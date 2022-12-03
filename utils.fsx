let splitBy (cond: 'a -> bool) (source: 'a seq) : 'a seq seq =
    let mutable i = 0

    source
    |> Seq.groupBy (fun x ->
        if cond x then i <- i + 1
        i)
    |> Seq.map snd

let splitBy' (skipDelimiter: bool) (cond: 'a -> bool) (source: 'a seq) : 'a seq seq = 

    let inline flush (buffer: ResizeArray<'a>) =
        seq {
            if buffer.Count > 0 then
                yield Seq.readonly (buffer)
                buffer.Clear()
        }

    seq {
        let buffer = ResizeArray()

        for item in source do
            if skipDelimiter then
                if cond item then
                    yield! flush buffer
                    if not skipDelimiter then
                        buffer.Add item
                else
                    buffer.Add item
            else
                if cond item then
                    yield! flush buffer
                    buffer.Add item
                else
                    buffer.Add item

        yield! flush buffer
    }

let splitInHalf (xs: 'a[]) : 'a[] * 'a[] =
    let half = xs.Length / 2

    xs.[..half - 1], xs.[half..]