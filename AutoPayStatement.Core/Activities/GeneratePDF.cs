using AutoPayStatement.Core.Model;
using Microsoft.Azure.Functions.Worker;

namespace AutoPayStatement.Core.Activities;

public class GeneratePdf(ChromePdfRenderer renderer)
{
    [Function(nameof(GeneratePdf))]
    public async Task<TemplateResult> ExecuteAsync([ActivityTrigger] string templateContent)
    {
        var pdfFromHtmlFile = await renderer.RenderHtmlAsPdfAsync(templateContent);

        return new TemplateResult
        {
            Content = pdfFromHtmlFile.Stream.ToArray(),
            Type = TemplateType.Pdf,
        };
    }
}
