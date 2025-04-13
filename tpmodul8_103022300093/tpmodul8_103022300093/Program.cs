using System;
class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.Load();

        Console.WriteLine($"Satuan suhu saat ini adalah {config.satuan_suhu}");
        Console.Write("Apakah ingin mengganti satuan suhu? (y/n): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu sekarang menjadi {config.satuan_suhu}");
        }

        Console.WriteLine($"\nBerapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuNormal = false;
        if (config.satuan_suhu == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        if (suhuNormal && hariDemam <= config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}