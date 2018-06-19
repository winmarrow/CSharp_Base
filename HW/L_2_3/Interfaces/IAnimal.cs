namespace L_2_3.Interfaces
{
    public interface IAnimal
    {
        bool IsHunger { get; }
        void Eat();
        void Sleep();
    }
}