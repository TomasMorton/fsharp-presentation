module FSharp.Language.Features.EnumSafety

type ErrorType =
    | Unknown
    | InvalidFields
    | MissingFields

let getErrorMessage errorType =
    match errorType with
    | Unknown -> "Unknown Error"
    | InvalidFields -> "Invalid Field"
    | MissingFields -> "Missing Field" //Comment this out - compilation failure for unhandled case
