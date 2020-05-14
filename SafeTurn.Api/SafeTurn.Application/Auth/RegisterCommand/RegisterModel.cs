namespace SafeTurn.Application.Auth.RegisterCommand
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}