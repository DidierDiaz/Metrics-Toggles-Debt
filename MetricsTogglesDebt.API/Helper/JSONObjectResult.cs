using System.Net;

namespace MetricsTogglesDebt.API.Helper
{
    public class JSONObjectResult<T>
    {
        public ICollection<string>? Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public T? Data { get; set; }

        public JSONObjectResult()
        {
            Status = HttpStatusCode.OK;
            Errors = new List<string>();
        }

        public JSONObjectResult(HttpStatusCode status)
        {
            Status = status;
            Errors = new List<string>();
        }
    }
}
