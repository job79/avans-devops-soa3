using Domain.ProjectManagement.Export;

namespace DomainServices.ProjectManagement.Export;

public class ExportPdf : IExportMethod
{
    public void Export(string rapport)
    {
        Console.WriteLine($"[ExportPdf] Exporting to pdf: {rapport}");
    }
}