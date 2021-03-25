// https://github.com/dotnet/mbmlbook

module HerculeP.CLI.MBML.MurderMystery

open System
open Microsoft.ML.Probabilistic.Models

[<Literal>]
let title = "A murder mystery"

let runExperiments() =
    
    printfn $"--- {title} ---"
    
    let auburnMurderer = Variable.Bernoulli(0.7)
    
    let engine = InferenceEngine()
    
    
    ()