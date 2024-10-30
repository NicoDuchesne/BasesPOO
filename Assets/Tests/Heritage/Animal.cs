using System;
using System.Security.Policy;

namespace TU_Challenge.Heritage
{

    public abstract class Animal
    {

        protected string _name;
        protected int _pattes;
        protected bool _isAlive;
        protected STATE _state;

        public string Name => _name;
        public int Pattes => _pattes;
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public STATE State { get => _state; set => _state = value; }

        public event Action OnDie;


        public Animal(string name)
        {
            this._name = name;
            this._state = STATE.HUNGRY;
            this._isAlive = true;
        }

        public abstract string Crier();

        public void Die()
        {
            this._isAlive = false;
            OnDie?.Invoke();
        }
    }
}

public enum STATE
{
    HUNGRY,
    FED,
    ATE_FISH,
};
