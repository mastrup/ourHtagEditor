---
description: This article describes how you can use the H-tag editor tag helper in your views.
---

# How to use

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
