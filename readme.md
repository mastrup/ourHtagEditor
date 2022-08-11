# ourHtagEditor
[![Nuget](https://img.shields.io/nuget/v/ourHtagEditor)](https://www.nuget.org/packages/ourHtagEditor/)

H-tag editor is a simple property editor that lets the editor pick a desired heading size (H1 down to H6) and the text-alignment (left, center or right).

## Prerequisites
Requires at least Umbraco 10.0.0.

## How to use
### Installation

Install ourHtagEditor via NuGet: `Install-Package ourHtagEditor`.

After restarting your site, you'll be able to create a new data type that uses the `Headline` property editor.

![H-tag editor in action](https://raw.githubusercontent.com/mastrup/ourHtagEditor/main/assets/img/screenshot.jpg)

### Using the Tag Helper
Browse to `/Views/_ViewImports.cshtml` in your Umbraco project and add the following line at the bottom
```cshtml
@addTagHelper *, OurHtagEditor
```
This will make it possible to use the following in your views:
```cshtml
<headline htag="@Model.Headline" />
```
Depending on your chosen settings on the property editor, it could render:
```html
<h2 style="text-align: left;">This is my nice headline</h2>
```

The tag helper accepts the attributes `class` and `link`.
The `link` attribute accepts the model Link, coming from the Multi URL Picker.

Using both attributes could look like this:
```cshtml
<headline htag="@Model.Headline" class="css-class" link="@Model.Link" />
```
Which will render:
```html
<a href="https://umbraco.com/" title="Visit Umbraco.com" target="_blank" rel="noopener">
    <h2 style="text-align: left;" class="css-class">This is my nice headline</h2>
</a>
```

### Changelog
Latest changes

**v2.0.0**
- Minimum required Umbraco version is 10.0.1.
- Added Tag Helper that can be used to generate the H-tag in views.
    - The old extension methods has been removed in favor of the new Tag Helper.
- Removed the grid functionality since it will be removed in Umbraco 13
- Accessibility enhancements of buttons and icons
- Renamed package from Our.Umbraco.HtagEditor to ourHtagEditor.
