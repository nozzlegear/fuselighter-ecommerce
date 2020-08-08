namespace Fuselighter.Database.Migrations

open SimpleMigrations

[<Migration(1L, "Create initial tables")>]
type Migration_1() =
    inherit Migration() with 
        override x.Up() =
            failwith "not implemented"
            
        override x.Down() =
            failwith "not implemented"
