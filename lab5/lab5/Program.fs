﻿open System
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

(* 13.
let rec proizved n = 
    if n=0 then 1
    else n%10*proizved(n/10)

let max num = 
    let rec max1 num maxCipher =
        if num = 0 then maxCipher
        else
            let nM = (num%10)
            let nDel = (num/10)
            if(nM>maxCipher) then max1 nDel nM
            else
                max1 nDel maxCipher
    max1 num 0
    
let min num = 
    let rec min1 num minCipher =
        if num = 0 then minCipher
        else
            let nM = (num%10)
            let nDel = (num/10)
            if(nM<minCipher) then min1 nDel nM
            else
                min1 nDel minCipher
    min1 num 10


[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число: ")
    let n = Convert.ToInt32(Console.ReadLine())
    let maxOut = max>>printfn "%i"
    let proizvedOut = proizved>>printfn "%i"
    let minOut = min>>printfn "%i"
    Console.WriteLine("Max ciph: ")
    maxOut n
    Console.WriteLine("Proizved ciph: ")
    proizvedOut n
    Console.WriteLine("Min ciph: ")
    minOut n
    0
    *)

(* 14.

let obhodDelit num f defaultZnach = 
    let rec obhodDelitPodKapotom basicNum f defZn currentNum =
        let resNum = currentNum-1
        if currentNum = 0 then defZn
        elif((basicNum%currentN) = 0) 
        then
             let defZn2 = (f defZn currentNum) 
             obhodDelitPodKapotom basicNum f defZn2 resNum
        else obhodDelitPodKapotom basicNum f defZn resNum
    obhodDelitPodKapotom num f defaultZnach num
        

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let num = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Сумма делителей числа равна: ")
    printfn "%i" (obhodDelit num (fun x y -> x+y)  0)
    0 
    *)

(* 15.

let rec nod a b =
    if(a>0 && b>0)
    then 
        if(a>b)
        then nod (a%b) b
    else nod a (b%a)
    else if(a=0)
        then b else a
        
    
let obhodVzaimProst num f defZnach = 
    let rec obhodVzaimProstPodKapotom basicNum f defZnach currentNum =
        let resNum = currentNum-1
        if currentNum = 0 then defZnach
        elif ((nod basicNum currentNum) = 1) 
        then 
            let defZn2 = (f defZnach currentNum)
            obhodVzaimProstPodKapotom basicNum f defZn2 resNum
        else obhodVzaimProstPodKapotom basicNum f defZnach resNum
    obhodVzaimProstPodKapotom num f defZnach num

[<EntryPoint>]
    let main argv =
    Console.WriteLine("Введите число")
    let num = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Сумма взаимнопростых делителей числа равна: ")
    printfn "%i" (obhodVzaimProst num (fun x y -> x+y) 0)
    0
*)

(*   // 16.
let rec nod a b =
   if(a>0 && b>0)
   then 
       if(a>b)
       then nod (a%b) b
       else nod a (b%a)
   else if(a=0)
       then b else a
       
   
let obhodVzaimProst num f kolvo = 
   let rec obhodVzaimProstPodKapotom basicNum f kolvoForKapot currentNum =
       let resNum = currentNum-1
       if currentNum = 0 then kolvoForKapot
       elif ((nod basicNum currentNum) = 1) 
       then 
           let newKolvo = (f kolvoForKapot currentNum)
           obhodVzaimProstPodKapotom basicNum f newKolvo resNum
       else obhodVzaimProstPodKapotom basicNum f kolvoForKapot resNum
   obhodVzaimProstPodKapotom num f kolvo num

let eulerFunc n =
   obhodVzaimProst n (fun x y -> x+1) 0

[<EntryPoint>]
let main argv =
   //Console.WriteLine("Введите число")
   let num = 10
  // Console.WriteLine("Введите второе число число")
   let num2 = 11
   Console.WriteLine("Количество взаимнопростых делителей первого числа равна: ")
   eulerFunc num|>printfn "%i" 
   Console.WriteLine("Количество взаимнопростых делителей второго числа равна: ")
   eulerFunc num2|>printfn "%i" 
   Console.WriteLine("Их НОД равен: ")
   nod num num2|>printfn "%i"
   Console.WriteLine("Тесты: ")
   (4=eulerFunc num)|>printfn"%b"
   (10=eulerFunc num2)|>printfn"%b"
   (1=nod num num2)|>printfn"%b"
   0

*)