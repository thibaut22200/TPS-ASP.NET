namespace TP1Module2
{
    public abstract class Forme
    {
        public abstract double aire();
        public abstract double perimetre();
        public override string ToString()
        {
            return "Aire = " + this.aire() + "\n" + "Périmètre = " + this.perimetre() + "\n";
        }
    }
}