namespace Journey.Model.Responses
{
    public class PostResponse
    {
        public int Id { get; internal set; }
        public string Text { get; internal set; }
        public string Title { get; internal set; }
        public string ImagePath { get; internal set; }
        public double AverageRatings { get; internal set; }
    }
}
