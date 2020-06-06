module FSharp.Language.Features.ComplexTypes

module ProductTypes =
    type Person =
        { First: string
          Last: string }

    type Address =
        { Street: string
          City: string }

    type Account =
        { Client: Person
          Address: Address
          Manager: Person option }

    let accountCreation () =
        { Client =
              { First = "Sam"
                Last = "Roberts" }
          Address =
              { Street = "123 Example Lane"
                City = "Fantasy Island" }
          Manager = None }


module SumTypes =
    type ApiError =
        | BadRequest of string
        | Unauthorized
        | NotFound

    type ApiResult<'a> =
        | Result of 'a
        | Error of ApiError

    let successfulRequest () =
        let r = Result "Some result body"
        r

    let failedRequest (): ApiResult<string> =
        let f = BadRequest "Failed business rule" |> Error
        f

module ComplexTypes =
    open ProductTypes
    open SumTypes

    type AccountResult =
        { Result: ApiResult<Account> }

    let successfulAccountResult () =
        let a = accountCreation ()
        { Result = Result a }

    let failedAccountResult () =
        let e = Unauthorized
        { Result = Error e }
