namespace Classes
{
    public class PieceBom
    {
        public string m_Description;

        public int m_Reference;

        public int m_Nombre;

        public override string ToString()
        {
            return $"{(this.m_Description).PadRight(25)} {(this.m_Reference).ToString().PadLeft(6)} {(this.m_Nombre).ToString().PadLeft(10)}\n";
        }
    }
}
