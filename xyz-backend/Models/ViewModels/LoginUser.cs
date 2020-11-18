namespace  xyz_backend.Models
{
    public class LoginUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
    }
}