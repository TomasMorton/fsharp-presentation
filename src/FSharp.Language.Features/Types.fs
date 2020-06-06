module FSharp.Language.Features.Types

let bool () =
    true

let int () =
    1

let float () =
    3.14

let string () =
    "Some string"

let listFixed () =
    [ 1; 3; 5 ]

let listRange () =
    [ 1 .. 5 ]

let listRangeGenerator () =
    [ 1 .. 2 .. 5 ]

let unit () =
    ()

let option () =
    let isEven x = x % 2 = 0

    let y = 3
    if isEven y then Some y else None

let tuple () =
    1, 4

module Record =
    type Person =
        { First: string
          Last: string }

    let person1 () =
        { First = "john"
          Last = "Doe" }

module Union =
    type Temp =
        | DegreesC of float
        | DegreesF of float

    let temp () = DegreesC 28.1
