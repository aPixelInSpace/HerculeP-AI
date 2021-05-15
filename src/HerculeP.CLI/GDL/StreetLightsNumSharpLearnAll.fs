// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.StreetLightsNumSharpLearnAll

open NumSharp

[<Literal>]
let title = "Street lights using NumSharp learning from all observations"

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

    let weights = np.array([| 0.5f; 0.48f; -0.7f; |])
    for _ in 1 .. 40 do
        let mutable error_for_all_lights = 0.0

        for i in 0 .. walk_vs_stop.shape.[0] - 1 do
            let input = streetlights.[i]
            let observation = walk_vs_stop.[i]

            let pred = input.dot(&weights)
            
            let deltaError = observation - pred
            let error = np.exp2(&deltaError)
            
            error_for_all_lights <- error_for_all_lights + error.GetDouble()
            
            let delta = pred - observation
            
            weights.ReplaceData(weights - (alpha * (input * delta)))
            
            printfn $"Prediction: {pred}"
        
        printfn $"Error: {error_for_all_lights}"