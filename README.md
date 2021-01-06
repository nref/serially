# Serially

A pure .NET 5.0 library for serial communication. Includes a REPL.

![A GIF of the Serially REPL](https://github.com/slater1/serially/blob/main/Images/repl.gif)

## Build

```
git clone https://github.com/slater1/serially
cd serially
dotnet build --configuration Release
```
## Run

```
> .\bin\Release\AnyCPU\net5.0\Serially.App.exe
Serially: A REPL and tail for Serial Ports

Format:
  serially [action] [port]
[action]
  help: Show this message and exit
  tail: Tail the given port
  repl [default]: Open a CLI with the given port

[port]
  A Windows COM port, e.g. COM1

Examples:
  Open a REPL on COM1: serially COM1
            Equivalent: serially repl COM1
        Just tail COM2: serially tail COM2
```

## Prebuilt Release

A prebuilt binary is in the ```Install/``` folder. Copy ```Install/``` to wherever you'd like to run Serially from.

The ```Install/``` folder contains ```repl.ps1``` and ```tail.ps1``` which offer similar features as ```Serially.App.exe```
for use in PowerShell.

## Serially.Core

Serially.Core is a pure .NET 5.0 library for serial communication. 

## Serially.App

```Serially.App.exe``` provides an a REPL (Read-Eval-Print Loop) for two-way communication with serial devices.

Basic ASCII key sequence escaping and mapping is provided. The following basic sequences are implemented so that basic REPL interaction works: 

- Arrow Keys (Up, Down, Right, Left)
- Delete

Using the ```tail``` option, Serially.App can also just tail the device i.e. for logging.

The REPL detects when the COM port is removed e.g. if the serial device was physically unplugged.
It automatically reconnects when the COM port is added again.

```
usb_cli:~$ Port COM5 removed
Waiting for COM5 ...
Opened COM5
usb_cli:~$
```

## NuGet

https://www.nuget.org/packages/Serially.Core/

## License

Serially is a fork of OpenNETCF's serialportnet. Its license is provided in LICENSE.txt.
