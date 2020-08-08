namespace Fuselighter.Server.Controllers

open System.Diagnostics
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Fuselighter.Server.Models

type HomeController (logger : ILogger<HomeController>, env: IWebHostEnvironment) =
    inherit Controller()

    member this.Index () =
        this.View()

    member this.Privacy () =
        this.View()

    member this.Error () =
        let activityId =
            if isNull Activity.Current then
                None
            else
                Option.ofString Activity.Current.Id 
        let model : ErrorViewModel =
            { RequestId = activityId
                          |> Option.defaultValue this.HttpContext.TraceIdentifier
              ShowRequestId = env.EnvironmentName = "Development" }
            
        this.View model 
