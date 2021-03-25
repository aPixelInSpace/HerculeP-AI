// https://dotnet.github.io/infer/userguide/Two%20coins%20tutorial.html

module HerculeP.CLI.InferTutorial.TwoCoins

open Microsoft.ML.Probabilistic.Models
open Microsoft.ML.Probabilistic.Distributions
open Microsoft.ML.Probabilistic.FSharp

[<Literal>]
let title = "Two coins"

let runExperiments() =
    
    printfn $"--- {title} ---"
    
    let firstCoin = Variable.Bernoulli(0.5)
    let secondCoin = Variable.Bernoulli(0.5)
    
    let engine = InferenceEngine()
        
    // variable bothHeads is random, because it depends on two random variables
    let bothHeads = firstCoin &&& secondCoin
    
    // we would like to find out its distribution
    let bothHeadsPost = engine.Infer<Bernoulli>(bothHeads)    
    printfn "Both heads posterior %A" bothHeadsPost
    
    // backwards reasoning    
    // we observe the output to be a particular value and ask questions about the inputs
    bothHeads.ObservedValue <- false
    
    let firstCoinPost = engine.Infer<Bernoulli>(firstCoin)    
    printfn "First coin posterior %A" firstCoinPost