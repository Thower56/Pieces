using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Pieces
    {
        private Dictionary<Pieces, int> Components = new Dictionary<Pieces, int>();
        private string m_Description;
        private string m_NumeroSerie;
        private int m_Reference;

        public Pieces(string p_description, int p_reference, string p_numeroSerie)
        {
            Set_Description = p_description;
            Set_NumeroSerie = p_numeroSerie;
            Set_Reference = p_reference;
        }
        public virtual void AjoutComponent(Pieces p_component)
        {
            if(Components.ContainsKey(p_component))
            {
                Components[p_component]++;
            }
            else
            {
                Components.Add(p_component, 1);
            }
        }

        public string Set_Description
        {
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("value ne peut pas etre null (1)");
                }
                this.m_Description = value;
            }
        }

        public string Set_NumeroSerie
        {
            set
            {   
                if(value == null)
                {
                    throw new ArgumentException("value ne peut pas etre < 0 (2)");
                }
                this.m_NumeroSerie = value;
            }
        }

        public int Set_Reference
        {
            set
            {
                if(value < 0)
                {
                    throw new ArgumentNullException("value ne peut pas etre null (3)");
                }
                this.m_Reference = value;
            }
        }

        public string Get_Description
        {
            get{return this.m_Description;}
        }
        public string Get_NumeroSerie
        {
            get{return this.m_NumeroSerie;}
        }
        public int Get_Reference
        {
            get{return this.m_Reference;}
        }
        public Dictionary<Pieces, int> GetDictionary()
        {
            return Components;
        }

        public virtual List<Pieces> PrepareListe()
        {
            List<Pieces> liste = new List<Pieces>{ new Pieces(Get_Description, Get_Reference, Get_NumeroSerie)};

            foreach(KeyValuePair<Pieces, int> p in Components)
            {
                for (int i = 0; i < p.Value; i++)
                {
                    liste.AddRange(p.Key.PrepareListe());
                }
            }

            return liste;
        }

        public string BOM()
        {
            var bom = PrepareListe()
            .GroupBy(p => p.Get_Description)
            .Select(p => new {Description = p.Key, Reference = p.First().Get_Reference, Count = p.Count()})
            .OrderBy(p => p.Reference);

            string BOM = $"{"Description".PadLeft(0)} {"Reference".PadLeft(25)} {"Nombre".PadLeft(10)}\n";
                        
            foreach(var p in bom)
            {
                BOM += $"{(p.Description).PadRight(25)} {(p.Reference).ToString().PadLeft(6)} {(p.Count).ToString().PadLeft(10)}\n";
            }

            return BOM;
        }


        // public virtual string BOM()
        // {
        //     string info = $"{"Description".PadLeft(0)} {"Reference".PadLeft(25)} {"Nombre".PadLeft(10)}\n";
        //     info += $"{this.m_Description.PadRight(25)} {this.m_Reference.ToString().PadLeft(6)} {"1".PadLeft(10)}\n";

        //     foreach(KeyValuePair<Pieces, int> p in Components)
        //     {
        //         info += $"{p.Key.Get_Description.PadRight(25)} {p.Key.Get_Reference.ToString().PadLeft(6)} {p.Value.ToString().PadLeft(10)}\n";
            
        //         if(p.Key.GetType().Name == "Piece_SousEnsemble")
        //         {
        //             var copiePiece = (Piece_SousEnsemble)p.Key;
        //             var copieDic = copiePiece.GetDictionary();
                    
        //             foreach(KeyValuePair<Pieces, int> ps in copieDic)
        //             {
        //                 info += $"{ps.Key.Get_Description.PadRight(25)} {ps.Key.Get_Reference.ToString().PadLeft(6)} {(ps.Value * p.Value).ToString().PadLeft(10)}\n";
        //             }
        //         }
                
        //     }

        //     return info;
        // }

        public override string ToString()
        {   
            string info = $"Piece: {this.m_Description}, part - #{this.m_Reference}, numero serie - #{this.m_NumeroSerie}\n";

            
            foreach(KeyValuePair<Pieces, int> p in Components)
            {   
                for(int i=0 ; i < p.Value ; i++)
                {
                    info += $"  {p.Key.ToString()}";
                }
            }
    
            return info;
        }

    }
}