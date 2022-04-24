// Learn more about F# at http://fsharp.org

open System
open System.Text.RegularExpressions
open System.Diagnostics

//5
type Passport(firstname:string,
    surname:string,
    patronymic:string,
    birtday:DateTime,
    gender:string,
    pasport_series:int,
    pasport_number:int
    ) = 
    //8. Хотя по факту, рег выражениями является конструкция match
    let namesPattern = @"^[a-zA-Z]+$"
    let genderPattern = @"Male|Female$"
    let serPattern = @"^[0-9]{4}$"
    let numPattern = @"^[0-9]{6}$"
    do if not(Regex(namesPattern).IsMatch(firstname))then raise <| new System.ArgumentException("Неправильно введено имя")
       elif not(Regex(namesPattern).IsMatch(surname))then raise <| new System.ArgumentException("Неправильно введена фамилия")
       elif not(Regex(namesPattern).IsMatch(patronymic))then raise <| new System.ArgumentException("Неправильно введено отчество")
       elif not(Regex(genderPattern).IsMatch(gender)) then raise <| new System.ArgumentException("Гендера только 2.")
       elif not(Regex(serPattern).IsMatch(pasport_series.ToString())) then raise <| new System.ArgumentException("Неправильная серия")
       elif not(Regex(numPattern).IsMatch(pasport_number.ToString())) then raise <| new System.ArgumentException("Неправильный номер")
       else ()

    member this.name = firstname
    member this.surname = surname
    member this.patr = patronymic
    member this.birtday = birtday
    member this.g = gender
    member this.ser = pasport_series
    member this.num = pasport_number

    //7
    interface IEquatable<Passport> with
        member this.Equals other = other.id.Equals this.id
    interface IComparable with
        member this.CompareTo obj =
            match obj with
            | :? Passport as p -> if this.ser = p.ser then this.num.CompareTo p.num else this.ser.CompareTo p.ser
            | _ -> -1
    interface IComparable<Passport> with
        member this.CompareTo obj = obj.ser.CompareTo this.ser
    override this.Equals obj =
        match obj with
        | :? Passport as p -> (this :> IEquatable<_>).Equals p
        | _ -> false
    override this.GetHashCode () = this.id.GetHashCode()


    //6
    override this.ToString()=
            $"Name:\t\t {this.name} \n Surname:\t {this.surname} \n Patronymic:\t {this.patr} \n Date of Birth:\t {this.birtday} \n Gender:\t {this.g} \n Serial:\t {this.ser} \n Number:\t {this.num}\n\n " 

    member this.id = 0
    
[<AbstractClass>]
type AbstractDoc() =
    abstract member searchDoc:Passport->bool

type ArrayDoc(arr: Passport []) =
    inherit AbstractDoc()
    member this.arr = arr

    override this.searchDoc doc =
        Array.exists(fun x-> x.Equals doc) this.arr

type ListDoc(list: Passport list) =
    inherit AbstractDoc()
    member this.list = list

    override this.searchDoc doc =
        List.exists(fun x-> x.Equals doc) this.list

type SetDoc(set: Passport Set) =
    inherit AbstractDoc()
    member this.set = set

    override this.searchDoc doc =
        Set.contains doc this.set

type BTN<'T> =
    | Empty
    | Node of 'T*BTN<'T>*BTN<'T>

type BT(tree:BTN<Passport>)=
    inherit AbstractDoc()
    member this.t = tree
    
    static member exists doc tree =
        let rec search tree =
            match tree with
            | Node (head, left, right) when head = doc->true
            | Node (head, left, right) when head<doc -> search right
            | Node (head, left, right) when head>doc -> search left
            | Empty -> false
        search tree
    
    override this.searchDoc doc =
        BT.exists doc this.t
(*      
//randomizer
let alphabet = "abcdefghijklmnopqrstuvwxyz"

let gendersRand = ["Male"; "Female"]

let randomStr len (random:Random) = 
    let randomChars = [|for i in 0..len -> alphabet.[random.Next(alphabet.Length)]|]
    
    new System.String(randomChars)

let genRan (random: Random)=
    let name = randomStr 10 random
    let sname = randomStr 15 random
    let pat = randomStr 20 random
    let bd = DateTime.Parse("01.03.2123")
    let gend = "Male"//List.item (random.Next( gendersRand.Length ) gendersRand
    let ser = random.Next (1000, 9999)
    let num = random.Next (100000, 999999)
    
    Passport(name, sname, pat, bd, gend, ser, num)

*)

let Time (watch:Stopwatch) searchMethod collection =
    watch.Reset()
    let stpwatch = new Stopwatch()
    stpwatch.Start()
    let startTime = stpwatch.ElapsedTicks
    let isFound = searchMethod collection
    let endTime = stpwatch.ElapsedTicks
    stpwatch.Stop()
    printfn "%A" (startTime, endTime, endTime - startTime)

[<EntryPoint>]
let main argv =
    //5 6 7 8 9 10
    let Person1 = Passport("Mokshin", "Roman", "Ivanovich", DateTime.Parse("01.01.2002"), "Male", 1001, 123456)
    let Person2 = Passport("Lukashev", "Alexey", "Andreevich", DateTime.Parse("01.03.2004"),"Female", 1002, 456789)
    let Person3 = Passport("Dmitrov", "Dimas", "Dmitrievich", DateTime.Parse("01.03.2004"),"Male", 1004, 879254)
    Person1.ToString()|>printfn"%A"
    Person2.ToString()|>printfn"%A"
    Person1.Equals Person2|>printfn"%b"
    Console.WriteLine()

    let arr = ArrayDoc([|Person1; Person2; Person3|])
    let list = ListDoc([Person1; Person2; Person3])
    let tree : BTN<Passport> = (Node)(Person1, (Node)(Person2, Empty, Empty), Empty)
    let bt = BT(tree)
    let set = SetDoc(Set [Person1; Person2; Person3])

    let neededTime = new Stopwatch()
    Time neededTime arr.searchDoc Person1
    Time neededTime list.searchDoc Person1
    Time neededTime bt.searchDoc Person1
    Time neededTime set.searchDoc Person1

    0
 
