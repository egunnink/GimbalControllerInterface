using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimbalInterface
{
    public static class CoordinateSystems
    {
        // adapted from: http://danceswithcode.net/engineeringnotes/geodetic_to_ecef/geodetic_to_ecef.html

        private const double A  = 6378137.0;            // WGS-84 semi-major axis
        private const double E2 = 6.6943799901377997e-3;// WGS-84 first eccentricity squared
        private const double A1 = 4.2697672707157535e+4;// A1 = A*e2
        private const double A2 = 1.8230912546075455e+9;// A2 = A1*A1
        private const double A3 = 1.4291722289812413e+2;// A3 = A1*e2/2
        private const double A4 = 4.5577281365188637e+9;// A4 = 2.5*A2
        private const double A5 = 4.2840589930055659e+4;// A5 = A1+A3
        private const double A6 = 9.9330562000986220e-1;// A6 = 1-e2

        /// <summary>
        /// converst ECEF xyz coordinates in meters to LLA coordinates in radians
        /// </summary>
        /// <param name="x">ECEF X m</param>
        /// <param name="y">ECEF Y m</param>
        /// <param name="z">ECEF Z m</param>
        /// <param name="lat">Lat rad</param>
        /// <param name="lon">Lon rad</param>
        /// <param name="alt">Alt m</param>
        public static void ECEFToLLA(double x, double y, double z, out double lat, out double lon, out double alt)
        {
            double ZP = Math.Abs(z);
            double WSQ = x * x + y * y;
            double W = Math.Sqrt(WSQ);
            double RSQ = WSQ + z * z;
            double R = Math.Sqrt(RSQ);

            lon = Math.Atan2(y, x);// final lon

            double SSQ = z * z / RSQ;
            double CSQ = WSQ / RSQ;
            double U = A2 / R;
            double V = A3 - A4 / R;

            double SS = 1.0, C = 1.0, S = 1.0;// these gets reassigned later
            if(CSQ > 0.3)
            {
                S = (ZP / R) * (1.0 + CSQ * (A1 + U + SSQ * V) / R);
                lat = Math.Asin(S);// first lat guess
                SS = S * S;
                C = Math.Sqrt(1.0 - SS);
            }
            else
            {
                C = (W / R) * (1.0 - SSQ * (A5 - U - CSQ * V) / R);
                lat = Math.Acos(C);// first lat guess
                SS = 1.0 - C * C;
                S = Math.Sqrt(SS);
            }

            double G = 1.0 - E2 * SS;
            double RG = A / Math.Sqrt(G);
            double RF = A6 / RG;
            U = W - RG * C;
            V = ZP - RF * S;

            double F = C * U + S * V;
            double M = C * V - S * U;
            double P = M / (RF / G + F);

            lat += P;// second lat guess
            alt = F + M * P / 2.0;
            if(z < 0.0)
            {
                lat = -lat;// final lat
            }
        }

        /// <summary>
        /// The same as the function above but it will convert the outputed LLA coordiantes from radians to degrees
        /// </summary>
        /// <param name="x">ECEF X m</param>
        /// <param name="y">ECEF Y m</param>
        /// <param name="z">ECEF Z m</param>
        /// <param name="latDeg">Lat deg</param>
        /// <param name="lonDeg">Lon deg</param>
        /// <param name="alt">Alt m</param>
        public static void ECEFToLLADeg(double x, double y, double z, out double latDeg, out double lonDeg, out double alt)
        {
            ECEFToLLA(x, y, z, out latDeg, out lonDeg, out alt);
            // convert the coordinates before we exit
            latDeg *= Units.RAD_TO_DEG;
            lonDeg *= Units.RAD_TO_DEG;
        }

        /// <summary>
        /// Converts LLA coordinates in radians to ECEF coordinates in meters
        /// </summary>
        /// <param name="lat">Lat rad</param>
        /// <param name="lon">Lon rad</param>
        /// <param name="alt">Alt m</param>
        /// <param name="x">ECEF X m</param>
        /// <param name="y">ECEF Y m</param>
        /// <param name="z">ECEF Z m</param>
        public static void LLAToECEF(double lat, double lon, double alt, out double x, out double y, out double z)
        {
            double SLAT = Math.Sin(lat);
            double SLON = Math.Sin(lon);
            double CLAT = Math.Cos(lat);
            double CLON = Math.Cos(lon);
            double N = A / Math.Sqrt(1.0 - E2 * SLAT * SLAT);
            x = (N + alt) * CLAT * CLON;
            y = (N + alt) * CLAT * SLON;
            z = (N * (1.0 - E2) + alt) * SLAT;
        }

        /// <summary>
        /// The same as the function above but it will convert the inputed LLA coordiantes from degrees to radians before calling the function
        /// </summary>
        /// <param name="lat">Lat deg</param>
        /// <param name="lon">Lon deg</param>
        /// <param name="alt">Alt m</param>
        /// <param name="x">ECEF X m</param>
        /// <param name="y">ECEF Y m</param>
        /// <param name="z">ECEF Z m</param>
        public static void LLAToECEFDeg(double latDeg, double lonDeg, double alt, out double x, out double y, out double z)
        {
            LLAToECEF(latDeg * Units.DEG_TO_RAD, lonDeg * Units.DEG_TO_RAD, alt, out x, out y, out z);
        }
    }
}
