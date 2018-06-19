using L_2_5.Enities;

namespace L_2_5.Interfaces
{
    public interface INewsOperator
    {
        void Subscribe(INewsSubscriber newsSubscriber);
        void Unsubscribe(INewsSubscriber newsSubscriber);

        News GetByIndex(int index);
    }
}