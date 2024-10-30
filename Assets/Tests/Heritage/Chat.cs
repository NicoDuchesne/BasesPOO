using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        public Chat(string name) : base(name)
        {
            this._pattes = 4;
        }

        public override string Crier()
        {
            switch (_state)
            {
                case STATE.HUNGRY:
                    return "Miaou (j'ai faim)";
                case STATE.FED:
                    return "Miaou (c'est bon laisse moi tranquille humain)";
                case STATE.ATE_FISH:
                    return "Miaou (Le poisson etait bon)";
                default:
                    return "Miaou (erreur)";
            }
        }

    }
}
