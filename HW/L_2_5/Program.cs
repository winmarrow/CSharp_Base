using System;
using L_2_5.Enities;
using L_2_5.Enums;
using CH = SharedLib.Helpers.ConsoleHelper;

namespace L_2_5
{
    internal class Program
    {
        private const string SomeNewsTitleString = "Тунис - Англия 1:2";
        private const string SomeNewsDescriptionString = "Поздний гол Кейна спасает для англичан мертвую игру";

        private const string SomeNewsContentString =
            @"Перспективная и омоложенная сборная Англии стартует на ЧМ-2018 со сверхтяжелой победы над Тунисом с привкусом нервозности, недостатка опыта и хладнокровия, а еще ... нашествия насекомых.

Героем английской нации стал новоиспеченный перед мундиалем капитан и главный форвард ""трех львов"" Харри Кейн. Его быстрый гол сначала вывел команду Саутгейта вперед в счете, а поздний гол головой в добавленное время оформил драматическую победу.

При этом, за весь матч нападающий нанес всего три удара. Действительно лидер.

Но дублю Кейна не утолить чувство больше фарта, чем системы в победе Англии. Хотя они зрелищно и остро начали матч, что мы прогнозировали перед игрой.

Настолько остро, что после собственных сейвов и выкрутасов на старте травмировал плечо основной кипер тунисцев Муез Хассен - он еще успел пропустить гол от Кейна, хотя через мгновение перед ним выполнил шикарный сейв поврежденной рукой. ...";

        private static void Main(string[] args)
        {
            CH.SetConsoleColor();
            CH.SetConsoleOutputEncoding();

            var op = new NewsOperator();
            var subscriber = new NewsSubscriber(NewsCategory.Sport);

            var newNews = new News
            {
                Category = NewsCategory.Sport | NewsCategory.Events,
                Title = SomeNewsTitleString,
                ShortDescription = SomeNewsDescriptionString,
                Content = SomeNewsContentString
            };

            op.Subscribe(subscriber);

            op.AddNews(newNews);

            Console.ReadKey();
        }
    }
}