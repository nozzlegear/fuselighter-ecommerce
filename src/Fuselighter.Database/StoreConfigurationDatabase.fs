namespace Fuselighter.Database

open System.Threading.Tasks
open Fuselighter.Database.Models
open FSharp.Control.Tasks.V2.ContextInsensitive

type StoreConfigurationDatabase(options : DatabaseOptions) =
    interface IStoreConfigurationDatabase with
        member x.GetAsync () =
            Task.FromResult None 
            
        member x.ConfigureAsync config =
            failwith "not implemented"
            