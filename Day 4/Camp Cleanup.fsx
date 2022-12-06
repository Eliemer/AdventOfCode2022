open System
open System.IO
open System.Text.RegularExpressions

let inputStr = File.ReadAllText "input.txt"

[<Literal>]
let pattern1 = @"([0-9]+)-([0-9]+),([0-9]+)-([0-9]+)"

type Sections =
    { Max: int
      Min: int }

    static member fullyEncompases (x: Sections) (y: Sections) =
        (x.Max >= y.Max && x.Min <= y.Min)
        || (y.Max >= x.Max && y.Min <= x.Min)

    static member partiallyEncompases (x: Sections) (y: Sections) =
        (y.Min <= x.Max && y.Min >= x.Min)
        || (x.Min <= y.Max && x.Min >= y.Min)

let matches = Regex.Matches(inputStr, pattern1)

// Part 1
let sectionPairs =
    matches
    |> Seq.map (fun (m: Match) ->
        let min1 = m.Groups.[1].Value |> Int32.Parse
        let max1 = m.Groups.[2].Value |> Int32.Parse
        let min2 = m.Groups.[3].Value |> Int32.Parse
        let max2 = m.Groups.[4].Value |> Int32.Parse

        { Min = min1; Max = max1 }, { Min = min2; Max = max2 })

sectionPairs
|> Seq.filter (fun (x, y) -> Sections.fullyEncompases x y)
|> Seq.length
|> printfn "Number of fully emcompased pairs: %d"

// Part 2
sectionPairs
|> Seq.filter (fun (x, y) -> Sections.partiallyEncompases x y)
|> Seq.length
|> printfn "Number of partially emcompased pairs: %d"
