module FSharp.Language.Features.Composition

module NumberComposition =
    let addOne x = x + 1
    let addFive x = x + 5
    let addSix = addOne >> addFive

    let addSixTest () =
        addSix 5
        
module ComplexComposition =
    let intToString = sprintf "%i"
    let stringToCharacterList = List.ofSeq
    
    let intToCharacterList = intToString >> stringToCharacterList
    
    let intToCharListTest () =
        156 |> intToCharacterList