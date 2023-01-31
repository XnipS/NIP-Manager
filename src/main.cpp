#include "main.h"

#include <json/json.h>

#include <ostream>

bool m_isRunning;

void Init() {
  console::PrintToConsole("Welcome to NIP-Manager!");
  console::PrintToConsole("Please enter a command:");
  m_isRunning = true;
}

void Quit() {
  console::PrintToConsole("Goodbye!");
  m_isRunning = false;
}

void RequestCommand() {
  std::string userInput;
  std::cin >> userInput;

  if (userInput == "exit") {
    Quit();
  } else if (userInput == "ping") {
    console::PrintToConsole("Pong!");
  } else if (userInput == "listallgames") {
    Json::Value data;
    std::ifstream raw_data("../test.json",  // File location relative to build
                           std::ifstream::binary);

    raw_data >> data;
    for (unsigned int x = 0; x < data["Games"].size(); x++) {
      std::cout << data["Games"][x];
    }
    std::cout << std::endl;

  } else {
    console::PrintToConsole("Unknown command.");
  }
}

int main() {
  Init();
  while (m_isRunning) {
    RequestCommand();
  }
  return 0;
}
