// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.FSharp.OneInputOneOutputNeuralNetwork

[<Literal>]
let title = "One input, one output neural network"

let runExperiments() =
    
    printfn $"--- {title} ---"
    
    let weight = 0.1
    
    let neuralNetwork input weight =
        let prediction = input * weight
        prediction
    
    let numberOfToes = [| 8.5; 9.5; 10.0; 9.0 |]
    
    let input = numberOfToes.[0]
    
    let pred = neuralNetwork input weight
    
    printfn "Prediction %A" pred