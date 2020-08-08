namespace Fuselighter.Database.Models

type PostId = PostId of int
type PostCategoryId = PostCategoryId of int
type ProductId = ProductId of int
type ProductVariantId = ProductVariantId of int
type ProductCategoryId = ProductCategoryId of int
type InventoryPolicy =
    /// Deny further purchases when the product variant is out of stock.
    | Deny
    /// Allow further purchases when the product variant is out of stock and decrement it below zero.
    | Continue 
type WeightUnit =
    | Ounces of decimal
    | Grams of decimal
    | Kilograms of decimal
    | Pounds of decimal 

