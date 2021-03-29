using System;
using System.Collections.Generic;

namespace HWDay15_15a
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "MITXAFEC";
            var wordBank = new List<string> { "MTXAFEC", "AC", "TAEC", "MTAFEC", "TAC", "MITXAFEC", "A", "MTAEC", "ITXAFEC" };
            var p = new ShrinkableWord(word, wordBank);
            p.PrintResult(wordBank, word);
        }
    }
    class ShrinkableWord
    {
        string _word;
        List<string> _wordBank;

        public ShrinkableWord(string word, List<string> wordBank)
        {
            _word = word;
            _wordBank = wordBank;
        }
        public void PrintResult(List<string> wordBank, string word)
        {
            var result = new Stack<string>();
            if (IsTheWordShrinkable(wordBank, word, result))
            {
                Console.Write($"Yes, {word} is shrinkable.");
            }
            else
            {
                Console.Write($"No, {word} is unshrinkable.");
            }
        }
        public bool IsTheWordShrinkable(List<string> wordBank, string word, Stack<string> result)
        {
            if (word.Length == 0)
        {
            return true;
            }
            for (int i = 0; i < word.Length; i++)
            {
                if (wordBank.Contains(word))
                {
                    result.Push(word[i].ToString());
                    if (IsTheWordShrinkable(wordBank, word.Remove(i, 1), result))
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

