using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lin = Console.ReadLine();
            var maxAvion = int.Parse(Console.ReadLine());
            string line;
            var list = new List<(int piste, int heure)>();
            while ((line = Console.ReadLine()) != null)
            {
                var group1 = line.Split(' ');
                var group2 = group1[0].Split(':');
                list.Add((int.Parse(group1[1]), int.Parse(group2[0]) * 60 + int.Parse(group2[1])));
            }

            foreach (var avion in list)
            {
                if (list.Where(a => a.piste == avion.piste)
                        .Any(a => Math.Abs(a.heure - avion.heure) <= 6 && a.heure != avion.heure))
                {
                    Console.WriteLine("COLLISION");
                    return;
                }
            }

            foreach (var piste in list.GroupBy(l => l.piste))
            {
                foreach (var avions in piste)
                {
                    if (piste.Where(a => avions.heure - a.heure <= 45 && a.heure <= avions.heure).Count() > maxAvion)
                    {
                        Console.WriteLine("COLLISION");
                        return;
                    }
                }
            }
            //résultat
            Console.WriteLine("OK");
        }
    }
}
