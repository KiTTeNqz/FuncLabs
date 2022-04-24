// Learn more about F# at http://fsharp.org

open System

let printerAgent = MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async{
        let! msg = inbox.Receive()
        
        match msg with
        | "F#" -> printfn "%s"("Подлиза")
        | "Php" | "Python" -> printfn "%s"("Я с тобой не общаюсь.")
        | "Java" -> printfn "%s"("Ты мой лучший друг")
        | other -> printfn "%s"($"Впервые слышу о {other}")
        return! messageLoop()
        }
    messageLoop()

    )
[<EntryPoint>]
let main argv =
    let arg1 = printerAgent.Post("Php")
    let arg2 = printerAgent.Post("Java")
    let arg2 = printerAgent.Post("по темечку кувалдой")
    Console.ReadKey()
    0 // return an integer exit code
