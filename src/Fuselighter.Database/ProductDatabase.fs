namespace Fuselighter.Database

open Fuselighter.Database.Models

type ProductDatabase(options : DatabaseOptions) =
    interface IProductDatabase with
        member x.CreateAsync partialProduct price =
            failwith "not implemented"
            
        member x.CreateCategory categoryName =
            failwith "not implemented"
            
        member x.GetAsync productId =
            failwith "not implemented"

        member x.UpdateAsync productId partialProduct =
            failwith "not implemented"
            
        member x.UpdateOptionsAsync productId options =
            failwith "not implemented"
    
        member x.UpdateCategoriesAsync productId productCategories =
            failwith "not implemented"
            
        member x.UpdateVariantAsync variantId partialVariant =
            failwith "not implemented"
            
        member x.TogglePublishAsync productId =
            failwith "not implemented"
            
        member x.DeleteAsync productId =
            failwith "not implemented"