using MetricsTogglesDebt.Data;
using MetricsTogglesDebt.Data.Entities;
using MetricsTogglesDebt.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetricsTogglesDebt.Service.Implementations
{
    public class MetricsService : IMetricsService
    {
        private readonly MetricsTogglesDebtDbContext _dbContext;

        public MetricsService(MetricsTogglesDebtDbContext dbContext) => _dbContext = dbContext;

        public List<LinesOfCode> GetAllLinesOfCodes()
        {
            try
            {
                return _dbContext.LinesOfCode
                    .AsNoTracking()
                    .OrderBy(x => x.File)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveLinesOfCode(LinesOfCode model)
        {
            try
            {
                if (model is null)
                    return 0;

                _dbContext.LinesOfCode.Add(model);
                _dbContext.SaveChanges();

                return model.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateLinesOfCode(LinesOfCode model)
        {
            try
            {
                if (model is null)
                    return 0;

                LinesOfCode? entity = _dbContext.LinesOfCode.FirstOrDefault(x => x.Id == model.Id);

                if (entity is null)
                    return 0;

                entity.SpecialCharacters = model.SpecialCharacters;

                _dbContext.Update(entity);
                _dbContext.SaveChanges();

                return entity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveClassesAndMethods(ClassesAndMethods model)
        {
            try
            {
                if (model is null)
                    return 0;

                _dbContext.ClassesAndMethods.Add(model);
                _dbContext.SaveChanges();

                return model.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveCommit(Commit model)
        {
            try
            {
                if (model is null)
                    return 0;

                _dbContext.Commit.Add(model);
                _dbContext.SaveChanges();

                return model.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveTags(Tags model)
        {
            try
            {
                if (model is null)
                    return 0;

                _dbContext.Tags.Add(model);
                _dbContext.SaveChanges();

                return model.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveRemotes(Remotes model)
        {
            try
            {
                if (model is null)
                    return 0;

                _dbContext.Remotes.Add(model);
                _dbContext.SaveChanges();

                return model.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double GetDepthOfInheritanceMetrics()
        {
            var classAndMethods = _dbContext.ClassesAndMethods
                .AsNoTracking()
                .GroupBy(x => x.Path)
                .Select(x => new
                {
                    path = x.Key,
                    group = x.ToList()
                }).ToList();

            var groupSum = classAndMethods.Sum(x => x.group.Count);
            var groupMax = classAndMethods.Max(x => x.group.Count);

            double value = Math.Round((double)groupMax / (double)groupSum, 2);
            return value;
        }

        public double GetLinesOfCodeMetrics()
        {
            var linesOfCode = _dbContext.LinesOfCode
                .AsNoTracking()
                .GroupBy(x => x.Lines)
                .Select(x => new
                {
                    lines = x.Key,
                    group = x.ToList()
                }).ToList();

            //var groupSum = linesOfCode.Sum(x => x.group.Count);
            //var groupMax = linesOfCode.Max(x => x.group.Count);

            //double value = Math.Round((double)groupMax / (double)groupSum, 2);
            //return value;
            int groupSum = linesOfCode.Sum(x => int.Parse(x.lines));
            int groupMax = linesOfCode.Max(x => int.Parse(x.lines));

            double value = Math.Round((double)groupMax / (double)groupSum, 2);
            return value;
        }

        public double GetClassCouplingMetrics()
        {
            var classCoupling = _dbContext.ClassesAndMethods
                .AsNoTracking()
                .GroupBy(x => x.Method)
                .Select(x => new
                {
                    method = x.Key,
                    group = x.ToList()
                }).ToList();

            int groupSum = classCoupling.Sum(x => x.group.Count);
            int groupMax = classCoupling.Max(x => x.group.Count);

            double value = Math.Round((double)groupMax / (double)groupSum, 2);
            return value;
        }

        public List<ClassesAndMethods> GetClassesAndMethods()
        {
            return _dbContext.ClassesAndMethods.AsNoTracking().OrderBy(x => x.Method).ToList();
        }

        public List<LinesOfCode> GetLinesOfCode()
        {
            return _dbContext.LinesOfCode.AsNoTracking().OrderBy(x => x.Language).ToList();
        }
    }
}
