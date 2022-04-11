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
(*//10.
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
    
*)

(*//20. Дан список. Найти пропущенные числа

let buildListOfAllNums list =
    let rec buildList1 currEl basicList currList max =
        if(currEl>=max+1) then currList
        else 
            let newCurrEl=currEl+1
            let newCurrList=currList@[newCurrEl]
            buildList1 newCurrEl basicList newCurrList max
    buildList1 (List.min list) list [] (List.max list)

let allInOne list =
    List.except list (buildListOfAllNums list)

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество элементов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    allInOne list|>writeList|>ignore
    0
*)

(*//30. Дан индекс. Определить, является ли он локальным максимумом

let isLocalMax list index =
    let currItem = List.item index list
    let endOfList=(List.length list)-1
    match index with
    |0 ->
        if currItem > List.item (index+1) list then true
        else false
    |endOfList -> 
                if currItem > List.item (index-1) list then true
                else false
    |_ -> 
        if currItem > List.item (index+1) list && currItem > List.item (index-1) list then true 
        else false

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество элементов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    Console.WriteLine("Введите индекс: ")
    let index = Convert.ToInt32(Console.ReadLine()) 
    
    if (isLocalMax list index) then Console.WriteLine("Ряльно лок.максимум")
    else Console.WriteLine("Не лок.максимум")

    0
*)

(*//40. Минимальный чётный

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество элементов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    let list = List.filter (fun x -> x%2 =0) list
    List.min list|>printfn"%i"
    0
*)

(*//50. *)
let delEL list el = List.filter (fun x -> (x <> el)) list

let uniq list = 
    let rec uniq1 list newList = 
        match list with
            |[] -> newList
            |h::t -> 
                        let listWithout = delEL t h
                        let newnewList = List.append newList [h]
                        uniq1 listWithout newnewList
    uniq1 list [] 

let listsXOR list1 list2 newList =
    let rec xor list1 list2 newList =
        match list1 with
        |[]->newList
        |h::t->
                if(not(List.exists (fun x -> x = h ) list2)) then
                                                            let newnewlist = newList@[h]
                                                            xor t list2 newnewlist
                else xor t list2 newList
    xor list1 list2 newList



[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество элементов списка1 ")
    let list1 = Convert.ToInt32(Console.ReadLine()) |> readList
    Console.WriteLine("Введите количество элементов списка2 ")
    let list2 = Convert.ToInt32(Console.ReadLine()) |> readList
    let uniqList1 = uniq list1
    let uniqList2 = uniq list2
    let newList = listsXOR uniqList1 uniqList2 []
    listsXOR uniqList2 uniqList1 newList|>writeList|>ignore
    0     