// Learn more about F# at http://fsharp.org

open System
open System.Text.RegularExpressions

//5
type Passport(
    firstname:string,
    surname:string,
    patronymic:string,
    birtday:DateTime,
    gender:string,
    pasport_series:int,
    pasport_number:int
    ) = class
    member this.name = firstname
    member this.surname = surname
    member this.patr = patronymic
    member this.birtday = birtday
    member this.g = gender
    member this.ser = pasport_series
    member this.num = pasport_number

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



    override this.ToString()=
            $"Name:\t\t {this.name} \n Surname:\t {this.surname} \n Patronymic:\t {this.patr} \n Date of Birth:\t {this.birtday} \n Gender:\t {this.g} \n Serial:\t {this.ser} \n Number:\t {this.num} " 

    member this.id = 0
    end

    

[<EntryPoint>]
let main argv =
    let person1 = Passport("Mokshin", "Roman", "Ivanovich", DateTime.Parse("01.01.2002"), "Male", 0001, 123456)
    let person2 = Passport("Lukashev", "Alexey", "Andreevich", DateTime.Parse("01.03.2004"),"Male", 0002, 456789)
    person1.ToString()|>printfn"%A"
    person2.ToString()|>printfn"%A"
    person1.Equals person2|>printfn"%b"
    0
