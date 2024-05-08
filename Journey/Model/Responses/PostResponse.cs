using Journy.Model;

namespace Journey.Model.Responses
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public double AverageRatings { get; set; }
        public string Username { get; set; }
        public string CountryName { get; set; }

      
    }
}
