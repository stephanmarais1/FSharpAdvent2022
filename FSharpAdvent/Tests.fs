namespace FSharpAdvent

module Tests =

    open Xunit

    [<Fact>]
    let ``Advent Day1`` () =

        let highestCalories = 
            @"../../../Data1.txt"
            |> Advent1.calculateHighest
            |> fun x -> x.Sum
        
        Assert.Equal(72070., highestCalories)