namespace ANCASE.Core.DTOs
{
    public record EmailDTO
    {
        public string Subject { get; init; }
        public IEnumerable<string> To { get; init; }
        public string Body { get; init; }
    }
}
