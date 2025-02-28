namespace API.Shared.Web.Models
{
    internal record ProblemResponseDTO
    {
        public string Title { get; init; }
        public string Type { get; init; }
        public string DetailsMessage { get; init; }
        public int StatusCode { get; init; }
    }
}
