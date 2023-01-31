#include "main.h"

#include "console.h"

bool m_isRunning;
void Init() {
  console::PrintToConsole("Welcome to NIP-Manager!");
  m_isRunning = true;
}

void Quit() {}

void PrintToConsole();

int main() {
  Init();
  while (m_isRunning) {
    m_isRunning = false;
  }
  return 0;
}