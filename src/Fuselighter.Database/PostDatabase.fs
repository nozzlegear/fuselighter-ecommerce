namespace Fuselighter.Database

open System
open System.Threading.Tasks
open Fuselighter.Database.Models
open FSharp.Control.Tasks.V2.ContextInsensitive

type PostDatabase(options : DatabaseOptions) =
    interface IPostDatabase with
        member x.ListAsync () =
            failwith "not implemented"
            
        member x.GetAsync postId =
            failwith "not implemented"
            
        member x.CreateAsync partialPost =
            failwith "not implemented"
            
        member x.UpdateAsync postId publishDate partialPost =
            failwith "not implemented"
            
        member x.DeleteAsync postId =
            failwith "not implemented"
