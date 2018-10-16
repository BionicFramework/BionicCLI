#!/usr/bin/env bash

source ~/.nuget_bionic_key

DIR=$(dirname "$(readlink -f "$BASH_SOURCE")")

if [ -z "$1" ]
  then
    echo "No version supplied"
    exit 1
fi

if [ -z "${NUGET_BIONIC_KEY}" ]
  then
    echo "No NuGet key found for Bionic"
    exit 1
fi

${DIR}/build_release.sh

echo "Pushing Bionic.$1.nupkg to NuGet..."
dotnet nuget push ./Bionic/nupkg/Bionic.$1.nupkg --source https://api.nuget.org/v3/index.json --api-key ${NUGET_BIONIC_KEY}
if [ $? = 0 ]
  then
    echo "Completed pushing Bionic.$1.nupkg to NuGet. Should be available in a few minutes."
fi

echo "Pushing BionicCore.$1.nupkg to NuGet..."
dotnet nuget push ./BionicCore/nupkg/BionicCore.$1.nupkg --source https://api.nuget.org/v3/index.json --api-key ${NUGET_BIONIC_KEY}
if [ $? = 0 ]
  then
    echo "Completed pushing BionicCore.$1.nupkg to NuGet. Should be available in a few minutes."
fi

echo "Pushing BionicPlugin.$1.nupkg to NuGet..."
dotnet nuget push ./BionicPlugin/nupkg/BionicPlugin.$1.nupkg --source https://api.nuget.org/v3/index.json --api-key ${NUGET_BIONIC_KEY}
if [ $? = 0 ]
  then
    echo "Completed pushing BionicPlugin.$1.nupkg to NuGet. Should be available in a few minutes."
fi

echo "Pushing BionicPlugin.$1.nupkg to NuGet..."
dotnet nuget push ./BionicTemplates/nupkg/BionicTemplates.$1.nupkg --source https://api.nuget.org/v3/index.json --api-key ${NUGET_BIONIC_KEY}
if [ $? = 0 ]
  then
    echo "Completed pushing BionicTemplates.$1.nupkg to NuGet. Should be available in a few minutes."
fi
