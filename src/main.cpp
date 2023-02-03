#include <cstddef>
#include <iostream>
#include <ostream>

#include "../include/cloud.h"
#include "../include/console.h"
#include "../include/download.h"
#include "../include/extractor.h"
#include "../include/pch.h"
#include "../include/savefile.h"

bool m_isRunning;
Json::Value data;
SaveFile myFile;
bool myFileFound = false;

bool DoesExist(const std::string& name) {
  struct stat buffer;
  return (stat(name.c_str(), &buffer) == 0);
}

void ListAllCommands() {
  std::cout << NIP_BigLine << std::endl;
  PrintToConsole("Listing all available commands:");
  std::cout << NIP_BigLine << std::endl;
  PrintToConsole("help");
  std::cout << "Shows this message." << std::endl;
  PrintToConsole("exit");
  std::cout << "Closes the program." << std::endl;
  PrintToConsole("ping");
  std::cout << "Pong!" << std::endl;
  PrintToConsole("allgames");
  std::cout << "Lists all games from the NIP-Cloud." << std::endl;
  PrintToConsole("download");
  std::cout << "After asking which game, the specified game is downloaded."
            << std::endl;
}

void StatusCheck() {
  // Download cloudinfo
  data = DownloadCloudInfo();
  // Message
  std::cout << NIP_BigLine << std::endl;
  std::cout << "STATUS CHECK" << std::endl;
  std::cout << NIP_BigLine << std::endl;
  // Check my version
  if (data["NIP-ManagerLatest"] != NIP_VERSION) {
    PrintToConsole(
        "WARNING! NIP-Manager is out of date! Please download the newest "
        "version!");
  } else {
    PrintToConsole("NIP-Manager is up to date! :)");
  }
  // Loop games
  for (int x = 0; x < myFile.data.size(); x++) {
    // Loop cloud data
    bool found = false;
    for (int y = 0; y < data.size(); y++) {
      // Check if version diff
      if (data["Games"][y]["Name"] == myFile.data[x].title) {
        found = true;
        if (data["Games"][y]["Latest"] != myFile.data[x].version) {
          std::cout << data["Games"][y]["Name"] << " is outdated!" << std::endl;
        } else {
          std::cout << data["Games"][y]["Name"] << " is up to date!"
                    << std::endl;
        }
      }
    }
    if (!found) {
      std::cout << myFile.data[x].title << " was not found in cloud!"
                << std::endl;
    }
  }
}

void Init() {
  // Welcome Message
  PrintToConsole("Welcome to NIP-Manager!");
  // Check for game info
  if (DoesExist((std::string)NIP_SaveLocation + NIP_SaveFile)) {
    // Load saved data
    PrintToConsole("Data file loaded!");
    myFile = ReadSaveFile();
    myFileFound = true;
  } else {
    PrintToConsole("Data file missing or not generated!");
  }
  // Status check if found
  if (myFileFound) {
    StatusCheck();
  }
  // Now looping
  m_isRunning = true;
}

void Quit() {
  PrintToConsole("Goodbye!");
  m_isRunning = false;
}

void AllGames() {
  if (!data.empty()) {
    for (unsigned int x = 0; x < data["Games"].size(); x++) {
      std::cout << data["Games"][x];
    }
    std::cout << std::endl;
  } else {
    std::cout << "No Cloud Data loaded! Perform a statuscheck!" << std::endl;
  }
}

void Download(int gameId) {
  if (gameId == -1) {
    PrintToConsole("Selection is unknown. (You miss-typed)");
  } else {
    mkdir(NIP_DownloadLocation, 0777);
    std::string path = (std::string)NIP_DownloadLocation + "";
    PrintToConsole("Downloading to ->" + path);
    DownloadFile(data["Games"][gameId]["Url"].asString(), path);
    PrintToConsole("Extracting...");
    PrintToConsole(path + "/" + data["Games"][gameId]["Name"].asString());
    extract(path);
    if (std::remove(path.c_str()) != 0) perror("Error deleting file");
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
  } else if (userInput == "help") {
    ListAllCommands();
  } else if (userInput == "ping") {
    PrintToConsole("Pong!");
  } else if (userInput == "allgames") {
    AllGames();

  } else if (userInput == "download") {
    DownloadPrompt();
  } else {
    PrintToConsole("Unknown command.");
  }
  std::cout << NIP_BigLine << std::endl;
}

int main(int argc, char* args[]) {
  // SaveFile f = ReadSaveFile();
  // WriteSaveFile(&f);
  Init();

  while (m_isRunning) {
    RequestCommand();
  }
  return 0;
}
