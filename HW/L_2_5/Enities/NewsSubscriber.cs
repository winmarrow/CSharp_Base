using System;
using System.Collections.Generic;
using L_2_5.Enums;
using L_2_5.Interfaces;

namespace L_2_5.Enities
{
    public class NewsSubscriber : INewsSubscriber
    {
        private const string NewsDisplayTemplate =
            "News from categories: [{0}]\n-Title: \"{1}\"\n-Description: {2}\n\t{3}";

        public List<News> MyNews = new List<News>();

        public NewsSubscriber(NewsCategory interests)
        {
            Interests = interests;
        }

        public NewsCategory Interests { get; set; }

        public void OnNewNews(object sender, NewNewsEventArgs eventArgs)
        {
            if (eventArgs.News.Category.HasFlag(Interests))
                GotNews(eventArgs.News);
        }

        private void GotNews(News news)
        {
            MyNews.Add(news);

            Console.WriteLine(NewsDisplayTemplate,
                news.Category,
                news.Title,
                news.ShortDescription,
                news.Content);
        }
    }
}