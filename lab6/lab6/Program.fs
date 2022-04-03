open System


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
