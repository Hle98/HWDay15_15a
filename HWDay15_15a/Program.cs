using System;
using System.Collections.Generic;

namespace HWDay15_15a
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "MITXAFEC";
            var wordbank = new List<string> { "MTXAFEC", "AC", "TAEC", "MTAFEC", "TAC", "MITXAFEC", "A", "MTAEC", "ITXAFEC" };
            var p = new ShrinkableWord(word, wordbank);
            p.PrintResult(wordbank, word);
        }
        class ShrinkableWord
        {
            string _word;
            List<string> _wordbank;

            public ShrinkableWord(string word, List<string> wordbank)
            {
                _word = word;
                _wordbank = wordbank;
            }
            public void PrintResult(List<string> wordbank, string word)
            {
                var result = new Stack<string>();
                if (IsTheWordShrinkable(wordbank, word, result))
                {
                    Console.Write($"Yes, {word} is shrinkable.");
                }
                else
                {
                    Console.Write($"No, {word} is unshrinkable.");
                }
            }
            public bool IsTheWordShrinkable(List<string> wordbank, string word, Stack<string> result)
            {
                if (word.Length == 0)
                {
                    return true;
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (wordbank.Contains(word))
                    {
                        result.Push(word[i].ToString());
                        if (IsTheWordShrinkable(wordbank, word.Remove(i, 1), result))
                        {
                            return true;
                        }
                        result.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }
    }
}
