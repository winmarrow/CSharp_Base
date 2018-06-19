using L_2_3.Interfaces;

namespace L_2_3.Abtract
{
    public abstract class Animal
        : IAnimal
    {
        private int _hunger;

        public bool IsHunger
        {
            get { return _hunger <= 20; }
        }

        
        
        protected Animal()
        {
            _hunger = 0;
        }

        
        public void Eat()
        {
            _hunger += 60;

            if (_hunger > 100) _hunger = 100;
        }

        public void Sleep()
        {
            _hunger -= 30;
        }
    }
}