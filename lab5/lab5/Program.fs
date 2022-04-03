open System
(* 11.

let prog11 answ =
    if answ="F#"|| answ ="Prolog"
    then "Подлиза :), но я тебя уважаю"
    else if answ="Python"||answ="R"
        then "Я с тобой не разговариваю."
        else "Ааа... Понятно!"


[<EntryPoint>]
let main argv =
    printfn "Какой язык нраица?"
    let s = Console.ReadLine();
    printfn "%s" (prog11 s)
    0 
*)

(* 12.
[<EntryPoint>]
let main argv =
    printfn "Какой язык нраица?"
    let Ans ans = 
        match ans with 
        |"F#"|"Prolog"->"Подлиза :), но я тебя уважаю"
        |"Python"|"R"->"Я с тобой не разговариваю."
        |_->"Ааа... Понятно!"

    //carring

    //Console.ReadLine()|> Ans |>printfn "%s" 

    //superposition
    let kostbILFunc arg = (if arg=4 then "F#" else "R")
    let funcForSuper = kostbILFunc>>Ans>>printfn "%s"
    funcForSuper 4
    0
    *)