﻿<h1 align="center">HorribleSubs Renamer</h1>
<div align="center">

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-grammas-recipe.svg)](https://forthebadge.com)

[![GitHub license](https://img.shields.io/github/license/dbelz/HorribleSubs-Renamer.svg?longCache=true&style=flat-square)](https://github.com/dbelz/HorribleSubs-Renamer/blob/master/LICENSE.md)
[![GitHub last commit](https://img.shields.io/github/last-commit/dbelz/HorribleSubs-Renamer.svg?longCache=true&style=flat-square)](https://github.com/dbelz/HorribleSubs-Renamer)
[![GitHub issues](https://img.shields.io/github/issues/dbelz/HorribleSubs-Renamer.svg?longCache=true&style=flat-square)](https://github.com/dbelz/HorribleSubs-Renamer/issues)

This is a simple console application which is able to rename files downloaded from HorribleSubs XDCC bots to the emby/jellyfin/kodi/plex compatible format.

<sub>Built with ❤︎ by Daniel Belz</sub>
</div><br>

* [Sample output](#sample-output)
* [Commandline options](#commandline-options)
    * [--source](#--source)
	* [--extensions](#--extensions)
	* [--season](#--season)
	* [--old-value and --new-value](#--old-value-and---new-value)
	* [--create-subfolders](#create-subfolders)
    * [--headless](#--headless)

<br>

## Sample output
A renamed file will look like this:
```
Tokyo Ghoul - s01e01.mkv
```

## Commandline options

### --source
This option is used to specify the directory where the files to rename are located.  
Required: false  
Default: Current directory  

Example:  
```
dotnet HorribleSubsRenamer.dll --source "C:\Test\"
```

### --extensions
This option is used to specify the file extensions which should be indexed.  
Required: false  
Default: mkv  

Example:  
```
dotnet HorribleSubsRenamer.dll --extensions mkv mp4
```

### --old-value and --new-value
These options are used to replace a certain string in the extracted title.  
Required: false  
Default: null  

Example:  
```
Source title: Tokyo Ghoul S2

dotnet HorribleSubsRenamer.dll --old-value "S2" --new-value ""

Output: Tokyo Ghoul
```

### --season
This option is used to specify the season number.  
Required: false  
Default: 1  

Example:  
```
dotnet HorribleSubsRenamer.dll -- season 2
```

### --create-subfolders
Used to specify if the application should create a directory for every renamed episode.  
Example:  
```
dotnet HorribleSubsRenamer.dll -- create-subfolders true
```

### --headless
Used to specify if the application should run in headless mode (not asking for confirmation).  
Example:  
```
dotnet HorribleSubsRenamer.dll -- headless true
```

## Contributing

__Contributions are always welcome!__  
Just send me a pull request and I will look at it. If you have more changes please create a issue to discuss it first.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
