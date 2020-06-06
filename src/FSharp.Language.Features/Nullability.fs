module FSharp.Language.Features.Nullability

open System

let cannotCompareNull () =
    let x = 1
    //    x = null
    //    x = Nullable()
    x

let cannotAssignNull () =
    //    let (x:int) = null
    ()

let cannotOperateWithNull () =
    let x = null
    let y = 1
    //    x + y
    x

let canWorkWithNullables () =
    let x = Nullable<int>(1)
    let y = Nullable<int>(2)
    //    x + y
    x.Value + y.Value

let ``canWorkWithGenerics...`` () =
    let x = null
    x

let ``...butNotReally`` =
    let t = ``canWorkWithGenerics...`` ()
    //    t + 1
    ()
