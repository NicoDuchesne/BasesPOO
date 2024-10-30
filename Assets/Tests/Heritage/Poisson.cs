using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Poisson : Animal
    {
        public Poisson(string name) : base(name) 
        {
            this._pattes = 0;
            this._name = name + " le poisson";
        }

        public override string Crier()
        {
            switch (_state)
            {
                case STATE.HUNGRY:
                    return "Bloupbloup (j'ai faim)";
                case STATE.FED:
                    return "Bloupbloup (j'ai mangé je crois)";
                default:
                    return "Bloupbloup (erreur)";
            }
        }
    }
}
