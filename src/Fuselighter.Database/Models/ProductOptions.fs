namespace Fuselighter.Database.Models

type ProductOption =
    { Key : string }

type ProductOptions =
    { Option1 : ProductOption option
      Option2 : ProductOption option
      Option3 : ProductOption option }
    
type ProductVariantOption =
    { Key : string
      Value : string }
    
type ProductVariantOptions =
    { Option1 : ProductVariantOption option
      Option2 : ProductVariantOption option
      Option3 : ProductVariantOption option }

