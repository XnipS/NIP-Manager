#include "../include/cloud.h"

Json::Value DownloadCloudInfo() {
  // Make info dir
  mkdir(NIP_InfoLocation, 0777);
  // Make path
  std::string path = (std::string)NIP_InfoLocation + NIP_InfoFile;
  // Get info from cloud
  DownloadFile(NIP_Cloud, path);
  // Return loaded json
  std::ifstream raw_data(path, std::ifstream::binary);

  Json::Value out;
  raw_data >> out;
  return out;
}