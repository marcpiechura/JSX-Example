module Counter

open Fable.Core
open Feliz

open Utils

[<JSX.Component>]
let Content key title (otherProps: string) = 
    let theme = Mui.useTheme()

    let (count, setCount) = React.useState 0
    let (someText, setSomeText) = React.useState ""
    
    JSX.jsx $"""
        import Box from '@mui/material/Box';
        import Button from '@mui/material/Button';
        import Typography from '@mui/material/Typography';
        import TextField from '@mui/material/TextField';
        import Stack from '@mui/material/Stack';

        <Stack>
            <Typography variant="h1">{title}</Typography>
            <Typography>You clicked {count} times</Typography>
            <Button onClick={fun _ -> setCount(count + 1)}>Click me</Button>

            <TextField 
                sx={ {| marginTop = theme.spacing 3 |} }
                variant="standard" label={otherProps} color="warning"
                value={someText} onChange={OnChange.value >> setSomeText}> </TextField>
        </Stack>
    """