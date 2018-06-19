using System;
using System.Collections.Generic;
using L_2_5.Enums;
using L_2_5.Interfaces;

namespace L_2_5.Enities
{
    public class NewsSubscriber : INewsSubscriber
    {
        private const string NewsDisplayTemplate = "News from categories: [{0}]\n-Title: \"{1}\"\n-Description: {2}\n\t{3}";

        public NewsCategory Interests { get; private set; }

        public List<News> MyNews = new List<News>();

        public NewsSubscriber(NewsCategory interests)
        {
            Interests = interests;
        }

        public void OnNewNews(object sender, NewNewsEventArgs eventArgs)
        {
            if (eventArgs.Category.HasFlag(Interests))
                GotNews((sender as INewsOperator).GetByIndex(eventArgs.NewsIndex));
            // TODO Я бы развернул такой пул реквест.
            // Мне не нравиться что у вас подписчик ходить в новостное агентство и забирает новость
            // Тут прекрасно может приходить новость, и подписчику не обязательно знать откуда в данном случае.
            // А уж тем более ходить и забирать что он там получил.
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