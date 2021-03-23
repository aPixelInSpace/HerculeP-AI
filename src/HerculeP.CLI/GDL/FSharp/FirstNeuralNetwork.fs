module HerculeP.CLI.GDL.FSharp.FirstNeuralNetwork

[<Literal>]
let title = "First neural network"

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
    
    ()