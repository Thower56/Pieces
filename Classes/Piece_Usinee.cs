using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Piece_Usinee : Pieces
    {
        public Piece_Usinee(string p_description, int p_reference, string p_numeroSerie) : base(p_description, p_reference, p_numeroSerie)
        {
        }
        
        public override string ToString()
        {
            return $"Piece: {this.Get_Description}, part - #{this.Get_Reference}, numero serie - #{this.Get_NumeroSerie}\n";
        }
    }
}