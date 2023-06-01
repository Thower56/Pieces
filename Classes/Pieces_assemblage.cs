using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Pieces_assemblage : Pieces
    {
        public Pieces_assemblage(string p_description, int p_reference, string p_numeroSerie) : base(p_description, p_reference, p_numeroSerie)
        {
        }

        public override string ToString()
        {
            return $"Piece: {this.Description}, part - #{this.Reference}, numero serie - #{this.NumeroSerie}\n";
        }
    }
}