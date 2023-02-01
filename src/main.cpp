#include <iostream>

#include "console.h"
#include "download.h"
#include "pch.h"

bool m_isRunning;
Json::Value data;

void Init() {
  console::PrintToConsole("Welcome to NIP-Manager!");
  m_isRunning = true;
}

void Quit() {
  console::PrintToConsole("Goodbye!");
  m_isRunning = false;
}

void RequestCommand() {
  console::PrintToConsole("Please enter a command:");

  std::string userInput;
  std::cin >> userInput;

  if (userInput == "exit") {
    Quit();
  } else if (userInput == "ping") {
    console::PrintToConsole("Pong!");
  } else if (userInput == "allgames") {
    std::ifstream raw_data("../test.json",  // File location relative to build
                           std::ifstream::binary);

    raw_data >> data;
    for (unsigned int x = 0; x < data["Games"].size(); x++) {
      std::cout << data["Games"][x];
    }
    std::cout << std::endl;

  } else if (userInput == "download") {
    console::PrintToConsole("Select Game:");
    for (unsigned int x = 0; x < data["Games"].size(); x++) {
      std::cout << data["Games"][x]["Name"];
      std::cout << std::endl;
    }

    std::string selection;
    std::cin >> selection;

    int selectedGame = -1;
    for (unsigned int x = 0; x < data["Games"].size(); x++) {
      if (data["Games"][x]["Name"] == selection) {
        selectedGame = x;
        break;
      }
    }
    if (selectedGame == -1) {
      console::PrintToConsole("Selection is unknown. (You miss typed)");
    } else {
      DownloadFile(data["Games"][selectedGame]["Url"].asString(),
                   "output.tar.gz");
    }

  } else {
    console::PrintToConsole("Unknown command.");
  }
  std::cout << BigLine << std::endl;
}

int main() {
  Init();
  while (m_isRunning) {
    RequestCommand();
  }
  return 0;
}
