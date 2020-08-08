namespace Fuselighter.Database.Models

type PartialProductVariant =
    { Price : decimal
      Taxable : bool
      Weight : WeightUnit
      InventoryQuantity : int
      InventoryPolicy : InventoryPolicy
      Barcode : string
      SKU : string
      ImageUrl : string }

