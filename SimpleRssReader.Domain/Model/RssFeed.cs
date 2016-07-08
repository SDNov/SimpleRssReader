using System;

namespace SimpleRssReader.Domain.Model
{
    public class RssFeed
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Link { get; set; }
        public String Description { get; set; }
    }
}
