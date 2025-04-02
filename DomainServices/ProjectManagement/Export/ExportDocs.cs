using Domain.ProjectManagement.Export;

namespace DomainServices.ProjectManagement.Export;

public class ExportDocs : IExportMethod
{
    public void Export(string rapport)
    {
        Console.WriteLine($"[ExportDocs] Exporting to docs: {rapport}");
    }
}