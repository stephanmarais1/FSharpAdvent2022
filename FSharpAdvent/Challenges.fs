namespace FSharpAdvent

module Advent1 =

    type M = { Sum : double; Acc : list<double> }

    let calculateHighest (path) =
        System.IO.File.ReadLines path
        |> Seq.fold(fun prev ->
            function
            | "" ->
                let compareSum = prev.Acc |> List.sum
                match prev.Sum > compareSum  with 
                | true -> { Sum = prev.Sum; Acc = [] } 
                | false -> { Sum = compareSum; Acc = [] }
            
            | a -> { Sum = prev.Sum; Acc = (double a) :: prev.Acc }
        
        ) { Sum = 0.; Acc = [] }

module Advent2 =

    type Choice = | Rock | Paper | Scissors

    let choiceValue =
        function
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3

    let play (player1 : Choice, player2 : Choice) =
        let playResult2 =
            match player1, player2 with
            // draw
            | a, b when a = b -> 3
            // player 1 wins
            | Rock, Scissors | Scissors, Paper | Paper, Rock -> 0
            // player 2 wins
            | _ -> 6

        playResult2 + choiceValue player2

    let calculateScores (path) =
        System.IO.File.ReadLines path
        |> Seq.fold(fun acc line ->
            match line.Split (' ') with
            | [|p1; p2|] ->
                let player1Choice =
                    match p1 with
                    | "A" -> Rock
                    | "B" -> Paper
                    | "C" -> Scissors
                    | _ -> failwith $"Could not interpret {p1}"

                let player2Choice =
                    match p2 with
                    | "X" -> Rock
                    | "Y" -> Paper
                    | "Z" -> Scissors
                    | _ -> failwith $"Could not interpret {p1}"

                play (player1Choice, player2Choice) + acc
            
            | _ -> failwith $"Could not interpret line {line}"
        
        ) 0