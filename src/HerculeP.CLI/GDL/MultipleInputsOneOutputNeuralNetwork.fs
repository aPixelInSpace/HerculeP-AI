// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.MultipleInputsOneOutputNeuralNetwork

open NumSharp

[<Literal>]
let title = "Multiple inputs, one output neural network"

let runExperiments() =
    
    printfn $"--- {title} ---"
    
    let weights = [| 0.1f; 0.2f; 0.0f |]
    
    let w_sum a b =
        ((0.0f), a, b) |||> Seq.fold2 (fun state a b -> state + (a * b))
    
    let neuralNetwork input weights =
        let prediction = w_sum input weights
        prediction
    
    let numberOfToes = [| 8.5f; 9.5f; 9.9f; 9.0f |]
    let wlrec = [| 0.65f; 0.8f; 0.8f; 0.9f |]
    let nfans = [| 1.2f; 1.3f; 0.5f; 1.0f |]
    
    let input = [| numberOfToes.[0]; wlrec.[0]; nfans.[0]; |]
    
    let pred = neuralNetwork input weights
    
    printfn "Prediction (F#) %A" pred
    
    let np_weights = np.array(weights)
    
    let np_numberOfToes = np.array(numberOfToes)
    let np_wlrec = np.array(wlrec)
    let np_nfans = np.array(nfans)
    
    let np_input = np.array([| numberOfToes.[0]; wlrec.[0]; nfans.[0] |])
    
    let np_pred = np_input.dot(&np_weights) // same as the w_sum defined earlier
    
    printfn "Prediction (NumSharp) %A" (np_pred.GetValue(0))