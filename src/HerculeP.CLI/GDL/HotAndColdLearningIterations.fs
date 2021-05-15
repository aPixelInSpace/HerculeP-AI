// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.HotAndColdLearningIterations

[<Literal>]
let title = "Hot and cold learning iterations"

let runExperiments() =

    printfn $"--- {title} ---"
    
    let mutable weight = 0.5
    
    let goal_prediction = 0.8
    
    let input = 0.5
    
    let step_amount = 0.001

    // finding the best weight given a starting weight, an input and a goal prediction
    // with a fixed step amount
        
    for iteration in [1 .. 1101] do
        
        let prediction = input * weight
        
        let error = (prediction - goal_prediction) ** 2.0
        
        if iteration % 20 = 0 then
            printfn "Error : %A Prediction : %A" error prediction
        
        let up_prediction = input * (weight + step_amount)
        let up_error = (up_prediction - goal_prediction) ** 2.0
        
        let down_prediction = input * (weight - step_amount)
        let down_error = (down_prediction - goal_prediction) ** 2.0
        
        if(up_error < down_error) then
            weight <- weight + step_amount

        if(down_error < up_error) then
            weight <- weight - step_amount
            
        if iteration % 20 = 0 then
            printfn "Best currently found weight is %A" weight

    printfn "Found weight is %A" weight