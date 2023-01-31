cmake_minimum_required(VERSION 3.5)

project(NIP-Manager LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

include_directories(
    /include
)

add_executable(NIP-Manager src/main.cpp)

target_link_libraries(NIP-Manager jsoncpp)