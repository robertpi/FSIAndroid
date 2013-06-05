namespace FSInteractiveAndroid

open System
open System.IO

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open Microsoft.FSharp.Compiler.Interactive

[<Activity (Label = "FSInteractiveAndroid", MainLauncher = true)>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 1
    //let interactive = new InteractiveSession()
    
    let input = new Shell.CompilerInputStream()
    let output = new Shell.CompilerOutputStream()
    let error = new Shell.CompilerOutputStream()
    
    let input', output', error' = new StreamReader(input), new StreamWriter(output), new StreamWriter(error)
    let args = [|"fsi.exe"|]
    
    let interact = new Shell.FsiEvaluationSession(args, input', output', error')
    
    let doStart() =
        interact.Run()
        
        

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)
        
        doStart()

        // Set our view from the "main" layout resource
        this.SetContentView (Resource_Layout.Main)

        // Get our button from the layout resource, and attach an event to it
        let button = this.FindViewById<Button>(Resource_Id.myButton)
        button.Click.Add (fun args -> 
            button.Text <- sprintf "%d clicks!" count
            count <- count + 1
        )

