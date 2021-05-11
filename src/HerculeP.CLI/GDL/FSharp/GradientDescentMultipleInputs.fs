// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.FSharp.GradientDescentMultipleInputs

open System

[<Literal>]
let title = "Gradient descent multiple inputs"

let runExperiments() =
    
    printfn $"--- {title} ---"
    
    let w_sum a b =
        (0.0, a, b) |||> Seq.fold2 (fun state a b -> state + (a * b))

    let weights = [| 0.1; 0.2; -0.1 |]
    let weightsString weights =
        (String.Empty, weights) ||> Seq.fold(fun s w -> s + w.ToString() + "; ")

    printfn $"Weights are {weightsString weights}"

    let neural_network input weights =
        w_sum input weights

    let toes = [ 8.5; 9.5; 9.9; 9.0 ]
    let wlrec = [ 0.65; 0.8; 0.8; 0.9 ]
    let nfans = [ 1.2; 1.3; 0.5; 1.0 ]

    let inputs = [ toes.[0]; wlrec.[0]; nfans.[0] ]

    let win_or_lose_binary = [ 1.0; 1.0; 0.0; 1.0 ]
    let observation = win_or_lose_binary.[0]

    let ele_mul n vector =
        vector |> Seq.map(fun e -> e * n)
    
    for _ in [1 .. 3] do

        let pred = neural_network inputs weights

        let error = (pred - observation) ** 2.0

        let delta = pred - observation

        let weight_deltas = ele_mul delta inputs |> Seq.toArray

        printfn $"Weights deltas are {weightsString weight_deltas}"

        //weight_deltas.[0] <- 0.0

        let alpha = 0.01
        
        for i in [0 .. (weights |> Array.length) - 1 ]  do
            weights.[i] <- weights.[i] - alpha * weight_deltas.[i]

        printfn $"Error is {error}; Prediction is {pred}; New weights are {weightsString weights}"