using L_2_5.Enities;
using L_2_5.Enums;

namespace L_2_5.Interfaces
{
    public interface INewsSubscriberV2
    {
        void OnNewNews(object sender, NewNewsEventArgs eventArgs);
        NewsCategory SubscibeCategories { get; set; }
    }
}