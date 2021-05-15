// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.GradientDescentMultipleInputsMultipleOutputs

open System

[<Literal>]
let title = "Gradient descent multiple inputs multiple outputs"

let runExperiments() =

    printfn $"--- {title} ---"

    let weights =
        [| 
            [| 0.1; 0.1; -0.3 |];
            [| 0.1; 0.2; 0.0 |];
            [| 0.0; 1.3; 0.1 |]
        |]

    let w_sum a b =
        (0.0, a, b) |||> Seq.fold2 (fun state a b -> state + (a * b))

    let vect_mat_mul vector matrix =
        matrix |> Seq.map(w_sum vector)

    let neural_network input weights =
        let pred = vect_mat_mul input weights
        pred

    let toes = [ 8.5; 9.5; 9.9; 9.0 ]
    let wlrec = [ 0.65; 0.8; 0.8; 0.9 ]
    let nfans = [ 1.2; 1.3; 0.5; 1.0 ]

    let hurt = [ 0.1; 0.0; 0.0; 0.1 ]
    let win = [ 1.0; 1.0; 0.0; 1.0 ]
    let sad = [ 0.1; 0.0; 0.1; 0.2 ]

    let alpha = 0.01

    let input = [ toes.[0]; wlrec.[0]; nfans.[0] ]
    let observations = [ hurt.[0]; win.[0]; sad.[0] ]

    let pred = neural_network input weights

    let deltas =
        (pred, observations)
        ||> Seq.map2(fun p o -> p - o)

    let errors = deltas |> Seq.map(fun d -> d ** 2.0)

    let ele_mul n vector =
        vector
        |> Seq.map(fun e -> e * n)
        |> Seq.toArray

    let outer_prod vect_a vect_b =
        vect_a
        |> Seq.map(fun e -> ele_mul e vect_b)
        |> Seq.toArray

    let weight_deltas = outer_prod input deltas
    
    let weightsForOneLine weights weight_deltas =
        (weights, weight_deltas)
        ||> Array.map2(fun w d -> w - (alpha * d))

    Array.blit
        ((weights, weight_deltas) ||> Array.map2(weightsForOneLine)) 0
        weights 0
        weights.Length

    let vString v =
        (String.Empty, v) ||> Seq.fold(fun s w -> s + w.ToString() + "; ")
    let mString m =
        (String.Empty, m) ||> Seq.fold(fun s v -> s + (vString v) + "\n")

    printfn $"Error is {vString errors}; Prediction is {vString pred}; New weight is {mString weights}"