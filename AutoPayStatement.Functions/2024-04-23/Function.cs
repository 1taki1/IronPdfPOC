using AutoPayStatement.Core.Model;
using AutoPayStatement.Core.Orchestrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Client;

namespace AutoPayStatement.Functions._2024_04_23
{
    public class Function
    {
        [Function("Function")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [DurableClient] DurableTaskClient client,
            FunctionContext executionContext)
        {
            var correlationId = Guid.NewGuid().ToString();

            var response = await client.ScheduleNewOrchestrationInstanceAsync(nameof(ProcessStatement),
                DataWithCorrelationId<object>.Create(correlationId, new { }));

            var result = await client.WaitForInstanceCompletionAsync(response);

            return new OkResult();
        }
    }
}
