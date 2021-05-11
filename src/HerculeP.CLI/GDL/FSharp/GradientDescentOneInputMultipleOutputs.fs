// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.FSharp.GradientDescentOneInputMultipleOutputs

open System

[<Literal>]
let title = "Gradient descent one input multiple outputs"

let runExperiments() =

    printfn $"--- {title} ---"

    let ele_mul n vector =
        vector |> Seq.map(fun e -> e * n)

    let weights = [| 0.3; 0.2; 0.9 |]

    let neural_network input weights =
        let pred = ele_mul input weights

        pred

    let wlrec = [ 0.65; 1.0; 1.0; 0.9 ]

    let hurt = [ 0.1; 0.0; 0.0; 0.1 ]
    let win = [ 1.0; 1.0; 0.0; 1.0 ]
    let sad = [ 0.1; 0.0; 0.1; 0.2 ]

    let input = wlrec.[0]
    let observations = [ hurt.[0]; win.[0]; sad.[0] ]

    for _ in [1 .. 40] do

        let pred = neural_network input weights

        let deltas =
            (pred, observations)
            ||> Seq.map2(fun p o -> p - o)

        let errors = deltas |> Seq.map(fun d -> d ** 2.0)

        let weight_deltas = ele_mul input deltas |> Seq.toArray
        let derivative = weight_deltas

        let alpha = 0.1

        // update the weights
        Array.blit
            (weights |> Array.mapi(fun i w -> w - weight_deltas.[i] * alpha)) 0
            weights 0
            weights.Length

        let vString v =
            (String.Empty, v) ||> Seq.fold(fun s w -> s + w.ToString() + "; ")

        printfn $"Error is {vString errors}; Prediction is {vString pred}; New weight is {vString weights}"