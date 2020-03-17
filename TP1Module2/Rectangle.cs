namespace TP1Module2
{
    public class Rectangle : Forme
    {
        internal int Longueur;
        internal int Largeur;

        public override double aire()
        {
            return this.Longueur * this.Largeur;
        }

        public override double perimetre()
        {
            return this.Longueur * 2 + this.Largeur * 2;
        }

        public override string ToString()
        {
            return "Rectangle de longueur = " + this.Longueur + " et de largeur = " + this.Largeur + "\n" + base.ToString();
        }
    }
}