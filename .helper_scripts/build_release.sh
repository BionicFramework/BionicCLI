#!/usr/bin/env bash

dotnet build -c Release /p:SourceLinkCreate=true /p:VersionSuffix= /p:OfficialBuild=true

dotnet pack -c Release /p:SourceLinkCreate=true /p:VersionSuffix= /p:OfficialBuild=true