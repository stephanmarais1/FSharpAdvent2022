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