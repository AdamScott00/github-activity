using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using github_activity;
using github_activity.Model;
using Microsoft.Extensions.DependencyInjection;

var builder = new ServiceCollection()
    .AddSingleton<GithubService>()
    .AddSingleton<EventManager>()
    .BuildServiceProvider();
    
var githubService = builder.GetRequiredService<GithubService>();
var eventManager = builder.GetRequiredService<EventManager>();

var rootCommand = new RootCommand("Github activity cli")
{
    new Argument<string>("username", "The Github username.")
};
rootCommand.Handler = CommandHandler.Create<string>(username =>
    {
        List<Event> result = githubService.GetActivityForUser(username).Result;
        var outputs = eventManager.GetEventOutputs(result);
        
        Console.WriteLine("Output:");
        foreach (var output in outputs)
        {
            Console.WriteLine(output);
        }
    }
);
await rootCommand.InvokeAsync(args);