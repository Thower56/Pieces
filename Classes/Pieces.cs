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
            if(p_description is null){throw new ArgumentNullException("description ne peut pas etre null (ctor1)"); }
            if(p_reference <= 0){throw new ArgumentNullException("reference ne peut pas etre < 0 (ctor2)"); }
            if(p_numeroSerie is null){throw new ArgumentNullException("numeroSerie ne peut pas etre null (ctor3)"); }
            Set_Description = p_description;
            Set_NumeroSerie = p_numeroSerie;
            Set_Reference = p_reference;
        }
        public virtual void AjoutPieces(Pieces p_component)
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
        public Dictionary<Pieces, int> GetListePieces()
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
            List<PieceBom> listBom = PrepareListe()
            .GroupBy(p => p.Get_Description)
            .Select(p => new PieceBom{m_Description = p.Key, m_Reference = p.First().m_Reference, m_Nombre = p.Count()})
            .OrderBy(p => p.m_Reference)
            .ToList();

            string BOM = $"{"Description".PadLeft(0)} {"Reference".PadLeft(25)} {"Nombre".PadLeft(10)}\n";
                        
            foreach(var p in listBom)
            {
                BOM += p.ToString();
            }

            return BOM;
        }


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
        
        
        public override bool Equals(Object obj)
        {
            if (!(obj is Pieces)) return false;

            Pieces p = (Pieces) obj;
            return this.Get_Description == p.Get_Description & this.Get_NumeroSerie == p.Get_NumeroSerie & this.m_Reference == p.m_Reference;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Get_Description, this.Get_NumeroSerie, this.Get_Reference);
        }

    }
}
