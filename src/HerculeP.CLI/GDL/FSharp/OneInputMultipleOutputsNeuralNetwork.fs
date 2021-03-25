// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.FSharp.OneInputMultipleOutputsNeuralNetwork

[<Literal>]
let title = "One input, multiple outputs neural network"

let runExperiments() =

    printfn $"--- {title} ---"
    
    let weights = [| 0.3; 0.2; 0.9 |]
    
    let ele_mul number vector =
        vector |> Seq.map(fun el -> number * el)

    let neuralNetwork input weights =
        let prediction = ele_mul input weights
        prediction

    let wlrec = [| 0.65; 0.8; 0.9 |]

    let input = wlrec.[0]

    let pred = neuralNetwork input weights

    printfn "Prediction %A" pred