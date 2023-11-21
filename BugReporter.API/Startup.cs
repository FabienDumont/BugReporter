using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(BugReporter.API.Startup))]

namespace BugReporter.API; 

public class Startup : FunctionsStartup {
    public override void Configure(IFunctionsHostBuilder builder) {
    }
}