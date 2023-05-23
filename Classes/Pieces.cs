using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Pieces
    {
        private List<Pieces> Components = new List<Pieces>();
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
            Components.Add(p_component);
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

        public string BOM()
        {
            var bill = new System.Text.StringBuilder();
            bill.Append(String.Format("{0,0} {1,30} {2,10}", "Description", "Reference", "Nombre\n")); 
            bill.Append(String.Format("{0,0} {1,-5} {2,9} {3}", Get_Description, Get_Reference, 1, "\n"));
            foreach (Pieces p in Components)
            {
                bill.Append(String.Format("{0,0} {1,-5} {2,9} {3}", p.Get_Description, p.Get_Reference, 1, "\n"));
            }
            return bill.ToString();
        }

        public override string ToString()
        {   
            string info = $"Piece: {this.m_Description}, part - #{this.m_Reference}, numero serie - #{this.m_NumeroSerie}\n";

            
            foreach(Pieces p in Components)
            {   
                info += $"  {p.ToString()}";
            }
    
            return info;
        }

    }
}