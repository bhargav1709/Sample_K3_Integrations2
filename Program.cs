using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Http;

namespace Sample_K3_Integrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // Fix: Ensure WebApplication is used correctly
            var app = builder.Build();

            // Configure the app to listen on port 8080 inside the container
            app.Urls.Add("http://*:8080");

            // Root endpoint
            app.MapGet("/", () => Results.Content(
                "<h1>Deployment Successful!</h1><p>Cloud-Native Pipeline is working via C# .NET and K3s.</p>",
                "text/html"
            ));

            // Health check endpoint for Kubernetes uptime monitoring
            app.MapGet("/health", () => Results.Ok("OK"));

            app.Run();
        }
    }
}