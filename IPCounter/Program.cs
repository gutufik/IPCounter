using System;

namespace IPCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ip1 = Console.ReadLine();
                var ip2 = Console.ReadLine();

                var ip1Parts = ip1.Split('.');
                var ip2Parts = ip2.Split('.');

                foreach (var ip in ip1Parts)
                {
                    if (int.Parse(ip) < 0 || int.Parse(ip) > 255)
                        throw new Exception();
                }
                foreach (var ip in ip2Parts)
                {
                    if (int.Parse(ip) < 0 || int.Parse(ip) > 255)
                        throw new Exception();
                }

                var ip1bits = (int.Parse(ip1Parts[0]) * Math.Pow(256,3)) + (int.Parse(ip1Parts[1]) * Math.Pow(256,2)) + (int.Parse(ip1Parts[2]) * 256) + int.Parse(ip1Parts[3]);
                var ip2bits = (int.Parse(ip2Parts[0]) * Math.Pow(256,3)) + (int.Parse(ip2Parts[1]) * Math.Pow(256,2)) + (int.Parse(ip2Parts[2]) * 256) + int.Parse(ip2Parts[3]);


                Console.WriteLine(Math.Abs(ip2bits - ip1bits));
            }
            catch
            {
                Console.WriteLine("Incorrect ip format");
            }
        }
    }
}
