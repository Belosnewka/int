using System;
namespace integral
{
    public class Integral3
    {
        int number;
        int ch;
	    public Integral3(int n)
	    {
            number = n;
            ch = 0;
        }
        static void main()
        {
            Function Fun = new Function(F);
            Function UndInt = new Function(G);
            double[] beg = { 0, 0, 0 };
            double[] end = { 1, 2 * Math.PI, Math.PI };
            int n = 10;
            Console.Write("Интеграл = {0}", Int3(Fun, UndInt, end, beg, n));
            Console.ReadKey();
        }
        public delegate double Function(double x, double y, double z);
        public static double F(double x, double y, double z)//полином * якобиан (собственные ф-ции и якобиан)
        {
            return x * x * Math.Sin(z)*;
        }
        public static double G(double x, double y, double z)//подинтегральная функция
        {
            return x * y * z;
        }
        public static double Int3(Function f, Function g, double[] b, double[] a, int n)
        {
            double hx = (b[0] - a[0]) / n, hy = (b[1] - a[1]) / n, hz = (b[2] - a[2]) / n, S = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                    {
                        double xi = a[0] + hx / 2 + i * hx;
                        double yj = a[1] + hy / 2 + j * hy;
                        double zk = a[2] + hz / 2 + k * hz;
                        S += hx * hy * hz * f(xi, yj, zk) * g(xi * Math.Sin(zk) * Math.Cos(yj), xi * Math.Sin(zk) * Math.Sin(yj), xi * Math.Cos(zk));
                    }
            return S;
        }
    }
}
