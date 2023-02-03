#include "../include/savefile.h"

#include <cstddef>
#include <iostream>
#include <iterator>
#include <string>

void GenerateSaveFile(){
    // SaveFile save;
    // SaveData newData save.data.push_back()
};

SaveFile LoadSave() {
  // Get raw savefile
  std::ifstream input((std::string)NIP_SaveLocation + NIP_SaveFile);

  // Parse raw file to struct
  int i = 0;
  int currentSave = 0;
  SaveFile output;
  for (std::string line; getline(input, line, '|');) {
    if (i == 0) {
      SaveData da;
      da.title = line;
      output.data.push_back(da);
      i++;
    } else if (i == 1) {
      output.data[currentSave].version = line;
      i++;
    } else if (i == 2) {
      output.data[currentSave].location = line;
      currentSave++;
      i = 0;
    }
  }
  return output;
};

void SaveToSaveFile(SaveFile* file) {
  std::ofstream input((std::string)NIP_SaveLocation +
                      "/parse.nip");  // NIP_SaveFile);
  for (int i = 0; i < file->data.size(); i++) {
    input << file->data[i].title << "|";
    input << file->data[i].version << "|";
    input << file->data[i].location << "|";
  }
  input.close();
};