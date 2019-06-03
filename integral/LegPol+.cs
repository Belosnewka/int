using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integral
{
    public class L_Pol
    {
        public static double koef(double y, double z, int n) // l(l+1) ссобственные значения, полином сразу на них делится
        {
            int l=1, m=0, s=3;
            while (n >= s)
            {
                s += 3 + 2 * l;
                l++;
            }
            m = n - s + (3 + 2 * (l - 2)) + 2;
            if (m == 0) return Pol(z, l) / l / (l + 1);
            else if (m <= l) return Math.Cos(m * y) * PolPri(z, l, m) / l / (l + 1);
            else return Math.Cos((m - l) * y) * PolPri(z, l, m - l) / l / (l + 1);
        }
        public static double SF(double y, double z, int n)
        {
            int l = 1, m = 0, s = 3;
            while (n >= s)
            {
                s += 3 + 2 * l;
                l++;
            }
            m = n - s + (3 + 2 * (l - 2)) + 2;
            if (m == 0) return Pol(z, l) / l / (l + 1);
            else if (m <= l) return Math.Cos(m * y) * PolPri(z, l, m);
            else return Math.Cos((m - l) * y) * PolPri(z, l, m - l);
        }
        public static double PolPri(double z, double l, int m)
        {
            if (m == 0) return Pol(z, l);
            if (m == 1) return dPol(z, l);
            if (l == 1 && m > 1) return 0;
            if (l == 0 && m > 0) return 0;
            else return (2 * l - 1) * PolPri(z, l - 1, m - 1) + PolPri(z, l-2, m);
        }
        public static double Pol(double z, double l)
        {
            if (l == 0) return 1;
            if (l == 1) return Math.Cos(z);
            else return (2 * l + 1) / (l + 1) * Math.Cos(z) * Pol(z, l - 1) - l / (l + 1) * Pol(z, l - 2);
        }
        public static double dPol(double z, double l)
        {
            if (l == 1) return 1;
            if (l == 2) return 3 * Math.Cos(z);
            else return l * Pol(z, l - 1) + Math.Cos(z) * dPol(z, l - 1);
        }
    }
}
