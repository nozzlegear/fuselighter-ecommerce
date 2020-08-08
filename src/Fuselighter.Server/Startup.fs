namespace Fuselighter.Server

open Fuselighter.Database
open Fuselighter.Database.Models
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration
        
    member private x.GetStoreConfigurationOrDefault (database : IStoreConfigurationDatabase) : StoreConfiguration =
        database.GetAsync()
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> Option.defaultValue { StoreName = "Fuselighter eCommerce"
                                 StoreDomain = "https://localhost:5001" }

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddControllersWithViews().AddRazorRuntimeCompilation() |> ignore
        services.AddRazorPages() |> ignore
        
        // TODO: get the database connection string from config
        services.AddSingleton<DatabaseOptions>({ ConnectionString = "fake-connection-string" }) |> ignore
        services.AddTransient<IStoreConfigurationDatabase, StoreConfigurationDatabase>() |> ignore
        services.AddScoped<IPostDatabase, PostDatabase>() |> ignore
        services.AddScoped<IProductDatabase, ProductDatabase>() |> ignore 
        services.AddSingleton<StoreConfiguration>(fun a ->
            let configDatabase = a.GetRequiredService<IStoreConfigurationDatabase>()
            this.GetStoreConfigurationOrDefault configDatabase) |> ignore 

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseExceptionHandler("/Home/Error") |> ignore
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseStaticFiles() |> ignore

        app.UseRouting() |> ignore

        app.UseAuthorization() |> ignore

        app.UseEndpoints(fun endpoints ->
            endpoints.MapControllerRoute(
                name = "default",
                pattern = "{controller=Home}/{action=Index}/{id?}") |> ignore
            endpoints.MapRazorPages() |> ignore) |> ignore

    member val Configuration : IConfiguration = null with get, set
