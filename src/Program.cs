using Classes;
internal class Program
{
    private static void Main(string[] args)
    {
        Pieces WaterValve = new Pieces("WaterPump",1234,"0481");
        Pieces VisseM8 = new Pieces_assemblage("Visse M8", 8757,"3774");
        Pieces Couvercle_Lateral = new Piece_SousEnsemble("Couvercle lateral", 0374,"1987");
        Pieces Couvercle_Monobloc = new Piece_Usinee("Couvercle Monobloc", 1257,"9874");
        Pieces Systeme_activation = new Piece_SousEnsemble("System d'activation", 1887, "0574");

        WaterValve.AjoutComponent(new Piece_Moulee("Base", 1387, "0474"));
        
        Systeme_activation.AjoutComponent(new Pieces_assemblage("Pin",1687, "0974" ));
        Systeme_activation.AjoutComponent(new Piece_Moulee("Plug", 1657, "0964"));
        Systeme_activation.AjoutComponent(new Piece_Usinee("Poigne", 3157,"2547"));

        WaterValve.AjoutComponent(Systeme_activation);
        Couvercle_Lateral.AjoutComponent(Couvercle_Monobloc);
        for(int i = 0; i < 4 ; i++)
        {
            Couvercle_Lateral.AjoutComponent(VisseM8);
            
        }
        WaterValve.AjoutComponent(Couvercle_Lateral);
        WaterValve.AjoutComponent(Couvercle_Lateral);
        

        Console.WriteLine(WaterValve.DOM());

    }
}