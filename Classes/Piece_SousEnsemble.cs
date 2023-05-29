using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Piece_SousEnsemble : Pieces
    {
        private Dictionary<Pieces, int> m_Sous_Emsemble_Components = new Dictionary<Pieces, int>();
        public override void AjoutPieces(Pieces p_component)
        {
            if(m_Sous_Emsemble_Components.ContainsKey(p_component))
            {
                m_Sous_Emsemble_Components[p_component]++;
            }
            else
            {
                m_Sous_Emsemble_Components.Add(p_component, 1);
            }
        }
        public Piece_SousEnsemble(string p_description, int p_reference, string p_numeroSerie) : base(p_description, p_reference, p_numeroSerie)
        {
        }

        public Dictionary<Pieces, int> GetListePieces()
        {
            return m_Sous_Emsemble_Components;
        }

        public override List<Pieces> PrepareListe()
        {
            List<Pieces> liste = new List<Pieces>{ new Pieces(Get_Description, Get_Reference, Get_NumeroSerie)};

            foreach(KeyValuePair<Pieces, int> p in m_Sous_Emsemble_Components)
            {
                for (int i = 0; i < p.Value; i++)
                {
                    liste.Add(p.Key);   
                }
            }

            return liste;
        }

        public override string ToString()
        {   
            string info = $"Piece: {Get_Description}, part - #{Get_Reference}, numero serie - #{Get_NumeroSerie}\n";

            
            foreach(KeyValuePair<Pieces, int> p in m_Sous_Emsemble_Components)
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
