docker build --tag lunixo-chromiumgtk-example:1.0 --file "Dockerfile" ..
docker run -it lunixo-chromiumgtk-example:1.0

# Alternatively if you want to enalble VNC - Add run_vnc_server() in Main ./bootstrap.sh, but you cannot run the application in the same time unless you run VNC as deamon 
# docker run -it -p 5900:5900 -e VNC_SERVER_PASSWORD=somepass --privileged lunixo-chromiumgtk-example:1.0 -s
