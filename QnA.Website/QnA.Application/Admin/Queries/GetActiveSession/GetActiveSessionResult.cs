namespace QnA.Application.Admin.Queries.GetActiveSession
{
    public class GetActiveSessionResult
    {
        public string Title { get; set; }
        public string Password { get; set; }
        public bool IsOffline { get; set; }
    }
}