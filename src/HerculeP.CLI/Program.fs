// Copyright 2020-2021 Patrizio Amella. All rights reserved. See License file in the project root for more information.

// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open HerculeP.CLI

[<EntryPoint>]
let main argv =
    
    //InferTutorial.TwoCoins.runExperiments()
    
    GDL.FSharp.OneInputOneOutputNeuralNetwork.runExperiments()
    
    GDL.FSharp.MultipleInputsOneOutputNeuralNetwork.runExperiments()
    
    GDL.FSharp.OneInputMultipleOutputsNeuralNetwork.runExperiments()
    
    GDL.FSharp.MultipleInputsMultipleOutputsNeuralNetwork.runExperiments()
    
    GDL.FSharp.PredictionsAsInputsForNeuralNetwork.runExperiments()
    
    GDL.FSharp.PredictionsEvaluation.runExperiments()
    
    GDL.FSharp.HotAndColdLearning.runExperiments()
    
    GDL.FSharp.HotAndColdLearningIterations.runExperiments()
    
    GDL.FSharp.GradientDescent.runExperiments()
    
    0 // return an integer exit code