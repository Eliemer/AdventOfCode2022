#load "../utils.fsx"

open System
open System.IO
open Utils

let prioritize =
    function
    | c when c >= 'a' && c <= 'z' -> int c - int 'a' + 1
    | c when c >= 'A' && c <= 'Z' -> int c - int 'A' + 27
    | _ -> failwith "what??"

let inputStr = File.ReadAllLines "input.txt"

// Part 1
inputStr
|> Array.sumBy (fun row ->
    let left, right = splitInHalf <| row.ToCharArray()

    Set.intersect (set left) (set right)
    |> Set.toList
    |> List.head
    |> prioritize)
|> printfn "Sum of priorities: %d"

// Part 2
inputStr
|> Array.chunkBySize 3
|> Array.sumBy (
    Array.map set
    >> Set.intersectMany
    >> Set.toList
    >> List.head
    >> prioritize
)
|> printfn "Sum of Badge priorities: %d"
