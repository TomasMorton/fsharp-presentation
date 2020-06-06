module FSharp.Language.Features.Immutability

module ImmutableInt =
    let noIncrement () =
        let x = 1
        //        x <- x + 1
        x

    let noAssignment () =
        let x = 1
        let y = 2
        //        x <- y
        x + y

module MutableInt =
    let increment () =
        let mutable x = 1
        x <- x + 1
        x

module ImmutableList =
    let immutableReference () =
        let x = [ 1; 2; 3 ]
        //        x <- [4;5;6]
        x

    let immutableValue () =
        let x = [ 1; 2; 3 ]
        //        x.[0] <- 5
        //        x.Head <- 5
        x

module MutableArray =
    let immutableReference () =
        let x = [| 1; 2; 3 |]
        //        x <- [|4;5;6|]
        x

    let MUTABLE_VALUE () =
        let x = [| 1; 2; 3 |]
        x.[0] <- 5
        x

module ImmutableRecord =
    type Person =
        { First: string
          Last: string }

    let p =
        { First = "Chris"
          Last = "Jones" }

    let immutablePerson () =
        //        p <-
        //            { First = "Sam"
        //              Last = "Smith" }
        p

    let immutableName () =
        //        p.First <- "Nice try"
        p.First

    let newPerson () =
        let p2 = { p with First = "Kevin" }
        p2

module ImmutableChoice =
    type Temp =
        | DegreesC of float
        | DegreesF of float

    let t = DegreesC 28.1

    let immutableReference () =
        //        t <- DegreesF 90.6
        t
