// Learn more about F# at http://fsharp.org

open System
open System.Text.RegularExpressions

//5
type Passport(
    firstname:string,
    surname:string,
    patronymic:string,
    birtday:DateTime
    //pasport_series:int,
    //pasport_number:int
    ) = class
    member this.name = firstname
    member this.surname = surname
    member this.patr = patronymic
    member this.birtday = birtday
    
    override this.ToString()=
            $"Name:\t\t {this.name} \n Surname:\t {this.surname} \n Patronymic:\t {this.patr} \n Date of Birth:\t {this.birtday} \n" 
    end

[<EntryPoint>]
let main argv =
    let person1 = Passport("Mokshin", "Roman", "Ivanovich", DateTime.Parse("01.01.2002"))//, 0001, 123456)
    let person2 = Passport("Lukashev", "Alexey", "Andreevich", DateTime.Parse("01.03.2004"))//, 0002, 456789)
    person1.ToString()|>printfn"%A"
    person2.ToString()|>printfn"%A"
    0
