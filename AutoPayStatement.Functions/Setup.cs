using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using IronPdf;

namespace AutoPayStatement.Functions;

public static class Setup
{
    public static void RegisterAzureApplicationInsights(this IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        IronPdf.Logging.Logger.LoggingMode = IronPdf.Logging.Logger.LoggingModes.Console;
        Installation.SingleProcess = true;

        services.AddSingleton(_ =>
        {
            var renderer = new ChromePdfRenderer()
            {
                RenderingOptions = new ChromePdfRenderOptions
                {
                    CssMediaType = IronPdf.Rendering.PdfCssMediaType.Screen,
                    PrintHtmlBackgrounds = true,
                    EnableJavaScript = true,
                    GrayScale = false,
                    PaperOrientation = IronPdf.Rendering.PdfPaperOrientation.Portrait,
                    PaperSize = IronPdf.Rendering.PdfPaperSize.A4,
                    MarginTop = 10,
                    MarginBottom = 10,
                    MarginLeft = 25,
                    MarginRight = 25,
                    UseMarginsOnHeaderAndFooter = UseMargins.None,
                    Zoom = 100,
                    Timeout = 1200
                }
            };
            renderer.RenderingOptions.PaperFit.UseChromeDefaultRendering();

            return renderer;
        });
    }
}