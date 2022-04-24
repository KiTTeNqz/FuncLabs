// Learn more about F# at http://fsharp.org

open System

type Maybe<'T> =
    |Value of 'T
    |Nil

let equalTypes mb1 mb2 =
    match mb1, mb2 with
    |Value v1, Value v2 ->true
    |Nil, Nil ->true
    |_->false

let functorMaybe func mb1 =
    match mb1 with
    |Value v->Value(func v)
    |Nil->Nil

let (<*>) mbVal mbFunc =
    match mbVal, mbFunc with
    |Value v, Value f ->Value(f v)
    |_->Nil

let mbId1 v =
    Value(v)

let (>>=) mb1 func =
    match mb1 with
    |Value v-> func v
    |Nil->Nil

[<EntryPoint>]
let main argv =

    let id x = x
    let mb1 = Value(10)
    let mb2 = Nil
    printfn"%A"(functorMaybe id mb1)
    printfn"%A"(functorMaybe id mb2)
    printfn""

    let f x = x+5
    let g x = x*10
    printfn"%A"(functorMaybe (f>>g) mb1)
    printfn"%A"(functorMaybe g (functorMaybe f mb1))
    printfn""
    

    let mbId = Value(fun x->x)
    printfn"%A"(Value(10)<*>mbId)
    printfn"%A"(Nil<*>mbId)
    printfn""

    let func x = x * 3
    let mbFunc = Value(func)
    printfn "%A"(equalTypes (Value(3) <*> mbFunc) (Value(func 3)))
    printfn "%A"(equalTypes (Nil<*>mbFunc) (Nil))
    printfn ""

    //третьего закона нема
    //четвёртый невозможно проверить

    0 // return an integer exit code