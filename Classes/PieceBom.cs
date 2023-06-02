namespace Classes
{
    public class PieceBom
    {
        private string m_Description;

        private int m_Reference;

        private int m_Nombre;

        public PieceBom(){}
        public PieceBom(string p_Description, int p_Reference, int p_Nombre)
        {
            Set_Description = p_Description;
            Set_Nombre = p_Nombre;
            Set_Reference = p_Reference;
        }
        public string Set_Description
        {
            set
            {
                if(value == null){ throw new ArgumentNullException("value");}
                this.m_Description = value;
            }
        }

        public int Get_Reference
        {
            get
            {
                return this.m_Reference;
            }
        }

        public int Set_Reference
        {
            set
            {
                if(value <= 0){ throw new ArgumentOutOfRangeException("value");}
                this.m_Reference = value;
            }
        }

        public int Set_Nombre
        {
            set
            {
                if(value <= 0){ throw new ArgumentOutOfRangeException("value");}
                this.m_Nombre = value;
            }
        }


        public override string ToString()
        {
            return $"{(this.m_Description).PadRight(27)} {(this.m_Reference).ToString().PadRight(13)} {(this.m_Nombre).ToString().PadRight(10)}\n";
        }
    }
}
