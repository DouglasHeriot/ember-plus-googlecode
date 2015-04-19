
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTOUIC ON)
set(CMAKE_AUTORCC ON)
set(CMAKE_INCLUDE_CURRENT_DIR ON)

find_package(Qt4 REQUIRED QtCore QtGui QtNetwork QtXml)
include(${QT_USE_FILE})

file(GLOB cppfiles gadget/*.cpp gadget/util/*.cpp glow/*.cpp glow/util/*.cpp net/*.cpp serialization/*.cpp serialization/detail/*.cpp util/*.cpp *.cpp)

include_directories(../../libember/Headers)
include_directories(../../libs101/Headers)
include_directories(../../libformula/Headers)

add_executable(TinyEmberPlus ${cppfiles} ${MOCSrcs} TinyEmberPlus.qrc)
target_link_libraries(TinyEmberPlus ember)
target_link_libraries(TinyEmberPlus ${QT_LIBRARIES})
