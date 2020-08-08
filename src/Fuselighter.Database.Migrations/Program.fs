open CommandLine
open System.Data.SqlClient
open Fuselighter.Database.Migrations
open Fuselighter.Database.Migrations.Options
open SimpleMigrations
open SimpleMigrations.DatabaseProvider

let processParserErrors (result : NotParsed<obj>) =
    let error = Seq.head result.Errors
    
    match error.Tag with
    | ErrorType.MissingRequiredOptionError ->
        Exit Failure
    | ErrorType.HelpRequestedError
    | ErrorType.HelpVerbRequestedError
    | ErrorType.VersionRequestedError ->
        // Parser will have already written the options to console
        Exit Success
    | x ->
        sprintf "Received parser error %A" x
        |> Problem
        
let run connStr (fn : SimpleMigrator -> unit) =
    let assembly = typeof<Migration_1>.Assembly
    
    use connection = new SqlConnection(connStr)
    connection.Open()
    
    let provider = MssqlDatabaseProvider connection
    let migrator = SimpleMigrator(assembly, provider)
    provider.TableName <- "StagesVersionInfo"
    
    try 
        migrator.Load()
        fn migrator
    finally
        connection.Close()
    
    Exit Success
        
let parseAndRun args =
    let result = Parser.Default.ParseArguments<UpOptions, ToOptions, BaselineOptions> args
    let runResult =
        match result with
        | :? CommandLine.Parsed<obj> as opts ->
            match opts.Value with
            | :? UpOptions as up -> 
                run up.connectionString (fun migrator -> migrator.MigrateToLatest())
            | :? ToOptions as opts ->
                run opts.connectionString (fun migrator -> migrator.MigrateTo opts.value)
            | :? BaselineOptions as opts ->
                run opts.connectionString (fun migrator -> migrator.Baseline opts.value)
            | x ->
                failwithf "Unhandled parsed command options type '%s'" (x.GetType().FullName)
        | :? CommandLine.NotParsed<obj> as notParsed ->
            processParserErrors notParsed
        | x ->
            sprintf "Unhandled parse arguments result type '%s'" (x.GetType().FullName)
            |> Problem 
        
    match runResult with
    | Exit exitType ->
        exitType
    | ShowHelp exitType ->
        exitType
    | Problem message ->
        eprintfn "%s" message
        Failure 

[<EntryPoint>]
let main argv =
    match parseAndRun argv with
    | Success -> 0
    | Failure -> 1