#load "../utils.fsx"

open System
open System.IO
open Utils

let inputString = File.ReadLines "input.txt"

let totalCaloriesPerInventory =
    inputString
    |> splitBy String.IsNullOrWhiteSpace // split by empty lines
    |> Seq.map 
        (Seq.tail // discard empty lines
        >> (Seq.map Int32.Parse) // parse int values
        >> Seq.sum) // sum calories

// Part 1
totalCaloriesPerInventory
|> Seq.max
|> printfn "Max calories: %d"

// Part 2
totalCaloriesPerInventory
|> Seq.sortDescending
|> Seq.take 3
|> Seq.sum
|> printfn "Total calories of top 3 elves: %d"