# If Anyone finds a better / smaller image that runs please update
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-focal AS base
RUN apt-get update && \
	apt-get clean && \
	apt-get upgrade -y && \
	DEBIAN_FRONTEND=noninteractive apt-get install -y xorg xvfb nano x11vnc fluxbox wget wmctrl dos2unix
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Lunixo.ChromiumGtk.Examples.Container/Lunixo.ChromiumGtk.Examples.Container.csproj", "Lunixo.ChromiumGtk.Examples.Container/"]
RUN dotnet restore "Lunixo.ChromiumGtk.Examples.Container/Lunixo.ChromiumGtk.Examples.Container.csproj"
COPY . .
WORKDIR "/src/Lunixo.ChromiumGtk.Examples.Container"
RUN dotnet build "Lunixo.ChromiumGtk.Examples.Container.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lunixo.ChromiumGtk.Examples.Container.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["Lunixo.ChromiumGtk.Examples.Container/bootstrap.sh", "."]
RUN dos2unix bootstrap.sh 
ENTRYPOINT ["./bootstrap.sh"]