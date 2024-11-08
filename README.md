# convert-wardrobe

On xabbo v1.0.3 and earlier, the wardrobe is stored in a LiteDB database named `wardrobe.db` in the same folder as the xabbo executable.\
From xabbo v1.1.0, the wardrobe is stored in a JSON file located at `%LOCALAPPDATA%\xabbo\wardrobe.json` on Windows and `~/.local/share/xabbo/wardrobe.json` on Linux/Mac.

# How to use

Requires the [.NET 8 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

Download the zip file for your OS from Releases and extract the binaries.

Make sure xabbo is not running.

On Windows you can drag your old `wardrobe.db` onto the `convert-wardrobe.exe` file.
The figures from the database should be inserted into the new xabbo JSON wardrobe file.

You can also use the terminal to convert a wardrobe file with the following command: `./convert-wardrobe wardrobe.db`.
