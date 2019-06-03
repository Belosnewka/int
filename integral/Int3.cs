using System;
namespace integral
{
    public class Integral3
    {
        public static double Int3(Function f, double[] b, double[] a, int n)
        {
            double hx = (b[0] - a[0]) / n, hy = (b[1] - a[1]) / n, hz = (b[2] - a[2]) / n, S = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                    {
                        double xi = a[0] + hx / 2 + i * hx;
                        double yj = a[1] + hy / 2 + j * hy;
                        double zk = a[2] + hz / 2 + k * hz;
                        S += hx * hy * hz * f(xi, yj, zk);
                    }
            return S;
        }
    }
}
