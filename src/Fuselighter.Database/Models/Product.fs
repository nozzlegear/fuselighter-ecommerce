namespace Fuselighter.Database.Models

open System

type Product =
    { Id : int
      Published : DateTimeOffset option
      Deleted : DateTimeOffset option
      Updated : DateTimeOffset
      Categories : ProductCategory seq
      Variants : ProductVariant seq
      Title : string
      Options : ProductOptions
      Content : string
      MetaDescription : string
      Slug : string }
