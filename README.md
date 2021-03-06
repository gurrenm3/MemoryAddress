# MemoryAddress
A highly optimized library for reading and writing values in Memory. 

There are a few popular libraries for reading and writing values in Memory. While they aren't bad, when it comes to reading/writing values in memory, they could be a lot better. This library uses OOP programming to have significantly faster read/write times (about 3x faster than other libraries).

This is based on and aims to be an improvement of [Memory.dll](https://github.com/erfg12/memory.dll) and [Squalr's](https://github.com/Squalr/Squalr) reading and writing.

## How to use it?
Download the latest release or build the source code to get a DLL, then reference that DLL in your Visual Studio project. There is a small amount of setup required to use this. Add the following code early on in your program execution:

```
var controller = new MemoryAddressController();
controller.AttachToProcess("name of your process");  // See Intellisense in VS for more info
```

if ``controller.AttachToProcess();`` is successful it will return true, meaning it successfully attached to the process you want to read/write. You are now ready to use this library. To use the optimized reading/writing features of this library, use the MemoryAddress class. 

Example:
```
var playerHealth = new MemoryAddress<int>("put your address here");

var currentHealth = playerHealth.Read(); // getting the value of an address
playerHealth.Write(1000); // setting the value of the address
```

## Why does this exist?
The leading Memory libraries are great, but in some ways can be bulky and poorly optimized. They are not the best option if all you want to do is read/write values in memory. This library uses OOP programming to achieve ~3x faster read/write speeds than the leading libraries. Additionally, this library comes with a handful of helpful extension/utility methods that you'll probably need if you're dealing with Memory. Finally, everything in this library is documented making it easy to understand what's happening.
