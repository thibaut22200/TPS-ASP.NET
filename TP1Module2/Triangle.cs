namespace TP1Module2
{
    public class Triangle : Forme
    {
        internal int A;
        internal int B;
        internal int C;

        public override double aire()
        {
            double p = this.perimetre() / 2;
            return System.Math.Sqrt(p * (p - this.A) * (p - this.B) * (p - this.C));
        }

        public override double perimetre()
        {
            return A + B + C;
        }

        public override string ToString()
        {
            return "Triangle de côté A = " + this.A + ", B = " + this.B + ", C = " + this.C + "\n" + base.ToString();
        }
    }
}