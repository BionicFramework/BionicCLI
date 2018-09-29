<span style="display:block;text-align:center;">![bionic](images/logo-full.png)</span>

<span style="display:block;text-align:center">Build web apps [Blazor](https://blazor.net) fast that run at [WASM speed](https://hackernoon.com/screamin-speed-with-webassembly-b30fac90cd92)!</span>

<span style="display:block;text-align:center">
    <a href="platforms/capacitor/ios"><img src="images/apple-logo.svg" alt="iOS" height="50px"/></a>
    &nbsp;&nbsp;&nbsp;
    <a href="platforms/electron"><img src="images/electron-logo.png" alt="Electron" height="50px"/></a>
    &nbsp;&nbsp;&nbsp;
    <a href="platforms/capacitor/android"><img src="images/android-logo.png" alt="Android" height="50px"/></a>
    &nbsp;&nbsp;&nbsp;
    <img src="images/pwa-logo.png" alt="PWA" height="40px"/>
</span>

# About

Bionic is an [Ionic Framework](https://ionicframework.com/) CLI clone for [Blazor](https://blazor.net/) projects.

The goal is to provide an easy, modular, and repeatable way of creating, building, and deploying Blazor projects.

Keep in mind that just like Blazor, this is an **exploration** project. With your help we can make it a reality.

## Features

- SCSS Style Isolation: Pages and components have their own SCSS file for quick and easy styling.
- Hot Rebuild: Automatically rebuild modified source or SCSS code (hot reloading not available, yet).
- Component Generation: Quickly generate Blazor pages, layouts, components, and services.
- Modular Platform Architecture: Project deployment platforms are provided through plugins and isolated within each project.
- Blast Scripting: Execute a group of commands under a single target name.

## Why

With the introduction of
[WebAssembly (WASM)](https://medium.com/mozilla-tech/why-webassembly-is-a-game-changer-for-the-web-and-a-source-of-pride-for-mozilla-and-firefox-dda80e4c43cb)
in the browser, it is now possible to use languages other than JavaScript to build amazing web apps that run at near native speed. This means that
[many languages](https://github.com/mbasso/awesome-wasm)
can now share code between frontend and backend without having to compromise computation power and typesafety as often happens in the world of JavaScript.

WebAssembly is maturing and will soon provide more functionality such as Garbage Collection, Multi-Threading, and much more.

With the creation of Blazor, [Steve Sanderson](https://github.com/SteveSanderson) made the promise of having WebAssembly on the frontend for web applications a reality.

At this point, marrying the power of Blazor with the power of a CLI simply made sense.

Hope you all have fun Blazing through some cool apps!
