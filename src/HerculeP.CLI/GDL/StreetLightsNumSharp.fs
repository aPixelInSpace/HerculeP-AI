// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.StreetLightsNumSharp

open NumSharp

[<Literal>]
let title = "Street lights using NumSharp"

let runExperiments() =

    printfn $"--- {title} ---"

    let streetlights =
        np.array(
            [|
                [| 1.0f; 0.0f; 1.0f; |]
                [| 0.0f; 1.0f; 1.0f; |]
                [| 0.0f; 0.0f; 1.0f; |]
                [| 1.0f; 1.0f; 1.0f; |]
                [| 0.0f; 1.0f; 1.0f; |]
                [| 1.0f; 0.0f; 1.0f; |]
            |])

    let walk_vs_stop = np.array([| 0.0f; 1.0f; 0.0f; 1.0f; 1.0f; 0.0f; |])

    let alpha = 0.1

    let input = streetlights.[0]
    let observation = walk_vs_stop.[0]

    let weights = np.array([| 0.5f; 0.48f; -0.7f |])
    for _ in 1 .. 20 do
        let pred = input.dot(&weights)
        let delta = pred - observation
        let error = np.exp2(&delta)
        weights.ReplaceData(weights - (alpha * (input * delta)))

        printfn "Error: %A; Prediction: %A; Weights: %A" error pred weights