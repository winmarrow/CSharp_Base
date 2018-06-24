using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L_2_5.Enums;
using L_2_5.Interfaces;

namespace L_2_5.Enities
{
    // TODO Вот вам пример с методом подписки и событием через свойство.
    // Жаль вас небыло в субботу. Я как раз это всё в деталях рассказывал
    public class NewsOperatorV2
    {
        private readonly Dictionary<NewsCategory, EventHandler<NewNewsEventArgs>> _onFreshNewsEvent;

        public NewsOperatorV2()
        {
            _onFreshNewsEvent = new Dictionary<NewsCategory, EventHandler<NewNewsEventArgs>>();
        }

        public void AddNews(News news)
        {
            if(news == null) throw new ArgumentNullException("news is null");
            if(_onFreshNewsEvent.ContainsKey(news.Category)) 
                _onFreshNewsEvent[news.Category]?.Invoke(this, new NewNewsEventArgs(news));
        }

        public void Subscribe(INewsSubscriberV2 subscriber, params NewsCategory[] category)
        {
            foreach (var newsCategory in category)
                _onFreshNewsEvent[newsCategory] += subscriber.OnNewNews;
        }

        public event EventHandler<NewNewsEventArgs> OnNewsAdded
        {
            add => ManageSubscription(value, true);
            remove => ManageSubscription(value, false);
        }

        private void ManageSubscription(EventHandler<NewNewsEventArgs> value, bool shouldAdd)
        {
            var subscriber = value.Target as INewsSubscriberV2;
            if(subscriber == null) return;

            foreach (var newsCategory in _onFreshNewsEvent.Keys)
                if (subscriber.SubscibeCategories.HasFlag(newsCategory))
                    if (shouldAdd)
                        _onFreshNewsEvent[newsCategory] += value;
                    else
                        _onFreshNewsEvent[newsCategory] -= value;
        }
    }
}
