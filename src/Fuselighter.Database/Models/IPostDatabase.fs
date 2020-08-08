namespace Fuselighter.Database.Models

open System
open System.Threading.Tasks

type IPostDatabase =
    abstract ListAsync : unit -> Task<Post seq>
    abstract GetAsync : PostId -> Task<Post option>
    abstract CreateAsync : PartialPost -> Task<Post> 
    abstract UpdateAsync : PostId -> DateTimeOffset option -> PartialPost -> Task<Post>
    abstract DeleteAsync : PostId -> Task 
