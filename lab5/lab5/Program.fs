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

(* 17.
let rec nod a b =
if(a>0 && b>0)
then 
    if(a>b)
    then nod (a%b) b
    else nod a (b%a)
else if(a=0)
    then b else a
    
let max x y =
if x>y then x else y
    

let obhodVzaimProst num f defZnach cond = 
let rec obhodVzaimProstPodKapotom basicNum f defZnach currentNum cond =
    let resNum = currentNum-1
    if currentNum = 0 then defZnach
    elif ((nod basicNum currentNum) = 1 && cond currentNum) 
    then 
        let defZn2 = (f defZnach currentNum)
        obhodVzaimProstPodKapotom basicNum f defZn2 resNum cond
    else obhodVzaimProstPodKapotom basicNum f defZnach resNum cond
obhodVzaimProstPodKapotom num f defZnach num cond



let obhodDelit num f defaultZnach cond = 
let rec obhodDelitPodKapotom basicNum f defZn currentNum cond=
    let resNum = currentNum-1
    if currentNum = 0 then defZn
    elif((basicNum%currentNum) = 0 && cond currentNum) 
    then
         let defZn2 = (f defZn currentNum) 
         obhodDelitPodKapotom basicNum f defZn2 resNum cond
    else obhodDelitPodKapotom basicNum f defZn resNum cond
obhodDelitPodKapotom num f defaultZnach num cond

[<EntryPoint>]
let main argv =
let num = 11
(10 = obhodVzaimProst num (fun x y -> max x y) 0 (fun x -> x%2 = 0))  |> printfn "%b"
(9 = obhodVzaimProst num (fun x y -> max x y) 1 (fun x -> x%2 = 1)) |> printfn "%b"
let num2 = 8
(0 = obhodVzaimProst num2 (fun x y -> x+y) 0 (fun x -> x%2 = 0))  |> printfn "%b"
(1*3*5*7 = obhodVzaimProst num2 (fun x y -> x*y) 1 (fun x -> x%2 = 1)) |> printfn "%b"
0
*)
(*18.

 1.Количество чётных чисел не взаимно простых с данным*)
 (*
let rec nod a b =
 if(a>0 && b>0)
 then 
     if(a>b)
     then nod (a%b) b
     else nod a (b%a)
 else if(a=0)
     then b else a

let obhod num =
 let rec obhod_In num p acc currNum =
     let newNum = currNum-1
     let newAcc=acc+1
     if currNum=0 then acc
     else 
         if ((nod num newNum)<>1 && p newNum) then obhod_In num p newAcc newNum
         else obhod_In num p acc newNum
 obhod_In num (fun x -> if(x%2=0) then true else false) 0 num
 *)

(*
[<EntryPoint>]
let main argv =
 let num = 10
 obhod num |> printfn "%i"
 let num = 11
 obhod num |> printfn "%i"
 0

*)

(* 19.1
let rec nod a b =
if(a>0 && b>0)
then 
    if(a>b)
    then nod (a%b) b
    else nod a (b%a)
else if(a=0)
    then b else a
    
let max x y =
if x>y then x else y
    
let isDiv2 x = if(x%2=0) then true else false
let condToCase x y = if (not((nod x y) = 1) && isDiv2 y) then true else false

let obhodVzaimProst num = 
let rec obhodVzaimProstPodKapotom basicNum kolvoForKapot currentNum =
    let resNum = currentNum-1
    if currentNum = 0 then kolvoForKapot
    elif condToCase basicNum currentNum
    then 
        let newKolvo = kolvoForKapot+1
        obhodVzaimProstPodKapotom basicNum newKolvo resNum
    else obhodVzaimProstPodKapotom basicNum kolvoForKapot resNum
obhodVzaimProstPodKapotom num 0 num

[<EntryPoint>]
let main argv =
let num = 10
obhodVzaimProst num |> printfn "%i"
let num = 11
obhodVzaimProst num |> printfn "%i"
0
*)

(*//2.Найти максимальную цифру числа, не делящуюся на 3
   
   
   let findCiph n =
       let rec ciph1 n max p =
           if n=0 then max
           else
               let ciph=n%10
               let newN=n/10
               if(ciph>max&& p ciph) then ciph1 newN ciph p
               else ciph1 newN max p
       ciph1 n Int32.MinValue (fun x->x%3<>0)
   
   [<EntryPoint>]
   let main argv =
       Console.WriteLine("Enter a number: ")
       let n = Convert.ToInt32(Console.ReadLine())
       findCiph n|>printfn "%i"
       0
       *)

(* 19.2

let isNotDiv3 n= if(n%3<>0) then true else false
let f7 n = 
    let rec f9 n f init predicate = 
        if n = 0 then init
        else
            let cifr = n % 10
            let n1 = n / 10
            let acc = f init cifr
            if predicate cifr then f9 n1 f acc predicate
            else f9 n1 f init predicate
    f9 n (fun x y -> if x > y then x else y) -1 isNotDiv3

[<EntryPoint>]
let main argv =
    Console.WriteLine("Enter a number: ")
    let n = Convert.ToInt32(Console.ReadLine())
    f7 n|>printfn "%i"
    0
    *)

//18.3 19.3
(*
let sumCifr n = 
  let rec sumCifr1 n cond currSum = 
      if n = 0 then currSum
      else
          let n1 = n / 10
          let cifr = n % 10
          let newSum = currSum + cifr
          if cond cifr then
              sumCifr1 n1 cond newSum
          else sumCifr1 n1 cond currSum
  sumCifr1 n (fun x-> x<5) 0

let rec nod a b =
  if(a>0 && b>0)
  then 
      if(a>b)
      then nod (a%b) b
      else nod a (b%a)
  else if(a=0)
      then b else a

let checkVzaimProst x y =
  if (nod x y) = 1 then true else false

let naimDelNe1 n =
  let rec naimDelNe1_In n min currN =
      if currN = n then min
      else
          let newN=currN+1
          if newN=1 then naimDelNe1_In n min newN
          else if(min>newN && n%newN=0) then naimDelNe1_In n newN newN
          else naimDelNe1_In n min newN
  naimDelNe1_In n Int32.MaxValue 0   

let obhod3 n =
  let rec obhod3_In n p max currN =
      if currN=n-1 then max
      else 
          let newN=currN+1 
          if currN=1 then obhod3_In n p max newN
          else if(not(checkVzaimProst n newN) && (newN%(naimDelNe1 n)<>0) && p newN max) then obhod3_In n p newN newN
          else obhod3_In n p max newN
  obhod3_In n (fun x y-> if x>y then true else false) Int32.MinValue 0

let proizved x y = x*y

let otv n = proizved (obhod3 n) ((obhod3>>sumCifr) n)

[<EntryPoint>]
let main argv = 
    let n=15
    otv n|>printfn "%i"
    Console.ReadKey()
    0 // возвращение целочисленного кода выхода
 *)

(*20*)

    (*

let matchWithSolve = function
    |1-> obhod
    |2-> findCiph
    |3-> otv

let TheLastFuncCurring(ind, x) =
    x|>(ind|>matchWithSolve)

let TheLastFuncSuperpos(ind, x) =
    let shell x = x
    (matchWithSolve<<shell) ind x

[<EntryPoint>]
let main argv =
    Console.WriteLine("Enter a number: ")
    let n = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Enter a number of func: ")
    let ind = Convert.ToInt32(Console.ReadLine())
    let testFunc=TheLastFuncCurring(ind, n)=TheLastFuncSuperpos(ind, n)
    testFunc|>printfn"%b"
    0
    *) 
