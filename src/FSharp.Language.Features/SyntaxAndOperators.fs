module FSharp.Language.Features.SyntaxAndOperators

let returnValue () =
    3 + 5

let returnUnit () =
    printf "An impure function!"

let returnUnitAgain () =
    let _ = 3 + 5
    ()

let returnUnitAgainAgain () =
    ignore (3 + 5)

let assignment () =
    let mutable x = 1
    x <- 2

let equality () =
    let x = 1
    let y = 2
    x = y

let parameters x y =
    x + y

let explicitType (a: int) =
    a

let print () =
    let x = 1
    let b = true
    let s = "A string"
    sprintf "Printing %s %i %b" s x b

let matchValue (x: int) =
    match x with
    | 1 -> "1"
    | negative when x < 0 -> sprintf "Negative: %i" negative
    | _ -> "Something else"

let pipe f x =
    x |> f

let usefulPipe () =
    let isEven x = x % 2 = 0

    let list = [ 1 .. 10 ]
    list
    |> List.filter isEven
    |> List.map (sprintf "#%i (Even)")
