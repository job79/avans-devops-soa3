namespace Domain.Workflows;

public class WorkflowResult
{
    public bool IsSuccessful { get; }
    public string? Error { get; }

    public WorkflowResult(bool isSuccessful, string? error = null)
    {
        this.IsSuccessful = isSuccessful;
        this.Error = error;
    }
}