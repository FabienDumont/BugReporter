using System;
using System.IO;
using System.Threading.Tasks;
using BugReporter.API.Features.ReportBug;
using BugReporter.API.Features.ReportBug.GitHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static BugReporter.API.Startup;

namespace BugReporter.API.Functions;

public class ReportBugFunction {
    private readonly CreateGitHubIssueCommand _createGitHubIssueCommand;
    private readonly ILogger<ReportBugFunction> _logger;

    public ReportBugFunction(CreateGitHubIssueCommand createGitHubIssueCommand, ILogger<ReportBugFunction> logger) {
        _createGitHubIssueCommand = createGitHubIssueCommand;
        _logger = logger;
    }

    [FunctionName("ReportBugFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] HttpRequest req
    ) {
        NewBug newBug = new("Very bad bug", "The div on the home page is not centered.");

        ReportedBug reportedBug = await _createGitHubIssueCommand.Execute(newBug);
        
        return new OkObjectResult(reportedBug);
    }
}