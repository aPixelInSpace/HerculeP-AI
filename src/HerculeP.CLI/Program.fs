// Copyright 2020-2021 Patrizio Amella. All rights reserved. See License file in the project root for more information.

// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open HerculeP.CLI
open HerculeP.CLI.GDL.FSharp

[<EntryPoint>]
let main argv =

    //InferTutorial.TwoCoins.runExperiments()

    OneInputOneOutputNeuralNetwork.runExperiments()

    MultipleInputsOneOutputNeuralNetwork.runExperiments()

    OneInputMultipleOutputsNeuralNetwork.runExperiments()

    MultipleInputsMultipleOutputsNeuralNetwork.runExperiments()

    PredictionsAsInputsForNeuralNetwork.runExperiments()

    PredictionsEvaluation.runExperiments()

    HotAndColdLearning.runExperiments()

    HotAndColdLearningIterations.runExperiments()

    GradientDescent.runExperiments()

    GradientDescentOneInput.runExperiments()

    GradientDescentMultipleInputs.runExperiments()
    
    GradientDescentOneInputMultipleOutputs.runExperiments()

    GradientDescentMultipleInputsMultipleOutputs.runExperiments()

    0 // return an integer exit code