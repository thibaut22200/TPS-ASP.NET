namespace TP1Module2
{
    public class Carre : Forme
    {
        internal int Longueur;
        public override double aire()
        {
            return System.Math.Pow(this.Longueur, 2);
        }

        public override double perimetre()
        {
            return this.Longueur * 4;
        }

        public override string ToString()
        {
            return "Carré de côté = " + this.Longueur + "\n" + base.ToString();
        }
    }
}