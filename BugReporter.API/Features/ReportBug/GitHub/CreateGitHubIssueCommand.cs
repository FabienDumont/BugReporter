using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BugReporter.API.Features.ReportBug.GitHub; 

public class CreateGitHubIssueCommand {
    private readonly ILogger<CreateGitHubIssueCommand> _logger;

    public CreateGitHubIssueCommand(ILogger<CreateGitHubIssueCommand> logger) {
        _logger = logger;
    }
    
    public async Task<ReportedBug> Execute(NewBug newBug) {
        _logger.LogInformation("Creating GitHub issue.");
        
        // Create GitHub issue
        ReportedBug reportedBug = new ReportedBug("1", "Very bad bug", "The div on the home page is not centered.");
        
        _logger.LogInformation($"Successfully created GitHub issue {reportedBug.Id}.");

        return reportedBug;
    }
}