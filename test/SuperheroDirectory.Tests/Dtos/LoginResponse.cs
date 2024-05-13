namespace SuperheroDirectory.Tests.Dtos
{
    public class LoginResponse
    {
        public string TokenType { set; get; }
        public string AccessToken { set; get; }
        public int ExpiresIn { set; get; }
        public string RefreshToken { set; get; }
    }
}
