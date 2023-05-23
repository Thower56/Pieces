using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Piece_SousEnsemble : Pieces
    {
        private List<Pieces> Sous_Emsemble_Components = new List<Pieces>();
        public override void AjoutComponent(Pieces p_component)
        {
            Sous_Emsemble_Components.Add(p_component);
        }
        public Piece_SousEnsemble(string p_description, int p_reference, string p_numeroSerie) : base(p_description, p_reference, p_numeroSerie)
        {
        }
        
        public override string ToString()
        {   
            string info = $"Piece: {this.Get_Description}, part - #{this.Get_Reference}, numero serie - #{this.Get_NumeroSerie}\n";

            
            foreach(Pieces p in Sous_Emsemble_Components)
            {   
                info += $"    {p.ToString()}";
            }
    
            return info;
        }
    }
}