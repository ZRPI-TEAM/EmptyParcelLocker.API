#!/bin/bash

apt-get update && apt-get install wget -y
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
apt-get update
apt-get install -y dotnet-sdk-6.0
dotnet tool install -g dotnet-ef
export PATH="$PATH:$HOME/.dotnet/tools"
dotnet ef --version
dotnet ef database update
dotnet EmptyParcelLocker.API.dll
