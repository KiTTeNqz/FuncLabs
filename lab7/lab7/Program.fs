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

(*//50. 
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
    let uniqList1, keys = List.unzip(List.countBy id list1)
    let uniqList2, keys = List.unzip(List.countBy id list2)
    let newList = listsXOR uniqList1 uniqList2 []
    listsXOR uniqList2 uniqList1 newList|>writeList|>ignore
    0  
*)

(*//60.Найти уникальные элементы, проверить делятся ли они на свои номера, и если делятся запихнуть в новый список

let rec divByIndexAndOccur1time list (indexList:int list) (occurList:int list) (newList:int list) =
    match list with
    |[]->newList
    |h::t->
        if(occurList.Head = 1 && not(indexList.Head=0) && h%indexList.Head = 0) then
                                                        let newnewList =List.append newList [h]
                                                        divByIndexAndOccur1time t indexList.Tail occurList.Tail newnewList
        else divByIndexAndOccur1time t indexList.Tail occurList.Tail newList

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество элементов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    let list1, keys = List.unzip(List.countBy id list)
    let index, list2 = List.unzip(List.indexed list1)
    divByIndexAndOccur1time list2 index keys []|>writeList|>ignore 
    0  
*)

(*//17.Вывести 3 списка:
    1. Номера элементов, которые могут получены как произведение двух любых элементов списка
    2. Номера элементов, которые могут получены как сумма любых других элементов списка.
    3. Номера элементов, которые делятся на 4 элемента из списка


let listExceptIndex index list =
    let rec except1 index list newList index2 =
        match list with
        |[]->newList
        |h::t->
                let newIndex=index2+1
                let newnewList = newList@[h]
                if newIndex=index then 
                                        except1 index t newList newIndex
                else except1 index t newnewList newIndex
    except1 index list [] -1


let listDelCount4 list indexes =
    let rec delCount basicList list newListIndexes (indexes:int list) =
        match list with
        |[]->newListIndexes
        |h::t->
                    if (List.length (List.filter (fun x->(x<>0)&&(h%x=0)) (listExceptIndex indexes.Head basicList))) = 4 then 
                                                                                                   delCount basicList t (List.append newListIndexes [indexes.Head]) indexes.Tail
                    else delCount basicList t newListIndexes indexes.Tail  
    delCount list list [] indexes

let buildMultList list indexes =
    let rec mult1 basicList list newList (indexes:int list) =
        match list with
        |[]->newList
        |h::t-> 
                    let newnewList=newList@List.map (fun x-> x*h) (listExceptIndex indexes.Head basicList)
                    mult1 basicList t newnewList indexes.Tail
    mult1 list list [] indexes

let buildMultCond list indexes =
    let rec build1 basicList list newListIndexes (indexes:int list) multList =
        match list with
        |[]->newListIndexes
        |h::t->
            if(List.exists (fun x->x=h) multList) then
                                                    build1 basicList t (List.append newListIndexes [indexes.Head]) indexes.Tail multList
            else build1 basicList t newListIndexes indexes.Tail multList
    build1 list list [] indexes (buildMultList list indexes)

let buildSumList list =
    let rec mult1 basicList list newList =
        match list with
        |[]->newList
        |h::t -> 
            if(not(h=List.last basicList)) then
                let itemForTrippleSum = List.item((List.findIndex(fun x->x=h) basicList)+1) basicList
                let listForConcat = List.map(fun x-> x+h+itemForTrippleSum) (List.except [h] (List.except [itemForTrippleSum] basicList))
                let newnewList = newList@(List.filter(fun x-> not(List.contains x newList)) listForConcat)
                mult1 basicList t newnewList
            else mult1 basicList t newList
    mult1 list list [] 
                

let buildSumCond list indexes =
    let rec build1 basicList list newListIndexes (indexes:int list) sumList =
        match list with
        |[]->newListIndexes
        |h::t->
            if(List.exists (fun x->x=h) sumList) then
                                            build1 basicList t (List.append newListIndexes [indexes.Head]) indexes.Tail sumList
            else build1 basicList t newListIndexes indexes.Tail sumList
    build1 list list [] indexes (buildSumList list)


[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите количество элементов списка ")
    let list = Convert.ToInt32(Console.ReadLine()) |> readList
    let index, list1 = List.unzip(List.indexed list)
    let multCond = buildMultCond list index
    let sumCond = buildSumCond list index
    let delCond = listDelCount4 list index
    let (list2, list3, list4) = (multCond, sumCond, delCond)
    printfn"%A"((list2, list3, list4))
    0
*)

(*
let rec nod a b =
    if(a%b = 0.0) then b
    elif (b%a = 0.0) then a
    elif ((abs a)>(abs b)) then nod (a%b) a
    else nod a (b%a)

let readarr n =
    let rec readarr1 n arr =
        match n with
        |0 -> arr
        |_ ->
            let Head = Convert.ToDouble(Console.ReadLine())
            let new_arr = Array.append arr [|Head|]
            readarr1 (n-1) new_arr
    readarr1 n Array.empty

let writeArr arr =  
    printfn "%A" arr

let delInArr a =
    let rec del1 a mod_a (newArr:double []) =
        match mod_a with
        |0.-> del1 a (mod_a+1.0) newArr
        |x when x<=abs(a)-> 
                    if(a%x=0.) then 
                                    let newnewArr = Array.append newArr [|-mod_a|]
                                    let newnewArr2 = Array.append newnewArr [|mod_a|]
                                    del1 a (mod_a+1.0) newnewArr2
                    else del1 a (mod_a+1.0) newArr
        |x when x>abs(a)->newArr
    del1 a 0. [||]


let formDr arr a = Array.map (fun x-> (x/(nod x a))/(a/(nod x a))) arr 
//НАПИСАТЬ НОД ДЛЯ ПРОВЕРКИ НЕСОКРАТИМЫХ ДРОБЕЙ
let formArrPossibleRoots arr1 arr2 =
    let rec del1 (arr1:double []) (arr2:double []) n (arrOfRoots:double []) =
        if n <> Array.length arr2 then 
                                    let new_itog = Array.append arrOfRoots (formDr arr1 arr2.[n])
                                    del1 arr1 arr2 (n+1) new_itog
        else arrOfRoots
    del1 arr1 arr2 0 [||]

let checkRoot arr root=
    let rec isRoot (arr:float array) root acc deg =
        match deg with
        |(-1)->acc
        |_->
            let newAcc=acc+arr.[deg]*(pown root deg)
            let newDeg = deg-1
            isRoot arr root newAcc newDeg
    isRoot arr root 0. ((Array.length arr)-1)
        
[<EntryPoint>]
let main argv =
    let n =Convert.ToInt32(Console.ReadLine())
    let arr = readarr (n+1)
    let p = delInArr (arr.[n])
    let q = delInArr (arr.[0])
    let q2=Array.filter (fun x-> x>0.) q
    let possibleRoots = formArrPossibleRoots q2 p
    let roots = Array.filter (fun x-> abs((checkRoot arr x))<0.001) possibleRoots
    writeArr roots
    0
*)


(*//19.
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку ")
    let str1 = Console.ReadLine()
    Console.WriteLine("Выберите метод от 1 до 3")
    let a = Convert.ToInt32(Console.ReadLine())
    match a with
    |1->
        let str = str1|>String.map Char.ToUpper 
        let stringRev = List.rev(Seq.toList str)
        List.ofSeq str = stringRev|>printfn"%b"
    |2->Array.length(str1.Split " ")|>printfn"%i"
    |3->List.length(List.distinct(Seq.toList str1))|>printfn"%A"
    |_->Console.WriteLine("Столько я не сделаю")
    0
*)
(*//20
let stringFold func (str:string) acc =
    let rec fold1 index acc =
        match index with
        |theLast when theLast=str.Length->acc
        |_->
            let newState = func acc (str.Chars index)
            let newInd=index+1
            fold1 newInd newState
    fold1 0 acc

let stringFold2 func (str:string) acc =
    let rec fold1 index acc =
        match index with
        |theLast when theLast>=(str.Length-2)->acc
        |_->
            let newState = func acc str.[index] str.[index+2]
            let newInd=index+3
            fold1 newInd newState
    fold1 0 acc

let isVowel letter =
    match letter with
    |'a'|'A'->true
    |'e'|'E'->true
    |'i'|'I'->true
    |'o'|'O'->true
    |'u'|'U'->true
    |'y'|'Y'->true
    |_->false

let countVowel string = stringFold (fun x y-> if (isVowel y) then (x+1.0) else x) string 0.
let countConsonant (string:string) =Convert.ToDouble(string.Length)-(countVowel string)

let ratio str = ((countConsonant str)/Convert.ToDouble(String.length str)) - (countVowel str/Convert.ToDouble(String.length str)) 

let trippleCount str = stringFold2 (fun x y z-> if y=z then (x+1) else x) str 0
let ratio2 str =  (Convert.ToDouble(trippleCount str))/(Convert.ToDouble(String.length str))

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку ")
    let str1 = Console.ReadLine()
    Console.WriteLine("Выберите метод от 1 до 2")
    let a = Convert.ToInt32(Console.ReadLine())
    match a with
    |1->List.sortBy (fun x-> ratio x) (Array.toList(str1.Split " "))|>printfn"%A"
    |2->List.sortBy (fun x-> ratio2 x) (Array.toList(str1.Split " "))|>printfn"%A"
    |_->Console.WriteLine("Столько я не сделаю")
    0
*)