module FSharp.Language.Features.Equality

let stringEquality () =
    "test" = "test"

let optionEquality () =
    let a = Some true
    let b = Some true
    a = b

module ChoiceEquality =
    type Temp =
        | DegreesC of float
        | DegreesF of float

    let choiceEquality () =
        let a = DegreesC 21.1
        let b = DegreesC 21.1
        a = b

module RecordEquality =
    type Person =
        { First: string
          Last: string }

    let recordEquality () =
        let a =
            { First = "Chris"
              Last = "Jones" }
        let b =
            { First = "Chris"
              Last = "Jones" }
        a = b
        