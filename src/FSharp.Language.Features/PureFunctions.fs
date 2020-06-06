module FSharp.Language.Features.PureFunctions

module PureNumbers =
    let add x y = x + y
    let multiply x y = x * y
    let square x = multiply x x

    let addThree = add 3
    let multiplyByTwo = multiply 2

    let test100 () =
        2
        |> addThree
        |> multiplyByTwo
        |> square

    let test39 () =
        3
        |> square
        |> multiplyByTwo
        |> multiplyByTwo
        |> addThree

module PureRecords =
    open FSharp.Language.Features.ComplexTypes.ProductTypes

    let withManager m (a: Account) =
        { a with Manager = m }

    let withAddress address (a: Account) =
        { a with Address = address }

    let withClientFirstName n (a: Account) =
        { a with Client = { a.Client with First = n } }

    let account = accountCreation ()

    let testPurity () =
        let newManager =
            { First = "John"
              Last = "Manager" }
        let newAddress =
            { Street = "456 Windy Lane"
              City = "Wellington" }

        //Does the order I create these in matter?
        let accountWithNewManager =
            account |> withManager (Some newManager)

        let accountWithNewAddress =
            account |> withAddress newAddress

        let accountWithNewManagerAndAddress =
            account
            |> withAddress newAddress
            |> withManager (Some newManager)

        printfn "accountWithNewManager: %A" accountWithNewManager
        printfn "accountWithNewAddress: %A" accountWithNewAddress
        printfn "accountWithNewManagerAndAddress: %A" accountWithNewManagerAndAddress
