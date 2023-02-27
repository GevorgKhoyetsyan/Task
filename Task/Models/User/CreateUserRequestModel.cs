using Task.Models.Car;

namespace Task.Models.User
{
    public class CreateUserRequestModel
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
    }
}
