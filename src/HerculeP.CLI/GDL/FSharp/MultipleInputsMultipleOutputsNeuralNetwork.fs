// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.FSharp.MultipleInputsMultipleOutputsNeuralNetwork

[<Literal>]
let title = "Multiple inputs, multiple outputs neural network"

let runExperiments() =

    printfn $"--- {title} ---"
    
    let weights =
        [|
          [| 0.1; 0.1; -0.3 |] // hurt ?
          [| 0.1; 0.2; 0.0 |] // win ?
          [| 0.0; 1.3; 0.1 |] // sad ?
        |]

    let w_sum a b =
        ((0.0), a, b) |||> Seq.fold2 (fun state a b -> state + (a * b))

    let vect_mat_mul vector matrix =
        matrix |> Array.map(w_sum vector)

    let neuralNetwork input weights =
        let prediction = vect_mat_mul input weights
        prediction
        
    // current dataset
    let toes = [| 8.5; 9.5; 9.9; 9.0 |]
    let wlrec = [| 0.65; 0.8; 0.8; 0.9 |]
    let nfans = [| 1.2; 1.3; 0.5; 1.0 |]

    let input = [| toes.[0]; wlrec.[0]; nfans.[0] |]
    
    let pred = neuralNetwork input weights

    printfn "Prediction %A" pred