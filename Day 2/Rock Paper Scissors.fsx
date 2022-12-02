open System
open System.IO

let inputStr = File.ReadAllLines "input.txt"

// Part 1
// X means rock
// Y means paper
// Z means scissors
let strategy = 
    function
    | "A X" -> 3 + 1 // draw
    | "A Y" -> 6 + 2 // win
    | "A Z" -> 0 + 3 // loss
    | "B X" -> 0 + 1 // loss
    | "B Y" -> 3 + 2 // draw
    | "B Z" -> 6 + 3 // win
    | "C X" -> 6 + 1 // win
    | "C Y" -> 0 + 2 // loss
    | "C Z" -> 3 + 3 // draw
    | _ -> failwith "Incorrect format"

inputStr
|> Array.sumBy strategy
|> printfn "%A"

// Part 2
// X means lose
// Y means draw
// Z means win
let strategy' =
    function
    | "A X" -> 0 + 3 // loss, Rock beats scissors
    | "A Y" -> 3 + 1 // draw, Rock draws with Rock
    | "A Z" -> 6 + 2 // win, Rock loses to Paper
    | "B X" -> 0 + 1 // Paper beats Rock
    | "B Y" -> 3 + 2 // Paper draws with Paper
    | "B Z" -> 6 + 3 // Paper loses to Scissors
    | "C X" -> 0 + 2 // Scissors beat Paper
    | "C Y" -> 3 + 3 // Scissors draws Scissors
    | "C Z" -> 6 + 1 // Scissors loses to Rock
    | _ -> failwith "Incorrect format"

inputStr
|> Array.sumBy strategy'
|> printfn "%A"
