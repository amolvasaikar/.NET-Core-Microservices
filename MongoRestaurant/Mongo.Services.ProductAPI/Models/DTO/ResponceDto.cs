namespace Mongo.Services.ProductAPI.Models.DTO
{
    public class ResponceDto
    {
        public bool IsSucess { get; set; } = true;
        public object Result  { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }

    }
}
