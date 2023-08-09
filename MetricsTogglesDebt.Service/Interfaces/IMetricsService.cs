using MetricsTogglesDebt.Data.Entities;

namespace MetricsTogglesDebt.Service.Interfaces
{
    public interface IMetricsService
    {
        List<LinesOfCode> GetAllLinesOfCodes();

        int SaveLinesOfCode(LinesOfCode model);

        int UpdateLinesOfCode(LinesOfCode model);

        int SaveClassesAndMethods(ClassesAndMethods model);

        int SaveCommit(Commit model);

        int SaveTags(Tags model);

        int SaveRemotes(Remotes model);
    }
}
