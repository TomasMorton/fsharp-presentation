module FSharp.Language.Features.MatchExpressions

let matchBool b =
    match b with
    | true -> 1
    | false -> 0
//  | _ -> raise (System.Exception "JavaScript?")

let matchInt x =
    match x with
    | 0 -> "Zero"
    | 1 -> "One"
    | number when number > 1 -> "Large"
    | number when number < 0 -> "Negative"
    | number -> sprintf "ERROR: Number %i doesn't exist!" number

let matchList () =
    let list = [ 1; 2; 3 ]
    match list with
    | 1 :: tail -> sprintf "%A" tail
    | x :: tail -> sprintf "%A - %A" x tail
    | [] -> "Empty list!"

module MatchChoice =
    type Choice =
        | B of bool
        | I of int
        | S of string

    let matchChoice () =
        let choice = S "Hi!"
        match choice with
        | B b -> sprintf "Boolean %b" b
        | I i -> sprintf "Integer %i" i
        | S s -> sprintf "String %s" s

module MatchRecord =
    type Person =
        { First: string
          Last: string }

    let matchRecord =
        let person =
            { First = "Bob"
              Last = "Smith" }

        match person with
        | { First = "Chris"; Last = l } -> sprintf "Hi, Chris %s" l
        | { First = "Bob" } -> "No, Bob."
        | _ -> "Who are you?"
