using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer
{
    class WordGenerator : IWordGenerator
    {
        const int n = 15;
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string RandomWord { get; set; } = GenerateWord();

        private static string GenerateWord()
        {

            string word = "";

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < n; i++)
            {
                int num = rand.Next(0, letters.Length - 1);
                word += letters[num];
            }
            return word;
        }

        string IWordGenerator.GenerateWord()
        {
            return GenerateWord();
        }
    }
}
