module FSharp.Language.Features.ErrorResults

type Entity =
    { Id: string
      Name: string }

type ValidationError =
    | InvalidId
    | InvalidName
    | NameInUse of string

type ValidationResult = Result<Entity, ValidationError>

let validEntity () =
    Result.Ok
        { Id = "id"
          Name = "Valid Entity" }

let invalidId () =
    Result.Error InvalidId

let invalidName () =
    Result.Error InvalidName

let nameInUse () =
    NameInUse "The name is already used by the entity with ID 123"
    |> Result.Error

let consumeResult r =
    match r with
    | Result.Ok entity -> printfn "%A" entity
    | Result.Error err -> printfn "%A" err


let success () =
    validEntity () |> consumeResult

let idFailure () =
    invalidId () |> consumeResult

let nameUsedFailure () =
    nameInUse () |> consumeResult
