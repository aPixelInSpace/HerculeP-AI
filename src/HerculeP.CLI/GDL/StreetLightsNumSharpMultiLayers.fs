// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.StreetLightsNumSharpMultiLayers

open System
open NumSharp

[<Literal>]
let title = "Street lights using NumSharp multi-layers neural network"

let runExperiments() =

    printfn $"--- {title} ---"
    
    np.random.seed(1)
    
    let alpha = 0.2
    
    let hidden_size = 4
    
    let streetlights =
        np.array(
            [|
                [| 1.0f; 0.0f; 1.0f; |]
                [| 0.0f; 1.0f; 1.0f; |]
                [| 0.0f; 0.0f; 1.0f; |]
                [| 1.0f; 1.0f; 1.0f; |]
            |])

    let walk_vs_stop = np.array([| [| 1.0f; 1.0f; 0.0f; 0.0f; |] |]).T

    let weights_0_1 = 2.0f * np.random.rand(3, hidden_size) - 1.0f
    
    let weights_1_2 = 2.0f * np.random.rand(hidden_size, 1) - 1.0f
    
    let relu x =
        Math.Max(0.0f, x)
    
    for iteration in 1 .. 60 do
        
        let mutable layer_2_error = 0.0
        
        for i in 0 .. streetlights.Shape.[0] do

            let layer_0 = streetlights.["i:i+1"]

            let layer_1 = np.dot(&layer_0, &weights_0_1)
            let zero = NDArray([| 0 |])
            let layer_1 = np.maximum(&layer_1, &zero)

            let layer_2 = np.dot(&layer_1, &weights_1_2)
            
            let walk_vs_stop_slice = walk_vs_stop.["i:i+1"]
            let sub = np.subtract(&layer_2, &walk_vs_stop_slice)
            let error = np.exp2(&sub)
            let sum = np.sum(&error)
            layer_2_error <- layer_2_error + sum.GetDouble()
            
            let layer_2_delta = walk_vs_stop_slice - layer_2
            
            let weights_1_2_T = weights_1_2.T
            let layer_1_delta = layer_2_delta.dot(&weights_1_2_T)
            let layer_1_delta_relu = layer_1_delta.copy()
            //layer_1_delta_relu.[h < 0] <- zero
            
            ()

        if iteration % 10 = 9 then printfn $"Error : {layer_2_error}"

    ()