cmake_minimum_required(VERSION 3.5)

project(NIP-Manager LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

add_library(NIP-Manager STATIC
	src/console.cpp
	src/download.cpp
	src/extractor.cpp
	src/savefile.cpp
	src/cloud.cpp

	include/console.h
	include/download.h
	include/extractor.h
	include/core.h
	include/savefile.h
	include/cloud.h
)

add_executable(NIP-Manager-App src/main.cpp)

target_link_libraries(NIP-Manager-App jsoncpp curl archive NIP-Manager)

message(STATUS "Adding PCHs")
target_precompile_headers(NIP-Manager PRIVATE include/pch.h)