// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let rec solve list1 list2 count =
    match list1 with
    |[]->count
    |h::t->
        let newCount = count + List.length(List.filter (fun x->x=h) list2)
        solve t list2 newCount

let shellSolve list1 list2 = solve list1 list2 0  

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество элементов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    Console.WriteLine("Введите количество элементов списка ")
    let list2 = Convert.ToInt32(Console.ReadLine()) |> readList
    let list1ForSolve = List.distinct list
    let list2ForSolve = List.distinct list2
    shellSolve list1ForSolve list2ForSolve|>printfn"%i"
    0
    
