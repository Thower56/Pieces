using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Pieces
    {
        private Dictionary<Pieces, int> m_Components;
        private string m_Description;
        private string m_NumeroSerie;
        private int m_Reference;

        public Pieces(string p_description, int p_reference, string p_numeroSerie)
        {
            if(p_description is null){throw new ArgumentNullException("description ne peut pas etre null (ctor1)"); }
            if(p_reference <= 0){throw new ArgumentNullException("reference ne peut pas etre < 0 (ctor2)"); }
            if(p_numeroSerie is null){throw new ArgumentNullException("numeroSerie ne peut pas etre null (ctor3)"); }

            m_Components = new Dictionary<Pieces, int>();
            Description = p_description;
            NumeroSerie = p_numeroSerie;
            Reference = p_reference;
        }
        public virtual void AjoutPieces(Pieces p_component)
        {
            if(this.m_Components.ContainsKey(p_component))
            {
                this.m_Components[p_component]++;
            }
            else
            {
                this.m_Components.Add(p_component, 1);
            }
        }

        public string Description
        {
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("value ne peut pas etre null (1)");
                }
                this.m_Description = value;
            }
            get
            {
                return this.m_Description;
            }
        }

        public string NumeroSerie
        {
            set
            {   
                if(value == null)
                {
                    throw new ArgumentException("value ne peut pas etre < 0 (2)");
                }
                this.m_NumeroSerie = value;
            }
            get
            {
                return this.m_NumeroSerie;
            }
        }

        public int Reference
        {
            set
            {
                if(value < 0)
                {
                    throw new ArgumentNullException("value ne peut pas etre null (3)");
                }
                this.m_Reference = value;
            }
            get
            {
                return this.m_Reference;
            }
        }

        public Dictionary<Pieces, int> ListePieces()
        {
            Dictionary<Pieces, int> copieListe = this.m_Components;
            return copieListe;
        }

        public virtual List<Pieces> PrepareListe()
        {
            List<Pieces> liste = new List<Pieces>{ new Pieces(this.m_Description, this.m_Reference, this.m_NumeroSerie)};

            foreach(KeyValuePair<Pieces, int> p in this.m_Components)
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
                .GroupBy(p => p.Description)
                .Select(p => new PieceBom{Set_Description = p.Key, Set_Reference = p.First().m_Reference, Set_Nombre = p.Count()})
                .OrderBy(p => p.Get_Reference)
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
            string info = $"Piece: {this.m_Description}, part - #{this.m_Reference}, numero serie - #{this.m_NumeroSerie} /n";

            
            foreach(KeyValuePair<Pieces, int> p in this.m_Components)
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
            if (!(obj is Pieces) || (obj is null)) return false;

            Pieces p = (Pieces) obj;
            return p.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.m_Description, this.m_NumeroSerie, this.m_Reference);
        }

    }
}
