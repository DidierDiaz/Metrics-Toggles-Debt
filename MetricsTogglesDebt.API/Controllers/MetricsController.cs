using MetricsTogglesDebt.API.Helper;
using MetricsTogglesDebt.Data.Entities;
using MetricsTogglesDebt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MetricsTogglesDebt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly IMetricsService _metricsService;

        public MetricsController(IMetricsService metricsService) => _metricsService = metricsService;

        [HttpGet(nameof(ImportResults))]
        public JSONObjectResult<int> ImportResults()
        {
            JSONObjectResult<int> responseObject = new();

            try
            {
                string json = System.IO.File.ReadAllText(Path.Combine("wwwroot", "json_files", "report_results.json"));
                var linesOfCode = JsonSerializer.Deserialize<List<ReportResultsJson>>(json, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                }) ?? throw new Exception("No se ha encontrado datos para importar");

                int imported = 0;
                foreach (var item in linesOfCode)
                {
                    if (!string.IsNullOrEmpty(item.File))
                        item.File = item.File.Replace("file:///c%3A/Github/", "/");

                    var entity = new LinesOfCode()
                    {
                        File = item?.File,
                        Language = item?.Language,
                        Lines = item?.Code?.ToString(),
                        Comments = item?.Comment?.ToString(),
                        Blank = item?.Blank?.ToString()
                    };

                    entity.Id = _metricsService.SaveLinesOfCode(entity);
                    imported++;
                }

                responseObject.Data = imported;
            }
            catch (Exception e)
            {
                responseObject.Status = System.Net.HttpStatusCode.InternalServerError;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                responseObject.Errors = new List<string>
                {
                    e.Message
                };
            }

            return responseObject;
        }

        [HttpGet(nameof(ImportSpecialCharacters))]
        public JSONObjectResult<int> ImportSpecialCharacters()
        {
            JSONObjectResult<int> responseObject = new();

            try
            {
                string json = System.IO.File.ReadAllText(Path.Combine("wwwroot", "json_files", "special_characters_results.json"));
                var specialCharacters = JsonSerializer.Deserialize<List<SpecialCharactersResultJson>>(json, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                }) ?? throw new Exception("No se ha encontrado datos para importar");

                int imported = 0;

                List<LinesOfCode> linesOfCode = _metricsService.GetAllLinesOfCodes();

                if (linesOfCode?.Count < 1)
                    throw new Exception("Para importar los caracteres especiales primero importe los datos del archivo report_results.json");

                foreach (SpecialCharactersResultJson item in specialCharacters)
                {
                    if (string.IsNullOrEmpty(item.Path))
                        continue;

                    item.Path = item.Path.Replace("\\", "/");

                    List<LinesOfCode>? found = linesOfCode?.Where(x => x.File.ToLower().Contains(item.Path))?.ToList();

                    if (found is null)
                        continue;

                    var entity = new LinesOfCode()
                    {
                        Id = found.FirstOrDefault().Id,
                        SpecialCharacters = item.Chars
                    };

                    entity.Id = _metricsService.UpdateLinesOfCode(entity);
                    imported++;
                }

                responseObject.Data = imported;
            }
            catch (Exception e)
            {
                responseObject.Status = System.Net.HttpStatusCode.InternalServerError;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                responseObject.Errors = new List<string>
                {
                    e.Message
                };
            }

            return responseObject;
        }

        [HttpGet(nameof(ImportMethodsResults))]
        public JSONObjectResult<int> ImportMethodsResults()
        {
            JSONObjectResult<int> responseObject = new();

            try
            {
                string json = System.IO.File.ReadAllText(Path.Combine("wwwroot", "json_files", "methods_results.json"));
                var methodsResults = JsonSerializer.Deserialize<List<MethodsResultsJson>>(json, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                }) ?? throw new Exception("No se ha encontrado datos para importar");

                int imported = 0;
                foreach (var item in methodsResults)
                {
                    item.Path = item.Path?.Replace("\\", "/");

                    var entity = new ClassesAndMethods()
                    {
                        Path = item.Path,
                        Found = item.Found,
                        FoundPaths = item.FoundPaths,
                        Method = item.Name
                    };

                    entity.Id = _metricsService.SaveClassesAndMethods(entity);
                    imported++;
                }

                responseObject.Data = imported;
            }
            catch (Exception e)
            {
                responseObject.Status = System.Net.HttpStatusCode.InternalServerError;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                responseObject.Errors = new List<string>
                {
                    e.Message
                };
            }

            return responseObject;
        }

        [HttpGet(nameof(ImportHistoryCommits))]
        public JSONObjectResult<int> ImportHistoryCommits()
        {
            JSONObjectResult<int> responseObject = new();

            try
            {
                string json = System.IO.File.ReadAllText(Path.Combine("wwwroot", "json_files", "history_commits_results.json"));
                var commits = JsonSerializer.Deserialize<List<Commit>>(json, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                }) ?? throw new Exception("No se ha encontrado datos para importar");

                int imported = 0;
                foreach (var commit in commits)
                {
                    commit.Id = _metricsService.SaveCommit(commit);
                    imported++;
                }

                responseObject.Data = imported;
            }
            catch (Exception e)
            {
                responseObject.Status = System.Net.HttpStatusCode.InternalServerError;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                responseObject.Errors = new List<string>
                {
                    e.Message
                };
            }

            return responseObject;
        }

        [HttpGet(nameof(ImportTagCommits))]
        public JSONObjectResult<int> ImportTagCommits()
        {
            JSONObjectResult<int> responseObject = new();

            try
            {
                string json = System.IO.File.ReadAllText(Path.Combine("wwwroot", "json_files", "tags_results.json"));
                var tags = JsonSerializer.Deserialize<List<Tags>>(json, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                }) ?? throw new Exception("No se ha encontrado datos para importar");

                int imported = 0;
                foreach (var tag in tags)
                {
                    tag.Id = _metricsService.SaveTags(tag);
                    imported++;
                }

                responseObject.Data = imported;
            }
            catch (Exception e)
            {
                responseObject.Status = System.Net.HttpStatusCode.InternalServerError;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                responseObject.Errors = new List<string>
                {
                    e.Message
                };
            }

            return responseObject;
        }

        [HttpGet(nameof(ImportRemoteCommits))]
        public JSONObjectResult<int> ImportRemoteCommits()
        {
            JSONObjectResult<int> responseObject = new();

            try
            {
                string json = System.IO.File.ReadAllText(Path.Combine("wwwroot", "json_files", "remotes.json"));
                var remotes = JsonSerializer.Deserialize<List<Remotes>>(json, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                }) ?? throw new Exception("No se ha encontrado datos para importar");

                int imported = 0;
                foreach (var remote in remotes)
                {
                    remote.Id = _metricsService.SaveRemotes(remote);
                    imported++;
                }

                responseObject.Data = imported;
            }
            catch (Exception e)
            {
                responseObject.Status = System.Net.HttpStatusCode.InternalServerError;
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                responseObject.Errors = new List<string>
                {
                    e.Message
                };
            }

            return responseObject;
        }
    }
}
