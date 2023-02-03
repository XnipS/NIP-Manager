#pragma once
#include "pch.h"

struct SaveData {
  std::string title;
  std::string version;
  std::string location;
};
struct SaveFile {
  std::vector<SaveData> data;
};

void GenerateSaveFile();

SaveFile ReadSaveFile();

void WriteSaveFile(SaveFile* file);
