// This code is from the book "Grokking Deep Learning" (I just re-implemented it in F# instead of Python)
// See https://github.com/iamtrask/Grokking-Deep-Learning and https://www.manning.com/books/grokking-deep-learning?a_aid=grokkingdl&a_bid=32715258

module HerculeP.CLI.GDL.HotAndColdLearning

[<Literal>]
let title = "Hot and cold learning"

let runExperiments() =

    printfn $"--- {title} ---"
    
    let weight = 0.1
    
    let neural_network input weight =
        input * weight
        
    let number_of_toes = [| 8.5 |]
    
    let win_or_lose_binary = [| 1.0 |] // won !
    
    let input = number_of_toes.[0]
    
    let isWin = win_or_lose_binary.[0]
    
    let pred = neural_network input weight
    
    let error = (pred - isWin) ** 2.0
    
    printfn "Prediction error %A" error
    
    let lr = 0.01
    
    let p_up = neural_network input (weight + lr)
    
    let e_up = (p_up - isWin) ** 2.0
    
    printfn "Prediction error with up weight %A" e_up
    
    let p_dn = neural_network input (weight - lr)
    
    let e_dn = (p_dn - isWin) ** 2.0
    
    printfn "Prediction error with down weight %A" e_dn
    
    let best_weight =
        if e_up < error && e_up < e_dn then
            weight + lr
        elif e_dn < error then
            weight - lr
        else
            weight

    printfn "Best currently found weight is %A" best_weight