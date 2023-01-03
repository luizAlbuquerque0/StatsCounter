namespace StatsCounter.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string token, int id)
        {
            Email = email;
            Token = token;
            Id = id;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
        public int Id { get; private set; }

    }
}
    