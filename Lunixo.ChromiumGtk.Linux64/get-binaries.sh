#!/bin/bash

URL="https://cef-builds.spotifycdn.com/cef_binary_88.2.7%2Bgc18ff58%2Bchromium-88.0.4324.150_linux64_client.tar.bz2"

echo "Downloading CEF ${URL}"

mkdir -p binary
curl ${URL} --output binary/binary.tar.bz2 

echo "Un-tar binaries ..."
tar -C binary -xvjf binary/binary.tar.bz2 --strip-components=2

echo "Stripping binaries ..."

strip binary/libcef.so
strip binary/libEGL.so
strip binary/libGLESv2.so
strip binary/swiftshader/libEGL.so
strip binary/swiftshader/libGLESv2.so