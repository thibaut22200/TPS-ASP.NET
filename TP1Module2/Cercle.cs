namespace TP1Module2
{
    public class Cercle : Forme
    {
        internal int Rayon;

        public override double aire()
        {
            return System.Math.Pow(this.Rayon, 2) * System.Math.PI;
        }

        public override double perimetre()
        {
            return 2 * System.Math.PI * this.Rayon;
        }

        public override string ToString()
        {
            return "Cercle de rayon = " + this.Rayon + "\n" + base.ToString();
        }
    }
}