module App

open System
open Fable.Core
open Feliz


JsInterop.import "" "@fontsource/roboto/300.css"
JsInterop.import "" "@fontsource/roboto/400.css"
JsInterop.import "" "@fontsource/roboto/500.css"
JsInterop.import "" "@fontsource/roboto/700.css"

[<Literal>]
let private themeDef = """createTheme({
  palette: {
    primary: {
        main: '#63C2C8',
    },
  },
})""" 

[<Import("createTheme", from="@mui/material/styles")>] 
[<Emit(themeDef)>]
let private theme : obj = jsNative

[<JSX.Component>]
let Root() =            
    JSX.jsx $"""
        import {{ ThemeProvider}} from '@mui/material/styles';
        import CssBaseline from '@mui/material/CssBaseline';
        import React from "react";

        <React.StrictMode>
            <ThemeProvider theme={theme}>
                <CssBaseline/>

                {Counter.Content "counter" "Counter 1" "Some text"}
            </ThemeProvider>
        </React.StrictMode>
    """

open Browser.Dom

document.getElementById "root"
|> ReactDOM.createRoot
|> fun r -> r.render(Root() |> unbox)