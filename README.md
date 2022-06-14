# _This project is no longer being maintained!_

Similar active projects:
* https://github.com/OutSystems/CefGlue
* https://github.com/chromelyapps/Chromely


# ChromiumGtk

ChromiumGtk is a WebView for GtkSharp using Chromium Embedded Framework (CEF) and CefGlue.


## Supported Platforms

* .NET Core 3.1 on Ubuntu 20.04 (AMD64)

## Dependencies

* [GtkSharp](https://github.com/GtkSharp/GtkSharp)
* [CEF](https://bitbucket.org/chromiumembedded/cef/)

## Installation

Use [nuget](https://www.nuget.org/packages/Lunixo.ChromiumGtk.Linux64/) to install ChromiumGtk.

```bash
dotnet add package Lunixo.ChromiumGtk.Linux64
```

## Usage

```C#
static void Main()
{
    var runtime = new Runtime();
    runtime.Initialize();
    Gtk.Application.Init();
    
    using var window = new Gtk.Window("ChromiumGTK Demo")
    {
        WidthRequest = 1200,
        HeightRequest = 800
    };
    
    window.Destroyed += (sender, args) => runtime.QuitMessageLoop();
    InteropLinux.SetDefaultWindowVisual(window.Handle);
    
    using var webView = new WebView();
    webView.LoadUrl("https://dotnet.microsoft.com/");
    
    window.Add(webView);
    window.ShowAll();
    
    runtime.RunMessageLoop();
    runtime.Shutdown();
}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)

This repository uses code from [CefGlue](https://gitlab.com/xiliumhq/chromiumembedded/cefglue) (MIT) and [Chromely](https://github.com/chromelyapps/Chromely) (MIT)
