namespace Poliza.Models
{
    public class UserEntity
    {
        public UserEntity(int id, string name, string password, string? role)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = role;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
