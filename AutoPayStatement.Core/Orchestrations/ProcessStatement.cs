using AutoPayStatement.Core.Activities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;
using AutoPayStatement.Core.Model;

namespace AutoPayStatement.Core.Orchestrations;

public class ProcessStatement
{
    [Function(nameof(ProcessStatement))]
    public async Task RunOrchestrator([OrchestrationTrigger] TaskOrchestrationContext context)
    {
        var template = await context.CallActivityAsync<TemplateResult>(
                nameof(GeneratePdf),
                File.ReadAllText("template.html"));

        File.WriteAllBytes("generated-file.pdf", template.Content);
    }
}