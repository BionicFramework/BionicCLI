# Blast Scripting

Blast scripts are easy to use and organize.
They allow you to easily set up build/task sequences.

In your Blazor project Client or Standalone directory, use your favorite text editor or IDE to create or edit ```.bionic/bionic.blast```
Add the following content and save it:

```text
:electron
>electron-init
>electron-build

:electron-init
bionic platform add electron
bionic platform electron init

:electron-build
dotnet build
bionic platform electron build
bionic platform electron serve
```

Lines starting with:
```text
: - targets
> - sub-targets. Make sure that there are no spaces after it.
```
Any other type of line is a cli command.

Then have bionic blast it away:

 - ```bionic blast electron``` - Install Electron Plugin and prepare project for Electron.

The above task is to be done once since it is installing Plugin and initializing project. For subsequent deployments you should only need:  

 - ```bionic blast electron-build``` - Build Blazor project and serve Electron.

# Blast scripts not executing?

There's a bug in [dotnet tools](https://github.com/dotnet/cli/issues/9321) that is preventing bionic tool from being found in the system path.
There are several solutions. If you are in OSX, just edit ```/etc/paths.d/dotnet-cli-tools``` to be ```$HOME/.dotnet/tools```.
Did not try in Linux, but you may have to do the same or just edit your shell init script accordingly.
