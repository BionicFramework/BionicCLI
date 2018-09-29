# Videos

## Bionic Monitor Release and demo

Bionic Monitor provides live reloading capability to both Standalone and Hosted Blazor projects.

<iframe width="560" height="315" src="https://www.youtube.com/embed/68xYErxxKLQ" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

The above demo did not make use of Bionic Monitor configuration file but once set it does not require one to pass 
command line arguments to Bionic Monitor. 


## Bionic 1.0.18 release and PWA demo

#### Published: Aug 29, 2018

<iframe width="560" height="315" src="https://www.youtube.com/embed/OFAOxmwrR0Q" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

#### What's new this week:

- Bionic 1.0.18 release

- PWA integration

- Blazor Layout generation

Fixed several issues found while trying to have app deployed as a PWA.

This video also shows current effort to create a tutorial app that will be available in new documentation site.

#### New bionic command:

- bionic generate layout MyLayout


## Bionic Docs and Bridge

#### Published: Aug 18, 2018

<iframe width="560" height="315" src="https://www.youtube.com/embed/Jnn0DgXcDIk" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

#### What's new this week:

- Documentation is now available at [here](https://bmsantos.github.io/bionic)

- Bionic Capacitor Plugin now provides bridge init command that allows for device level functionality. You can read more [here](https://bmsantos.github.io/bionic/platforms/capacitor/0intro)

This video also shows current effort to create a tutorial app that will be available in new documentation site.

#### New Capacitor plugin commands:

- bionic platform capacitor bridge init


## From 0 to iOS with Bionic

#### Published: Aug 10, 2018

<iframe width="560" height="315" src="https://www.youtube.com/embed/ivvS1okYu7E" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

#### What's new this week:

- Introduces ios support through capacitor platform plugin

- Demonstrates current effort in exposing capacitor device level functionality to Blazor apps

#### New Capacitor plugin commands:

- bionic platform capacitor android sync
- bionic platform capacitor ios init
- bionic platform capacitor ios build
- bionic platform capacitor ios sync
- bionic platform capacitor ios open


## Bionic 1.0.17 - From 0 to Android with Bionic

#### Published: Aug 3, 2018

<iframe width="560" height="315" src="https://www.youtube.com/embed/67A1ZVlyUfA" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

#### What's new on version 1.0.17

- Fixed Services issue broken since Blazor 0.5

- Introduces \[Injectable\] attribute for Services

- Introduces capacitor platform plugin

#### Capacitor plugin commands:

- bionic platform capacitor init
- bionic platform capacitor android init
- bionic platform capacitor android build
- bionic platform capacitor android open


## Bionic 1.0.16 - From 0 to Electron with Bionic

#### Published: Jul 27, 2018

<iframe width="560" height="315" src="https://www.youtube.com/embed/2aGTsSe7-MU" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

#### What's new on version 1.0.16

- Plugin Architecture - Plugins are fetched and loaded from NuGet.

- Introduces bionic platform command

- Introduces electron platform plugin

- Introduces blast scripting


#### Added Maintenance Commands:

- bionic blast \[target\]
- bionic platform add \[short-plugin-name\]

#### Electron plugin commands:

- bionic platform electron init
- bionic platform electron build
- bionic platform electron serve


## Bionic 1.0.12 - First maintenance and dev commands

#### Published: July 17 2018

<iframe width="560" height="315" src="https://www.youtube.com/embed/NONCv-i4Q34" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

Version 1.0.12 adds support for both Standalone and Hosted Blazor projects as well as plethora of new commands:

#### Maintenance commands

- bionic --version
- bionic docs
- bionic info
- bionic serve
- bionic uninstall
- bionic update
- bionic -h

#### Development commands

- bionic start
- bionic serve
- bionic generate page MyPage
- bionic generate component MyComponent
- bionic generate service MyService
- bionic -g


## Bionic - Ionic CLI clone for Blazor

#### Published: Jul 8, 2018

<iframe width="560" height="315" src="https://www.youtube.com/embed/_YRR6L2Pzks" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

Bionic aims to be an Ionic CLI clone for Blazor projects. As of now, it only allows to easy add and style Blazor components.