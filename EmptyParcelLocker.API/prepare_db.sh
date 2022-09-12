#!/bin/bash

export PATH="$PATH:$HOME/.dotnet/tools"
dotnet ef --version
dotnet ef database update
dotnet EmptyParcelLocker.API.dll
