#pragma once
#include <iostream>

class console {
 public:
  static void PrintToConsole(std::string input) {
#ifdef DEBUG_ON
    std::cout << "[" << console::currentDateTime() << "] " << input
              << std::endl;
#else
    std::cout << ">>> " << input << std::endl;
#endif
  };

 private:
  static const std::string currentDateTime() {
    time_t now = time(0);
    struct tm tstruct;
    char buf[80];

    tstruct = *localtime(&now);
    strftime(buf, sizeof(buf), "%d-%m-%Y %X", &tstruct);

    return buf;
  }
};