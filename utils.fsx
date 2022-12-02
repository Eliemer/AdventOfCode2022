let splitBy (cond: 'a -> bool) (source: 'a seq) : 'a seq seq =
    let mutable i = 0

    source
    |> Seq.groupBy (fun x ->
        if cond x then i <- i + 1
        i)
    |> Seq.map snd

let splitBy' (cond: 'a -> bool) (source: 'a seq) : 'a seq seq = 

    let inline flush (buffer: ResizeArray<'a>) =
        seq {
            if buffer.Count > 0 then
                yield Seq.readonly (buffer)
                buffer.Clear()
        }

    seq {
        let buffer = ResizeArray()

        for item in source do
            if cond item then
                yield! flush buffer
            buffer.Add item

        yield! flush buffer
    }