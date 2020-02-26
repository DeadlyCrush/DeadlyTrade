# WindowsHook
Based on [MouseKeyHook](https://github.com/gmamaladze/globalmousekeyhook) by gmamaladze . I made some changes to to support .Net 4.0+,.Net Core 3.0+, WinForm, WPF etc. To make this project not to depend on System.Windows.Forms, some codes are from Microsoft which files are under system.Windows.Forms. I changed original namepsace to WindowsHook.

[![nuget][nuget-badge]][nuget-url]

 [nuget-badge]: https://img.shields.io/badge/nuget-v5.4.0-blue.svg
 [nuget-url]: https://www.nuget.org/packages/WindowsHook

![Mouse and Keyboard Hooking Library in c#](/mouse-keyboard-hook-logo.png)

## What it does?

This library allows you to tap keyboard and mouse, to detect and record their activity even when an application is inactive and runs in background.

## Prerequisites

 - **Windows:** .Net 4.0+,.Net Core 3.0+, Windows Desktop Apps(WinForm, WPF etc.)

## Installation and sources

<pre>
  nuget install WindowsHook
</pre>

 - [NuGet package][nuget-url]
 - [Source code][source-url]

 [source-url]: https://github.com/topstarai/WindowsHook

 ## Usage

 ```csharp
 private IKeyboardMouseEvents m_GlobalHook;

 public void Subscribe()
 {
     // Note: for the application hook, use the Hook.AppEvents() instead
     m_GlobalHook = Hook.GlobalEvents();

     m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
     m_GlobalHook.KeyPress += GlobalHookKeyPress;
 }

 private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
 {
     Console.WriteLine("KeyPress: \t{0}", e.KeyChar);
 }

 private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
 {
     Console.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);

     // uncommenting the following line will suppress the middle mouse button click
     // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
 }

 public void Unsubscribe()
 {
     m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
     m_GlobalHook.KeyPress -= GlobalHookKeyPress;

     //It is recommened to dispose it
     m_GlobalHook.Dispose();
 }
 ```
(also have a look at the Demo app included with the source)

## How it works?

This library attaches to windows global hooks, tracks keyboard and mouse clicks and movement,please note this don't support common .Net events with KeyEventArgs and MouseEventArgs. this is the difference with WindowsHook project. But you can still easily retrieve any information you need:
 * Mouse coordinates
 * Mouse buttons clicked
 * Mouse drag actions
 * Mouse wheel scrolls
 * Key presses and releases
 * Special key states

 Additionally, there are `MouseEventExtArgs` and `KeyEventExtArgs` which provide further options:
 * Input suppression
 * Timestamp
 * IsMouseDown/Up
 * IsKeyDown/Up.

## Quick contributing guide

 - Fork and clone locally
 - Create a topic specific branch. Add some nice feature.
 - Send a Pull Request to spread the fun!

## License

The MIT license see: [LICENSE.txt](/LICENSE.txt)
