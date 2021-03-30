#!/bin/bash

URL="https://cef-builds.spotifycdn.com/cef_binary_90.0.4%2Bgdc12a89%2Bchromium-90.0.4430.30_linux64_beta_client.tar.bz2"

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