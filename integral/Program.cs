using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integral
{
    public delegate double Function(double x, double y, double z);
    class Program
    {
        static int n=50;
        static void Main(string[] args)
        {
            double[] beg = { 0, 0, 0 };
            double[] end = { 1, 2 * Math.PI, Math.PI };
            double p1 = 0, p2 = 0, p3 = 0;
            Function F = new Function(G);
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = Int3_in.Int3(F, end, beg, 10, i);
            }
            double m = 0, l;
            for (int i = 0; i < 500; i++) //подразумеваем точки в ск
            {
                p1 += 0.001;
                p2 += Math.PI/500; p3 += Math.PI/1000;
                l = Sum(x, n, p1, p2, p3) - K(p1 * Math.Sin(p3) * Math.Cos(p2), p1 * Math.Sin(p3) * Math.Sin(p2), p1 * Math.Cos(p3));
                if (l*l > m*m) m = l;
            }
            Console.WriteLine(m);
            Console.ReadKey();
        }
        public static double G(double x, double y, double z)//неоднородная часть в дк, решениие подразумевает именно такой вид
        {
            return 6;
        }
        static double K(double x, double y, double z)// решение в дк
        {
            return x*x + y*y + z*z;
        }
        static double Sum(double []m, int n, double x, double y, double z)
        {
            double S = 0;
            for (int i=0; i<n; i++)
            {
                S += m[i] * L_Pol.SF(y, z, i);
            }Console.WriteLine(S);
            return S;
        }
    }
}
