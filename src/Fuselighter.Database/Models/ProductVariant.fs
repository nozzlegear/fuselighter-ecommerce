namespace Fuselighter.Database.Models

open System

/// A ProductVariant represents one combination of product options, e.g. "Blue Shirt" or "Green / Small Shirt".
/// They have their own individual prices, weights and images. When a customer purchases a product, what they're
/// actually purchasing is one of the product's variants. 
type ProductVariant =
    { Id : int
      ProductId : int
      Price : decimal
      Taxable : bool
      Updated : DateTimeOffset option 
      Weight : WeightUnit
      InventoryQuantity : int
      InventoryPolicy : InventoryPolicy
      Position : int
      Barcode : string
      SKU : string
      ImageUrl : string
      Deleted : DateTimeOffset option
      Options : ProductVariantOptions }
