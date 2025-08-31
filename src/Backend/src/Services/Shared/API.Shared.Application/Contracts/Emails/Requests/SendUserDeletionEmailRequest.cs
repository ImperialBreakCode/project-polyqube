namespace API.Shared.Application.Contracts.Emails.Requests
{
    public record SendUserDeletionEmailRequest(string Email, string DeletionToken)
    {
        public static SendUserDeletionEmailRequest Create(string Email, string DeletionToken) 
            => new(Email, DeletionToken);
    }
}
