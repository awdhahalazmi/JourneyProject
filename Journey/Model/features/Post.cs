namespace Journy.Model.features
{
    public class Post
    {
        public int Id { get; set; }
        public string Texts { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }

        public UserAccount User { get; set; }
        public Country Country { get; set; }
    }
}
