using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Piece_SousEnsemble : Pieces
    {
        private Dictionary<Pieces, int> Sous_Emsemble_Components = new Dictionary<Pieces, int>();
        public override void AjoutComponent(Pieces p_component)
        {
            if(Sous_Emsemble_Components.ContainsKey(p_component))
            {
                Sous_Emsemble_Components[p_component]++;
            }
            else
            {
                Sous_Emsemble_Components.Add(p_component, 1);
            }
        }
        public Piece_SousEnsemble(string p_description, int p_reference, string p_numeroSerie) : base(p_description, p_reference, p_numeroSerie)
        {
        }

        public override string DOM()
        {
            string info ="";
            foreach(KeyValuePair<Pieces, int> p in Sous_Emsemble_Components)
            {
                info += $"{p.Key.Get_Description.PadRight(25)} {p.Key.Get_Reference.ToString().PadLeft(5)} {(p.Value).ToString().PadLeft(10)}\n";
            }

            return info;
        }
        
        public override string ToString()
        {   
            string info = $"Piece: {Get_Description}, part - #{Get_Reference}, numero serie - #{Get_NumeroSerie}\n";

            
            foreach(KeyValuePair<Pieces, int> p in Sous_Emsemble_Components)
            {   
                for(int i=0 ; i < p.Value ; i++)
                {
                    info += $"    {p.Key.ToString()}";
                }
            }
    
            return info;
        }
    }
}