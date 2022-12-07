open System.IO

let inputStr = File.ReadLines "input.txt"

let MARKER_SIZE = 4

// Part 1
inputStr
|> Seq.exactlyOne
|> Seq.windowed MARKER_SIZE
|> Seq.findIndex (fun arr -> arr.Length = (Array.distinct arr).Length)
|> (+) MARKER_SIZE
|> printfn "Num of chars until start-of-packet Marker was detected: %d"

let MARKER_SIZE' = 14

// Part 2
inputStr
|> Seq.exactlyOne
|> Seq.windowed MARKER_SIZE'
|> Seq.findIndex (fun arr -> arr.Length = (Array.distinct arr).Length)
|> (+) MARKER_SIZE'
|> printfn "Num of chars until start-of-message Marker was detected: %d"
