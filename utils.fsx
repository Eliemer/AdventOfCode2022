let splitBy (cond: 'a -> bool) (source: 'a seq) : 'a seq seq =
    let mutable i = 0

    source
    |> Seq.groupBy (fun x ->
        if cond x then i <- i + 1
        i)
    |> Seq.map snd