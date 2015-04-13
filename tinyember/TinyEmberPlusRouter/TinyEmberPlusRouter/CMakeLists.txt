
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_AUTOMOC ON)
set(CMAKE_INCLUDE_CURRENT_DIR ON)

find_package(Qt4 REQUIRED QtCore QtGui QtNetwork QtXml)
include(${QT_USE_FILE})

file(GLOB cppfiles glow/*.cpp model/*.cpp model/matrix/*.cpp model/matrix/detail/*.cpp net/*.cpp *.cpp)

include_directories(../../../libember/Headers)
include_directories(../../../libs101/Headers)

add_executable(TinyEmberPlusRouter ${cppfiles} ${MOCSrcs})
target_link_libraries(TinyEmberPlusRouter ember)
target_link_libraries(TinyEmberPlusRouter ${QT_LIBRARIES})
