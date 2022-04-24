// Learn more about F# at http://fsharp.org

open System

type IPrint = interface
    abstract member Print: unit->unit
    end

[<AbstractClass>]
type Shape() = 
    abstract member square: unit->double

type Rectangle(w:double, h:double) =
    inherit Shape()
    let mutable width = w
    let mutable height = h
    override this.square() = width*height
    override this.ToString() = $"Прямоугольник. Ширина = {width}, высота = {height}"
    interface IPrint with 
        member this.Print():unit = printfn "%s" (this.ToString())

type Square(w: double) =
    inherit Rectangle(w, w)
    let mutable side = w
    override this.ToString() = $"Квадрат. Сторона = {side}"
    interface IPrint with 
        member this.Print():unit = printfn "%s" (this.ToString())

type Circle(r: double) =
    inherit Shape()
    let mutable radius = r;
    override this.square() = (pown radius 2)*Math.PI
    override this.ToString() = $"Круг. Радиус = {radius}"
    interface IPrint with 
        member this.Print():unit = printfn "%s" (this.ToString())

type UnionGeoShape = 
    |UnionRectangle of double*double
    |UnionSquare of double
    |UnionCircle of double

let UnionSquare(shape: UnionGeoShape) =
    match shape with
    |UnionRectangle(a, b)->a*b
    |UnionSquare(a)->a*a
    |UnionCircle(a)->(pown a 2)*Math.PI

[<EntryPoint>]
let main argv =
    let rect = Rectangle(5.,10.)
    (rect :> IPrint).Print()

    let squr = Square(10.)
    (squr :> IPrint).Print()

    let circ = Circle(10.)
    (circ :> IPrint).Print()

    let newShape = UnionCircle(10.)
    printfn "%A" (UnionSquare newShape)

    0
