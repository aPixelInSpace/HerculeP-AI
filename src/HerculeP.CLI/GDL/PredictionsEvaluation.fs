// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.PredictionsEvaluation

[<Literal>]
let title = "Predictions evaluation"

let knob_weight = 0.5
let input = 0.5
let goal_pred = 0.8

let pred = input * knob_weight

let error = (pred - goal_pred) ** 2.0

let runExperiments() =

    printfn $"--- {title} ---"
    
    printfn "Prediction error %A" error