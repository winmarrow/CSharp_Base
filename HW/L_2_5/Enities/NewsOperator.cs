using System;
using System.Collections.Generic;
using System.Linq;
using L_2_5.Enums;
using L_2_5.Interfaces;
using SharedLib.Structs;

namespace L_2_5.Enities
{
    public class NewsOperator : INewsOperator
    {
        private event EventHandler<NewNewsEventArgs> NewNewsAdded;
        private readonly List<News> _news = new List<News>();

        public AddResult AddNews(News news)
        {
            if (!News.IsValid(news)) return new AddResult("News is invalid or news category don't exist");

            _news.Add(news);
            Console.WriteLine("New news added");

            NewNewsAdded?.Invoke(this, new NewNewsEventArgs(news.Category, _news.Count - 1));

            return new AddResult();
        }

        public IEnumerable<News> GetAll()
        {
            return _news;

        }
        public IEnumerable<News> GetAllByCategory(NewsCategory category)
        {
            return _news.Where(news => news.Category.HasFlag(category)).ToList();
        }

        public News GetByIndex(int index)
        {
            return this[index];
        }

        //public News this[int index]
        //{
        //    get
        //    {
        //        if (index < 0 && index > _news.Count - 1) return new News();
        //        return _news[index];
        //    }
        //}
        // TODO Да ладно вы же используете новый синтаксис, а это всего лишь 6.0
        public News this[int index] => index >= 0 && index < _news.Count ? _news[index] : new News();

        public void Subscribe(INewsSubscriber newsSubscriber)
        {
            NewNewsAdded += newsSubscriber.OnNewNews;
        }
        public void Unsubscribe(INewsSubscriber newsSubscriber)
        {
            NewNewsAdded -= newsSubscriber.OnNewNews;
        }


    }
}