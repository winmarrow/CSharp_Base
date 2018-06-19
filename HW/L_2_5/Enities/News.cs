using System;
using L_2_5.Enums;

namespace L_2_5.Enities
{
    public class News
    {
        public NewsCategory Category { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }

        public static bool IsValid(News news)
        {
            return news != null
                   && !string.IsNullOrWhiteSpace(news.Title)
                   && !string.IsNullOrWhiteSpace(news.ShortDescription)
                   && !string.IsNullOrWhiteSpace(news.Content);
        }
    }
}