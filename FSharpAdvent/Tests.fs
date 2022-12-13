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

    [<Fact>]
    let ``Advent Day2`` () =

        let score = Advent2.calculateScores @"../../../Data2.txt" |> snd
        
        Assert.Equal(10595, score)
