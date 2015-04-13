
file(GLOB cppfiles Source/*.cpp Source/*/*.cpp)

include_directories(Headers)

add_library(ember SHARED ${cppfiles})

