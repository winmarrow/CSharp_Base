using L_2_5.Enities;

namespace L_2_5.Interfaces
{
    public interface INewsSubscriber
    {
        void OnNewNews(object sender, NewNewsEventArgs eventArgs);
    }
}