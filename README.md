# ourHtagEditor
H-tag editor is a simple grid editor that lets the editor pick a desired heading size (H1 down to H6) and the text-alignment (left, center or right).<br>
This editor is built for the Umbraco [Grid Layout](https://our.umbraco.org/documentation/getting-started/backoffice/property-editors/built-in-property-editors/grid-layout).

![H-tag editor in action](https://i.imgur.com/wHh4Cf7.gif)

## How to use
Download and install the package from our.umbraco.org or<br>
drop the files in the App_Plugins folder, located in the root of your Umbraco installation.

Install via NuGet or the Umbraco Package Installer: https://github.com/mastrup/ourHtagEditor/releases

## Setup

### Install Dependencies

```bash
npm install -g grunt-cli
npm install
```

### Build

```bash
grunt
```

### Changelog

**v1.0.3**
- Updated editor to the look and feel of Umbraco 8

**v1.0.2**
- New: Nuget package build
- Fix: Fixed issue where alignment and type wouldn't be transferred between environments

**v1.0.1**
- New: Nuget package build

**v1.0.0**
- Initial release