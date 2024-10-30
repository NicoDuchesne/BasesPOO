using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEditor.Progress;

namespace TU_Challenge.Heritage
{
    public class Animalerie
    {
        private List<Animal> _animals;
        public event Action<Animal> OnAddAnimal;

        public Animalerie()
        {
            this._animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
            CheckCatsAndFishes(animal);
            OnAddAnimal?.Invoke(animal);
        }

        public bool Contains(Animal animal)
        {
            return _animals.Contains(animal);
        }

        public Animal GetAnimal(int index)
        {
            return _animals[index];
        }

        public void FeedAll()
        {
            foreach (Animal animal in _animals)
            {
                animal.State = STATE.FED;
            }
        }

        public void CheckCatsAndFishes(Animal animalAdded)
        {
            if ((animalAdded.GetType() == typeof(Chat) || animalAdded is Poisson) && CatCanEatFish())
            {
                foreach (Animal animal in _animals)
                {
                    if (animal is Poisson && animal.IsAlive) animal.Die();
                    if (animal.GetType() == typeof(Chat) && animal.IsAlive && animal.State == STATE.HUNGRY) animal.State = STATE.ATE_FISH;
                }
            }
        }

        public bool CatCanEatFish()
        {
            bool _containsCat = false;
            bool _containsFish = false;

            foreach (Animal animal in _animals)
            {
                if (animal.GetType() == typeof(Chat) && animal.IsAlive && animal.State == STATE.HUNGRY) _containsCat = true;
                if (animal is Poisson && animal.IsAlive) _containsFish = true;
                if (_containsCat && _containsFish) return true;
            }

            return false;
        }

    }
}


