namespace Fuselighter.Database.Models

open System

type Post =
    { Id : int
      Slug : string
      Title : string 
      Categories : PostCategory seq
      Published : DateTimeOffset option
      Description : string
      MetaDescription : string
      HeaderImageUrl : string option
      MarkdownContent : string }
