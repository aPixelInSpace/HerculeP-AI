// Copyright 2020-2021 Patrizio Amella. All rights reserved. See License file in the project root for more information.

module HerculeP.CLI.MBML.MurderMistery

open System
open Microsoft.ML.Probabilistic.Models

[<Literal>]
let title = "A murder mystery"

type MurdererProbs(grey, auburn) =
    member this.Grey : float = grey
    member this.Auburn : float = auburn

type ConditionalVariablesWeapon(revolverGivenGrey, daggerGivenGrey, revolverGivenAuburn, daggerGivenAuburn) =
    member this.RevolverGivenGrey = revolverGivenGrey
    member this.DaggerGivenGrey = daggerGivenGrey
    member this.RevolverGivenAuburn = revolverGivenAuburn
    member this.DaggerGivenAuburn = daggerGivenAuburn

type ConditionalVariablesHair(hairGivenGrey, hairGivenAuburn) =
    member this.HairGivenGrey = hairGivenGrey
    member this.HairGivenAuburn = hairGivenAuburn

type Variables(murdererMarginals, name, posteriors) =
    member this.MurdererMarginals = murdererMarginals
    member this.Name = name
    member this.Posteriors = posteriors

type PriorKnowledgeModel(engine, name, priors : MurdererProbs) =
    let mutable murderer = None
    let mutable posterior : MurdererProbs option = None
    member this.Engine = engine
    member this.Name = name
    member this.Priors = priors

    member this.ConstructModel() =
        murderer <- Some (Variable.Bernoulli(priors.Auburn).Named("murderer=Auburn"))
            
    member this.Variables() =
        Variables(this.Priors, this.Name, posterior)

    member this.DoInference() =
        this.ConstructModel()
        this.Variables()

let runExperiments() =
    let engine = InferenceEngine()
    engine.ShowFactorGraph <- false
    
    let priors = MurdererProbs(0.3, 0.7)
    
    let conditionalsWeapon = ConditionalVariablesWeapon(0.9, 0.1, 0.2, 0.8)
    let conditionalsHair = ConditionalVariablesHair(0.5, 0.05)
    
    printfn $"\n{title}\n"
    
    let priorKnowledgeModel = PriorKnowledgeModel(engine, title, priors)
    
    printfn "%A" priorKnowledgeModel
    
    let priorKnowledge = priorKnowledgeModel.DoInference()
    
    printfn "%A" priorKnowledge
    
    ()