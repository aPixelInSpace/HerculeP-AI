// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.FSharp.GradientDescentOneIteration

[<Literal>]
let title = "Gradient descent one iteration"

let runExperiments() =
    
    printfn $"--- {title} ---"
    
    let mutable weight = 0.1
    
    printfn $"Initial weight is {weight}"
    
    let alpha = 0.01
    
    let neural_network input weight =
        let prediction = input * weight
        
        prediction

    let numberOfToes = [| 8.5; |]
    let win_or_lose_binary = [| 1.0 |] // won

    let input = numberOfToes.[0]
    let goal_pred = win_or_lose_binary.[0]
    
    for _ in [1 .. 4] do

        let pred = neural_network input weight
        
        // mean squared error
        let error = (pred - goal_pred) ** 2.0
        
        //delta is a measurement of how much this node missed. The true prediction is 1.0, and the
        //network’s prediction was 0.85, so the network was too low by 0.15. Thus, delta is negative 0.15.
        let delta = pred - goal_pred
        
        //weight_delta is a measure of how much a weight caused the network to miss. You calculate
        //it by multiplying the weight’s output node delta by the weight’s input.
        let weight_delta = input * delta
        
        //You multiply weight_delta by a small number alpha before using it to update weight. This
        //lets you control how fast the network learns.
        weight <- weight - (weight_delta * alpha)
        
        printfn $"Error is {error}; Prediction is {pred}; New weight is {weight}"