using System;
using System.IO;
using System.Threading.Tasks;
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
    private readonly ILogger<ReportBugFunction> _logger;

    public ReportBugFunction(ILogger<ReportBugFunction> logger) {
        _logger = logger;
    }

    [FunctionName("ReportBugFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] HttpRequest req
    ) {
        return new OkResult();
    }
}