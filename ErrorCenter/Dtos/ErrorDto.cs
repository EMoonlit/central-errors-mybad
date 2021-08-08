namespace ErrorCenter.Dtos
{
    public class ErrorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventsCount { get; set; }
        public string Level { get; set; }
    }
}
