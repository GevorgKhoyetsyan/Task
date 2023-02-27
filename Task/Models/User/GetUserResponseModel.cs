using Task.Models.Car;

namespace Task.Models.User
{
    public class GetUserResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public ICollection<CarResponseModel>? cars { get; set; }
    }
}
