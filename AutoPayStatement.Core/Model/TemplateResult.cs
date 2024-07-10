namespace AutoPayStatement.Core.Model;

public class TemplateResult
{
    public required byte[] Content { get; set; }
    public TemplateType Type { get; set; }
}

public enum TemplateType
{
    Html,
    Pdf,
}