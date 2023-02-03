#include "../include/console.h"
#include "../include/download.h"
#include "../include/extractor.h"
#include "../include/pch.h"

bool m_isRunning;
Json::Value data;

bool DoesExist(const std::string& name) {
  struct stat buffer;
  return (stat(name.c_str(), &buffer) == 0);
}

void Init() {
  PrintToConsole("Welcome to NIP-Manager!");
  if (DoesExist("./installed.nip")) {
    PrintToConsole("Data file found!");
  } else {
    PrintToConsole("Data file missing or not generated!");
  }
  m_isRunning = true;
}

void Quit() {
  PrintToConsole("Goodbye!");
  m_isRunning = false;
}

void AllGames() {
  std::ifstream raw_data("../test.json",  // File location relative to build
                         std::ifstream::binary);

  raw_data >> data;
  for (unsigned int x = 0; x < data["Games"].size(); x++) {
    std::cout << data["Games"][x];
  }
  std::cout << std::endl;
}

void Download(int gameId) {
  if (gameId == -1) {
    PrintToConsole("Selection is unknown. (You miss-typed)");
  } else {
    mkdir("downloaded", 0777);
    std::string path = "./downloaded/output.tar.gz";
    PrintToConsole("Downloading to ->" + path);
    DownloadFile(data["Games"][gameId]["Url"].asString(), path);
    PrintToConsole("Extracting...");
    // console::PrintToConsole(path + "/" +
    //                         data["Games"][gameId]["Name"].asString(););
    extract("./downloaded/output.tar.gz");
    PrintToConsole("Done!");
  }
}
void DownloadPrompt() {
  PrintToConsole("Select Game:");
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
  Download(selectedGame);
}

void RequestCommand() {
  PrintToConsole("Please enter a command:");

  std::string userInput;
  std::cin >> userInput;

  if (userInput == "exit") {
    Quit();
  } else if (userInput == "ping") {
    PrintToConsole("Pong!");
  } else if (userInput == "allgames") {
    AllGames();

  } else if (userInput == "download") {
    DownloadPrompt();
  } else if (userInput == "test") {
    PrintToConsole("Testing!");
    AllGames();
    DownloadPrompt();
  } else {
    PrintToConsole("Unknown command.");
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
