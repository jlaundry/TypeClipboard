# TypeClipboard

For IT professionals everywhere who are sick of typing long complex passwords into remote consoles. Just copy the password into your clipboard, select the password box, and press F8 or click Type!

![Screenshot of Type Clipboard](/screenshot.png)

(Doesn't have to be a password either, also useful for URLs, Base64-encoded things, etc.)

This is also available in the Windows Store:

https://apps.microsoft.com/detail/9p5r4jk7r8h5

Tested with a wide variety of consoles, including vSphere, Horizon (HTML5), and Citrix.

## Known Issues

  * **VMWare vSphere Web Console** doesn't work with Chrome/Edge due to the way vSphere processes vScanCode values and what Chrome/Edge provide. [#6](https://github.com/jlaundry/TypeClipboard/issues/6).
    * I don't have a fix for this. I recommend you use Firefox or VMRC instead.

## Resolved Issues

  * **VMWare / Omnissa Horizon desktop client** uses a low-level keyboard driver, which SendKeys can't send to.
    * This may be fixed in v1.5 - I need feedback please!
  * **Using different keyboard layouts** between source and destination causes the sent keys to be mapped to the destination key location, not the intended source value. [#2](https://github.com/jlaundry/TypeClipboard/issues/2) [#3](https://github.com/jlaundry/TypeClipboard/issues/3)
    * Fixed in v1.5: https://github.com/jlaundry/TypeClipboard/releases/tag/1.5.0
