# Web browser

Chromium-based internet browser performed by Pentiminax.

## How to install ?

```bash
git clone https://github.com/TrinicraftM/Navigateur
NavigateurWeb.sln
```

## How to config ?

```cs
//BrowserForm.cs
public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.Locale = "fr";

            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings);
            }

            WebBrowser = new ChromiumWebBrowser("https://www.google.fr/");
            BrowserPanel.Controls.Add(WebBrowser);
            WebBrowser.LoadingStateChanged += WebBrowser_LoadingStateChanged;

        }
```