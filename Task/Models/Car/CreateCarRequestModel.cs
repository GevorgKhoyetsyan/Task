namespace Task.Models.Car
{
    public class CreateCarRequestModel
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
    }
}
