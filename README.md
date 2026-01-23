# TypeClipboard

For IT professionals everywhere who are sick of typing long complex passwords into remote consoles. Just copy the password into your clipboard, select the password box, and press F8 or click Type!

![Screenshot of Type Clipboard](/screenshot.png)

(Doesn't have to be a password either, also useful for URLs, Base64-encoded things, etc.)

Also, if you don't want to compile yourself, this is also available in the Windows Store:

https://www.microsoft.com/en-us/p/type-clipboard/9p5r4jk7r8h5

Tested with a wide variety of consoles, including vSphere, Horizon (HTML5), and Citrix. There is a known issue where VMWare Horizon's client seems to be using a very low-level keyboard driver, so it doesn't work with it. Sorry.

## Developing

My development environment is (currently) Windows 11 Enterprise on arm64, with Visual Studio Community 2026.

When installing, you will need the following components:

  * .NET desktop development (just the basic .NET 4.7.2 options)
  * WinUI application development
  * Windows 11 SDK (10.0.26100.0)

