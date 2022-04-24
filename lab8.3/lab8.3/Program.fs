open System
open FParsec

type Expr =
    |Num of float
    |Plus of Expr*Expr
    |Minus of Expr*Expr

let pstring_ws s = spaces >>. pstring s .>> spaces
let float_ws = spaces >>. pfloat .>> spaces

let parseExpression, implementation = createParserForwardedToRef<Expr, unit>()

let parsePlus = 
    tuple2 (parseExpression .>> pstring_ws "+") parseExpression |>> Plus
let parseMinus = 
    tuple2 (parseExpression .>> pstring_ws "-") parseExpression |>> Minus
let parseOp = 
    between (pstring_ws "(") (pstring_ws ")") (attempt parsePlus <|> parseMinus)
let parseNum = float_ws |>> Num

implementation := parseNum <|> parseOp

let rec EvalExpr(e:Expr):float =
    match e with
    | Num(num) -> num
    | Plus(a,b) ->
        let left =
            match a with
            | Num(num) -> num
            | _ -> EvalExpr(a)
        let right =
            match b with
                | Num(num) -> num
                | _ -> EvalExpr(b)
        let res1 = left + right
        printfn "%f + %f = %f" left right res1 
        res1
    | Minus(a,b) ->
        let left =
            match a with
            | Num(num) -> num
            | _ -> EvalExpr(a)
        let right =
            match b with
            | Num(num) -> num
            | _ -> EvalExpr(b)
        let res2 = left - right
        printfn "%f - %f = %f" left right res2 
        res2

[<EntryPoint>]
let main argv =
    let result = run parseExpression "(((3+4)+(1-2))+10)"
    printfn "%A" result
    match result with
    | Success(result, _, _) ->
        let eval1 = EvalExpr(result)
        printfn "Результат вычислений: %f" eval1
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg
    0
