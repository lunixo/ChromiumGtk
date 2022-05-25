#!/bin/bash

URL="https://cef-builds.spotifycdn.com/cef_binary_102.0.3%2Bg53d4ce9%2Bchromium-102.0.5005.40_linux64_beta_client.tar.bz2"

echo "Downloading CEF ${URL}"

mkdir -p binary
curl ${URL} --output binary/binary.tar.bz2 

echo "Un-tar binaries ..."
tar -C binary -xvjf binary/binary.tar.bz2 --strip-components=2

echo "Stripping binaries ..."

strip binary/libcef.so
strip binary/libEGL.so
strip binary/libGLESv2.so
strip binary/libvk_swiftshader.so
strip binary/libvulkan.so.1