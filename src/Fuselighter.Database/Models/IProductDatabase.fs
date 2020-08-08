namespace Fuselighter.Database.Models

open System.Threading.Tasks

type IProductDatabase =
    abstract CreateAsync : PartialProduct -> decimal -> Task<Product>
    abstract CreateCategory : string -> Task<ProductCategory>
    abstract GetAsync : ProductId -> Task<Product option>
    // TODO: need some kind of method to set the product option values all at once
    // this would wipe out all existing options (actually just archive them) and create an
    // all new set of variants for the options that have changed.
    // Probably requires a map of some kind so we can track which options get deleted and which
    // do not get deleted.
    abstract UpdateAsync : ProductId -> PartialProduct -> Task<Product>
    abstract UpdateOptionsAsync : ProductId -> ProductOptions -> Task<Product>
    abstract UpdateCategoriesAsync : ProductId -> ProductCategoryId seq -> Task<Product>
    abstract UpdateVariantAsync : ProductVariantId -> PartialProductVariant -> Task<ProductVariant>
    abstract TogglePublishAsync : ProductId -> Task<Product> 
    abstract DeleteAsync : ProductId -> Task

