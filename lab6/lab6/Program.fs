﻿open System


(* 9, 12, 22, 24, 31, 34, 40, 46, 58*)

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
                   System.Console.Write(head)
                   System.Console.Write(" ")
                   writeList tail 

let rec accCond list (f : int -> int -> int) p acc = 
    match list with
    | [] -> acc
    | h::t ->
                let newAcc = f acc h
                if p h then accCond t f p newAcc
                else accCond t f p acc

let rec condCount list p count = 
    match list with
    | [] -> count
    | h::t ->
                let newCount = count+1
                if p h then condCount t p newCount
                else condCount t p count

(* 11.
let func1 list (f : int -> int -> int -> int) = 
    let rec func1In list (f : int -> int -> int -> int) = 
        match list with
        []->[]

        |x1::x2::x3::tail ->
            (f x1 x2 x3)::(func1In tail f)
        |x1::x2::tail ->
            (f x1 x2 1)::[]
        |x1::tail ->
            (f x1 1 1)::[]
    func1In list f

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество эелемнтов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    let resultListSum = func1 list (fun x y z -> x+y+z)
    Console.WriteLine("Итоговый список:")
    writeList resultListSum

    *)
(*Задание 9. Дан целочисленный массив. Вернуть элементы перед последним минимальным

let listMin list = 
    match list with 
    |[] -> 0
    |h::t -> accCond list (fun x y -> if x < y then x else y) (fun x -> true) h

let indexOfLastMin list =
    let rec index_of_last_Min list tail indCurr indLast =
        match tail with
        |[]->indLast
        |h::t-> 
            let newIndCurr=indCurr+1
            if(listMin list = h) then index_of_last_Min list t newIndCurr newIndCurr
            else index_of_last_Min list t newIndCurr indLast
    index_of_last_Min list list -1 -1


let filtIndex list = 
    let rec filter1 list pr newList currInd = 
        match list with
        | [] -> newList
        | h::t ->
                let newCurrInd = currInd+1
                let newnewList = newList @ [h]
                if pr currInd then filter1 t pr newnewList newCurrInd
                else filter1 t pr newList newCurrInd
    filter1 list (fun x-> x<(indexOfLastMin list)-1) [] -1
                                      
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество эелемнтов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    Console.WriteLine("Последний минимальный: ")
    printfn "%i" (listMin list)
    Console.WriteLine("Последний минимальный индекс: ")
    printfn "%i" (indexOfLastMin list)
    Console.WriteLine("Список до последнего минимального: ")
    filtIndex list|>writeList|>ignore
    0

*)

(*//12. Вернуть список, заключенный между минимальным и максимальным элементами инвертировать

let listMin list = 
    match list with 
    |[] -> 0
    |h::t -> accCond list (fun x y -> if x < y then x else y) (fun x -> true) h

let listMax list = 
    match list with 
    |[] -> 0
    |h::t -> accCond list (fun x y -> if x > y then x else y) (fun x -> true) h
(*
*)
let pos list el = 
    let rec pos1 list el num = 
        match list with
            |[] -> 0
            |h::t ->    if (h = el) then num
                        else 
                            let num1 = num + 1
                            pos1 t el num1
    pos1 list el 0

let indexMin list = pos list (listMin list)
let indexMax list = pos list (listMax list)
let solve list =
    let rec solve1 list cond cond2 currInd newList1 newList2 newList3 minInd maxInd =
        match list with
        |[]->newList1@newList2@newList3
        |h::t-> 
            let newCurrInd=currInd+1
            let newnewlist1 = newList1@[h]
            let newnewlist2 = [h]@newList2
            let newnewlist3 = newList3@[h]
            if (cond newCurrInd minInd maxInd) then solve1 t cond cond2 newCurrInd newList1 newnewlist2 newList3 minInd maxInd
            elif (cond2 newCurrInd maxInd) then solve1 t cond cond2 newCurrInd newnewlist1 newList2 newList3 minInd maxInd
            else solve1 t cond cond2 newCurrInd newList1 newList2 newnewlist3 minInd maxInd
    solve1 list (fun x y z-> x>y && x<z) (fun x y-> x<y) -1 [] [] [] (indexMin list) (indexMax list)
            

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество эелемнтов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    Console.WriteLine("Минимальный: ")
    printfn "%i" (listMin list)
    Console.WriteLine("Индекс Минимального: ")
    printfn "%i" (indexMin list)
    Console.WriteLine("Максимальный: ")
    printfn "%i" (listMax list)
    Console.WriteLine("Индекс Максимального: ")
    printfn "%i" (indexMax list)
    Console.WriteLine("Между ними: ")
    solve list|>writeList|>ignore
    0
    *)

(*//22. Количество минимальных в промежутке a b

let listMin list = 
    match list with 
    |[] -> 0
    |h::t -> accCond list (fun x y -> if x < y then x else y) (fun x -> true) h

let buildListCond list a b =
    let rec buildRev currInd list between newList a b =
        match list with
        |[]->newList
        |h::t-> 
            let newInd=currInd+1
            let newnewList=newList@[h]
            if (between newInd a b) then buildRev newInd t between newnewList a b 
            else buildRev newInd t between newList a b
    buildRev -1 list (fun x y z-> x>y && x<z) [] a b 

let solve22 list a b =
    condCount (buildListCond list a b) (fun x -> x = (listMin list)) 0

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество эелемнтов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    Console.WriteLine("Минимальный: ")
    printfn "%i" (listMin list)
    Console.WriteLine("Введите интервал a b: ")
    let a = Convert.ToInt32(Console.ReadLine())
    let b = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Подсписок: ")
    buildListCond list a b|>writeList|>ignore
    Console.WriteLine("Количество минимальных между ними: ")
    solve22 list a b|>printfn "%i"
    0
    *)

(*//24. Найти два наибольших эелмента

let max2 list =
    let rec maxes list (max1,max2) =
        match list with
        |[]-> (max1,max2)
        |h::t->
            let newMax2=max1
            if(h>max1) then maxes t (h, newMax2)
            else maxes t (max1, max2)
    maxes list (Int32.MinValue, Int32.MinValue)


[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество эелемнтов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    max2 list|>printfn "%A" 
    0
*)
