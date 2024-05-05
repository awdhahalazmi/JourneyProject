namespace Journey.Model
{
    public class CreatePostRequest
    {
        public string Texts { get; set; }
        public string Title { get; set; }
        public IFormFile ImagePath { get; set; }
        public int CountryId { get; set; }
    }

}
