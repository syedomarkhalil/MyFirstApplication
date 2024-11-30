namespace MyFirstApplication.Models
{
    

        public class Show
        {
            public int Id { get; set; }
            public string? Url { get; set; }
            public string? Name { get; set; }
            public string? Type { get; set; }
            public string? Language { get; set; }
            public string[]? Genres { get; set; }
            public string? Status { get; set; }
            public string? Runtime { get; set; }
            public int AverageRuntime { get; set; }
            public string? Premiered { get; set; }
            public string? Ended { get; set; }
            public string? OfficialSite { get; set; }
            public Schedule? Schedule { get; set; }
            public Rating? Rating { get; set; }
            public int Weight { get; set; }
            public Network? Network { get; set; }
            public object? WebChannel { get; set; }
            public object? DvdCountry { get; set; }
            public Externals? Externals { get; set; }
            public Image? Image { get; set; }
            public string? Summary { get; set; }
            public int Updated { get; set; }
            public Links? Links { get; set; }
        }

        public class Schedule
        {
            public string? Time { get; set; }
            public string[]? Days { get; set; }
        }

        public class Rating
        {
            public float? Average { get; set; }
        }

        public class Network
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public Country? Country { get; set; }
            public string? OfficialSite { get; set; }
        }

        public class Country
        {
            public string? Name { get; set; }
            public string? Code { get; set; }
            public string? Timezone { get; set; }
        }

        public class Externals
        {
            public int Tvrage { get; set; }
            public string? TheTvdb { get; set; }
            public string? Imdb { get; set; }
        }

        public class Image
        {
            public string? Medium { get; set; }
            public string? Original { get; set; }
        }

        public class Links
        {
            public Self? Self { get; set; }
            public Previousepisode? PreviousEpisode { get; set; }
        }

        public class Self
        {
            public string? Href { get; set; }
        }

        public class Previousepisode
        {
            public string? Href { get; set; }
            public string? Name { get; set; }
        }

    
}
