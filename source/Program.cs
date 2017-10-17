using System;

namespace SuperMarioImWorkshop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mario = SuperMarioSpiel.StarteMitDreiLeben().StarteAlsKleinerMario();
            mario
                .WirdVonGegnerGetroffen()
                .FindetFeuerblume()
                .Schießen(Console.WriteLine);

            Console.ReadLine();
        }
    }
}