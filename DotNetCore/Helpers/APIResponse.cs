namespace DotNetCore.Helpers
{
    public class ApiResponse
    {

        public int? StatusCode { get; set; }
        public string? HttpStatusCodes { get; set; }
        public string? Message { get; set; }
        public dynamic Data { get; set; }
        public int? AffectedRows { get; set; }
        public dynamic Error { get; set; }
        public bool ExistanceFlag { get; set; }

    }
}
