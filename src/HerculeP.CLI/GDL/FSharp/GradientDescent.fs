// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.FSharp.GradientDescent

[<Literal>]
let title = "Gradient descent"

let runExperiments() =

    printfn $"--- {title} ---"
    
    let mutable weight = 0.5
    
    let goal_pred = 0.8
    
    let input = 0.5
    
    for iteration in [1 .. 20] do
        let pred = input * weight
        
        let error = (pred - goal_pred) ** 2.0
        
        let direction_and_amount = (pred - goal_pred) * input
        
        weight <- weight - direction_and_amount
        
        if iteration % 4 = 0 then
            printfn "Error : %A Prediction : %A" error pred

    printfn "Found weight is %A" weight