#pragma once
#include "pch.h"

void DownloadFile(std::string url, std::string output);

std::size_t write_data(void *ptr, std::size_t size, std::size_t nmemb,
                       void *stream);