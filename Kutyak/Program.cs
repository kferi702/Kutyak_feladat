using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class Program
    {
        public static List<KutyaNevek> nevek = new List<KutyaNevek>();
        public static List<KutyaFajtak> fajtak = new List<KutyaFajtak>();
        public static List<Kutya> kutya = new List<Kutya>();
        public static void beolv_k(string f_neve)
        {
            FileStream f = new FileStream(@f_neve, FileMode.Open);
            StreamReader r = new StreamReader(f, Encoding.Default);
            r.ReadLine();
            while (!r.EndOfStream)
            {
                string[] s = r.ReadLine().Split(';');
                if (f_neve == "KutyaNevek.csv")
                    nevek.Add(new KutyaNevek(s[0], s[1]));
                if (f_neve == "KutyaFajtak.csv")
                    fajtak.Add(new KutyaFajtak(s[0], s[1], s[2]));
                if (f_neve == "Kutyak.csv")
                    kutya.Add(new Kutya(s[0], s[1], s[2], s[3], s[4]));
            }
            r.Close();
            f.Close();
        }
        public static void f3()
        {
            Console.WriteLine("3. feladat: Kutyanevek száma: " + nevek.Count);
        }
        public static void f6()
        {
            Console.Write("6. feladat: Kutyák átlagéletkora: ");
            double sum = 0;
            foreach (Kutya k in kutya)
                sum += k.kor;
            sum = sum / kutya.Count;
            Console.WriteLine(Math.Round(sum, 2));
        }
        public static void f7()
        {
            Console.Write("7. feladat: A legídősebb kutya neve és fajtája: ");
            int max = int.MinValue;
            int fajId = 0;
            int nevId = 0;
            foreach (Kutya k in kutya)
                if (k.kor > max)
                {
                    max = k.kor;
                    fajId = k.f_id;
                    nevId = k.n_id;
                }

            Console.WriteLine(nevek.ElementAt(nevId - 1).nev + ", " + fajtak.ElementAt(fajId - 1).magyar + " " + max);
        }
        public static void f8()
        {
            Console.WriteLine("8. feladat: Január 10.-én vizsgált kutya fajták ");
            Dictionary<string, int> vizsgalt = new Dictionary<string, int>();
            for (int i = 1; i < kutya.Count; i++)
            {
                if (kutya.ElementAt(i).orvos == "2018.01.10")
                {
                    if (!vizsgalt.ContainsKey(fajtak.ElementAt(kutya.ElementAt(i).f_id-1).magyar))
                        vizsgalt.Add(fajtak.ElementAt(kutya.ElementAt(i).f_id-1).magyar, 1);
                    else
                        vizsgalt[fajtak.ElementAt(kutya.ElementAt(i).f_id-1).magyar]++;
                }
            }
            foreach (var v in vizsgalt)
            {
                Console.WriteLine("\t"+v.Key + ": " + v.Value + " kutya");
            }
        }
        public static void f9()
        {
            Console.Write("9. feladat: Legjobban leterhelt nap: ");
            Dictionary<string, int> vizsgalt = new Dictionary<string, int>();
            foreach(Kutya k in kutya)
            {
                if (!vizsgalt.ContainsKey(k.orvos))
                    vizsgalt.Add(k.orvos, 1);
                else
                    vizsgalt[k.orvos]++;
            }
            int max = int.MinValue;
            string s = "";
            foreach (var v in vizsgalt)
                if (v.Value > max)
                {
                    max = v.Value;
                    s = v.Key + ": " + v.Value + " kutya";
                }
            Console.WriteLine(s);
        }
        public static void kiiras()
        {
            Console.WriteLine("10. feladat: névsattisztika.txt");
            Dictionary<string, int> kiir = new Dictionary<string, int>();
            foreach(Kutya k in kutya)
            {
                if (!kiir.ContainsKey(nevek.ElementAt(k.n_id - 1).nev))
                    kiir.Add(nevek.ElementAt(k.n_id - 1).nev, 1);
                else
                    kiir[nevek.ElementAt(k.n_id - 1).nev]++;
            }
            var sortKiir = from e in kiir orderby e.Value descending select e;
            FileStream f = new FileStream(@"Névstatisztika.txt", FileMode.OpenOrCreate);
            StreamWriter s = new StreamWriter(f, Encoding.UTF8);
            foreach(var sk in sortKiir)
            {
                s.WriteLine(sk.Key + ";" + sk.Value);
            }
            s.Close();
            f.Close();
        }
        static void Main(string[] args)
        {
            beolv_k("KutyaNevek.csv");
            f3();
            beolv_k("KutyaFajtak.csv");
            beolv_k("Kutyak.csv");
            f6();
            f7();
            f8();
            f9();
            kiiras();
            Console.ReadKey();
        }

    }
}
