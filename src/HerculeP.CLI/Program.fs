// Copyright 2020-2021 Patrizio Amella. All rights reserved. See License file in the project root for more information.

// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open HerculeP.CLI

[<EntryPoint>]
let main argv =
    
    InferTutorial.TwoCoins.runExperiments()
    
    GDL.FSharp.FirstNeuralNetwork.runExperiments()
    
    0 // return an integer exit code