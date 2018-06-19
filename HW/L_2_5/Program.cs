﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L_2_5.Enities;
using L_2_5.Enums;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            CH.SetConsoleColor();
            CH.SetConsoleOutputEncoding();

            var op = new NewsOperator();
            var subscriber = new NewsSubscriber(NewsCategory.Sport);

            var newNews = new News()
            {
                Category = NewsCategory.Sport | NewsCategory.Events,
                Title = "Тунис - Англия 1:2",
                ShortDescription = "Поздний гол Кейна спасает для англичан мертвую игру",
                Content = "Перспективная и омоложенная сборная Англии стартует на ЧМ-2018 со сверхтяжелой победы над Тунисом с привкусом нервозности, недостатка опыта и хладнокровия, а еще ... нашествия насекомых.\r\n\r\nГероем английской нации стал новоиспеченный перед мундиалем капитан и главный форвард \"трех львов\" Харри Кейн. Его быстрый гол сначала вывел команду Саутгейта вперед в счете, а поздний гол головой в добавленное время оформил драматическую победу.\r\n\r\nПри этом, за весь матч нападающий нанес всего три удара. Действительно лидер.\r\n\r\nНо дублю Кейна не утолить чувство больше фарта, чем системы в победе Англии. Хотя они зрелищно и остро начали матч, что мы прогнозировали перед игрой.\r\n\r\nНастолько остро, что после собственных сейвов и выкрутасов на старте травмировал плечо основной кипер тунисцев Муез Хассен - он еще успел пропустить гол от Кейна, хотя через мгновение перед ним выполнил шикарный сейв поврежденной рукой. ..."
                
            };

            op.Subscribe(subscriber);

            op.AddNews(newNews);

            Console.ReadKey();
        }
    }
}
