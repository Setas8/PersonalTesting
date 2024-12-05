using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Ask data
        Console.Write("Number of participants: ");
        int participantsNum = int.Parse(Console.ReadLine());

        List<string> participants = new List<string>();

        for (int i = 0; i < participantsNum; i++)
        {
            Console.Write($"Name participant {i + 1}: ");
            participants.Add(Console.ReadLine());
        }
        //Shuffle
        Random rng = new Random();
        int n = participants.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = participants[k];
            participants[k] = participants[n];
            participants[n] = value;
        }

        //Assign secret santa
        Dictionary<string, string> secretSantas = new Dictionary<string, string>();

        for (int i = 0; i < participantsNum; i++)
        {
            string secretSanta = participants[(i + 1) % participantsNum];
            secretSantas[participants[i]] = secretSanta;
        }

        Console.WriteLine("\nSECRET SANTA RESULT");
        foreach (var pair in secretSantas)
        {
            Console.WriteLine($"{pair.Key} --> {pair.Value}");
        }
    }
}
