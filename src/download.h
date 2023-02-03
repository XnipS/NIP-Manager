#pragma once
#include "pch.h"

static std::size_t write_data(void *ptr, std::size_t size, std::size_t nmemb,
                              void *stream) {
  std::size_t written = fwrite(ptr, size, nmemb, (FILE *)stream);
  return written;
}

inline void DownloadFile(std::string url, std::string output) {
  CURL *curl_handle;
  static const std::string pagefilename = output;
  FILE *pagefile;

  curl_global_init(CURL_GLOBAL_SSL);

  /* init the curl session */
  curl_handle = curl_easy_init();
  curl_easy_setopt(curl_handle, CURLOPT_URL, url.c_str());
  curl_easy_setopt(curl_handle, CURLOPT_WRITEFUNCTION, write_data);
  curl_easy_setopt(curl_handle, CURLOPT_USERAGENT, "libcurl-agent/1.0");
  // curl_easy_setopt(curl_handle, CURLOPT_VERBOSE, 1L);
  curl_easy_setopt(curl_handle, CURLOPT_NOPROGRESS, 0L);
  curl_easy_setopt(curl_handle, CURLOPT_FOLLOWLOCATION, 1L);
  curl_easy_setopt(curl_handle, CURLOPT_HTTPPROXYTUNNEL, 1L);
  curl_easy_setopt(curl_handle, CURLOPT_SSL_OPTIONS,
                   (long)CURLSSLOPT_ALLOW_BEAST | CURLSSLOPT_NO_REVOKE);

  /* open the file */
  pagefile = fopen(pagefilename.c_str(), "wb");
  if (pagefile) {
    /* write the page body to this file handle */
    curl_easy_setopt(curl_handle, CURLOPT_WRITEDATA, pagefile);

    /* get it! */
    curl_easy_perform(curl_handle);

    /* close the header file */
    fclose(pagefile);
  }

  /* cleanup curl stuff */
  curl_easy_cleanup(curl_handle);

  curl_global_cleanup();
}