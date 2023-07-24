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
    }
}
