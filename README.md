# BlazorUtils.JsInterop

This project is meant to facilitate Blazor to Javascript interaction.<br>
It has categorized different JS interactions into different utility classes such as:<br>
- IJsInteropStorageUtils for browser storage utilities
- IJsInteropPwaUtils for PWA specific javascript APIs 
- IJsInteropTimeUtils for date and time specific javascript APIs 

### Installation
> Add reference to this BlazorUtils.JsInterop project in your Blazor project<br>
> The path will be specific to where you pull this repo on your system.
```
<ProjectReference Include="..\..\BlazorUtils\BlazorUtils.JsInterop\BlazorUtils.JsInterop.csproj" />
```

> Add the IJsInteropService to Program.cs
```
builder.Services.AddSingleton<IJsInteropService, JsInteropService>();
```

> Add below script to index.html
```
<script src="_content/BlazorUtils.JsInterop/jsinterop.js"></script>
```

### Usage
> Add below directives to get an instance of the JsInterop service in your razor component:
```
@using BlazorUtils.JsInterop
@inject IJsInteropService JSR
```
> Then use required utility, e.g. if you need to check if your web app is installed as a PWA:
```
    private async Task InstallPwaButtonClick()
    {
        IsPwaInstalled = await JSR.PwaUtils.IsPwaInstalled();

        if (!IsPwaInstalled)
        {
            await JSR.PwaUtils.ShowPwaInstallPrompt();
        }
    }
```

### Demo Project
Here's a project which uses BlazorUtils.JsInterop library:<br>
https://github.com/sobu86/TimeUtilities

You can take a look at this commit specifically which utilizes storage utils:<br>
https://github.com/sobu86/TimeUtilities/commit/84cdbb7ab4f90bb3778443e3e598ff4ca8e335a8
