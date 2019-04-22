﻿<h1 align="center">HorribleSubs Renamer</h1>
<div align="center">

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-grammas-recipe.svg)](https://forthebadge.com)

[![GitHub license](https://img.shields.io/github/license/dbelz/HorribleSubs-Renamer.svg?longCache=true&style=flat-square)](https://github.com/dbelz/HorriblSubs-Renamer/blob/master/LICENSE.md)
[![Nuget](https://img.shields.io/nuget/v/HorribleSubsRenamer.svg?style=flat-square)](https://www.nuget.org/packages/HorribleSubsRenamer/)
[![GitHub last commit](https://img.shields.io/github/last-commit/dbelz/HorriblSubs-Renamer.svg?longCache=true&style=flat-square)](https://github.com/dbelz/HorriblSubs-Renamer)
[![GitHub issues](https://img.shields.io/github/issues/dbelz/HorribleSubs-Renamer.svg?longCache=true&style=flat-square)](https://github.com/dbelz/HorriblSubs-Renamer/issues)

This is a simple console application which is able to rename files downloaded from HorribleSubs XDCC bots to the emby/jellyfin/kodi/plex compatible format

<sub>Built with ❤︎ by Daniel Belz</sub>
</div><br>

* [Commandline options](#getting-started)
    * [--dir](#--dir)
	* [--extensions](#--extensions)
	* [--season](#--season)
    * [--headless](#--headless)

<br>

# Commandline options

### --dir
This option is used to specify the directory where the files to rename are located.  
**Required: false**  
**Default: Current directory**  

**Example:**  
```
HorribleSubsRenamer.exe --dir "C:\Test\"
```

### --extensions
This option is used to specify the file extensions which should be indexed.  
**Required: false**  
**Default: "mkv"**  

**Example:**  
```
HorribleSubsRenamer.exe --extensions mkv mp4
```

### --season
This option is used to specify the season number.  
**Required: false**  
**Default: 1**  

**Example:**  
```
HorribleSubsRenamer.exe -- season 2
```

### --headless
This option is used to specify if the application should run in headless mode (not asking for confirmation etc.).  

**Example:**  
```
HorribleSubsRenamer.exe -- headless true
```

## Contributing

__Contributions are always welcome!__  
Just send me a pull request and I will look at it. If you have more changes please create a issue to discuss it first.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
