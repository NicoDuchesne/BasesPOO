using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chien : Animal
    {
        public Chien(string name) : base(name)
        {
            this._pattes = 4;
        }

        public override string Crier()
        {
            switch (_state)
            {
                case STATE.HUNGRY:
                    return "Ouaf (j'ai faim)";
                case STATE.FED:
                    return "Ouaf (viens on joue ?)";
                default:
                    return "Ouaf (erreur)";
            }
        }

    }
}
