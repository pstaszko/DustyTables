namespace DustyTables
[<AutoOpen>]
module Pipes =
    type DustyTablesPipes =
        static member RunCmd qry parameters fn =
            "data source=localhost;initial catalog=Builder;Integrated Security=True"
            |> Sql.connect
            |> Sql.parameters (parameters |> List.map (fun (x, y) -> x, (new Microsoft.Data.SqlClient.SqlParameter(x, y.ToString()))))
            |> Sql.query qry
            |> Sql.execute fn
