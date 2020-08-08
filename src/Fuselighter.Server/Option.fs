module Option

// Converts a null, empty or whitespace string to an option
let ofString str =
    match System.String.IsNullOrWhiteSpace str with
    | true -> None
    | false -> Some str
     

