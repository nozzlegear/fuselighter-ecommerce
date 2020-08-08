namespace Fuselighter.Database.Models

type PartialPost =
    { Slug : string
      Title : string 
      Categories : PostCategoryId seq
      Published : bool 
      Description : string
      MetaDescription : string
      HeaderImageUrl : string option
      MarkdownContent : string }
