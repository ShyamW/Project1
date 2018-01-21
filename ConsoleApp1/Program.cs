using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        [System.STAThread]
        static void Main(string[] args)
        {   
            // read clipboard text
            string a = Clipboard.GetText(); 
            
            // remove punctuation and spaces from words
            var rawWords = Regex.Replace(a, "[!.,;:?\n\r]", " ");
            List<string> words = rawWords.Split(" ".ToCharArray()).ToList();
            words = words.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            // lowercase all the words
            words = words.ConvertAll(d => d.ToLower());

            // drop duplicate words and sort alphabetically
            words = words.Distinct().ToList();
            words = words.OrderBy(q => q).ToList();

            // print to screen
            words.ForEach(Console.WriteLine);

            Console.Read();
        }
    }
}
