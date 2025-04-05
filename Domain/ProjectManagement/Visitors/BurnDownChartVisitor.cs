using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Export;

namespace Domain.ProjectManagement.Visitors;

// Visitor pattern
public class BurnDownChartVisitor : Visitor
{
    private int _totalStoryPoints = 0;
    private readonly IExportMethod _exportMethod;
    
    public BurnDownChartVisitor(IExportMethod exportMethod)
    {
        this._exportMethod = exportMethod;
    }
    
    public int GetTotalStoryPoints()
    {
        return _totalStoryPoints;
    }
    
    public override void VisitBacklogItem(BacklogItem backlogItem)
    {
        _totalStoryPoints += backlogItem.StoryPoints;
    }

    public void Export(bool includeHeader, bool includeFooter)
    {
        this._exportMethod.Export($"Burndown chart story points: {_totalStoryPoints}", includeHeader, includeFooter);
    }
}