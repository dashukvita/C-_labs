using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionatyTest
{
    class EngRusDic
    {
        private readonly Dictionary <string, HashSet<string>> dic = new Dictionary<string, HashSet<string>>();

        public EngRusDic() {}

        private Dictionary<string, HashSet<string>> Dic
        {
            get => dic;
        }

        private bool WordsAreNormal(string input_word, string input_translation)
        {
            bool wordIsNormal = true;
            if (input_word == "" || input_translation == "")
            {
                wordIsNormal = false;
            }
            else
            {
                for (int i = 0; i < input_word.Length; i++)
                {
                    if (!Char.IsLetter(input_word[i]))
                    {
                        wordIsNormal = false;
                    }
                }

                if(wordIsNormal)
                {
                    for (int i = 0; i < input_translation.Length; i++)
                    {
                        if (!Char.IsLetter(input_translation[i]))
                        {
                            wordIsNormal = false;
                        }
                    }
                }

                if(wordIsNormal)
                {
                    if ((input_word[0] >= 1072 && input_word[0] <= 1104))
                    {
                        for (int i = 1; i < input_word.Length; i++)
                        {
                            if (input_word[i] < 1072 || input_word[i] > 1104)
                            {
                                wordIsNormal = false;
                            }
                        }
                    }
                }

                if (wordIsNormal)
                {
                    if ((input_translation[0] >= 1072 && input_translation[0] <= 1104))
                    {
                        for (int i = 1; i < input_translation.Length; i++)
                        {
                            if (input_translation[i] < 1072 || input_translation[i] > 1104)
                            {
                                wordIsNormal = false;
                            }
                        }
                    }
                }

                if (wordIsNormal)
                {
                    if ((input_word[0] >= 97 && input_word[0] <= 123))
                    {
                        for (int i = 1; i < input_word.Length; i++)
                        {
                            if (input_word[i] < 97 || input_word[i] > 123)
                            {
                                wordIsNormal = false;
                            }
                        }
                    }
                }

                if (wordIsNormal)
                {
                    if ((input_translation[0] >= 97 && input_translation[0] <= 123))
                    {
                        for (int i = 1; i < input_translation.Length; i++)
                        {
                            if (input_translation[i] < 97 || input_translation[i] > 123)
                            {
                                wordIsNormal = false;
                            }
                        }
                    }
                }

                if (wordIsNormal)
                {
                    if (wordIsNormal && (((input_word[0] >= 1072 && input_word[0] <= 1104) && (input_translation[0] >= 97 && input_translation[0] <= 123)) ||
                     (input_word[0] >= 97 && input_word[0] <= 123) && (input_translation[0] >= 1072 && input_translation[0] <= 1104)))
                    {
                        return true;
                    }
                    else
                    {
                        wordIsNormal = false;
                    }
                }
            }
            if (!wordIsNormal) Console.WriteLine("Неверный формат слова! Слово не было добавлено в словарь.");
            return wordIsNormal;
        }

        public void AddWord(string word, string translation)
        {
            string input_word = word.Trim();
            input_word = input_word.ToLower();

            string input_translation = translation.Trim();
            input_translation = input_translation.ToLower();

            if (WordsAreNormal(input_word, input_translation))
            {
                if (!dic.ContainsKey(input_word))
                {
                    dic.Add(input_word, new HashSet<string>());
                    dic[input_word].Add(input_translation);

                    dic.Add(input_translation, new HashSet<string>());
                    dic[input_translation].Add(input_word);
                }
                else if (!dic[input_word].Contains(input_translation))
                {
                    dic[input_word].Add(input_translation);
                    dic.Add(input_translation, new HashSet<string>());
                    dic[input_translation].Add(input_word);
                }
                else
                {
                    Console.WriteLine("Словарь уже содержит слово и перевод.");
                }
            }
        }

        public HashSet<string> GetTranslation(string word)
        {
            if (dic.ContainsKey(word))
            {
                HashSet<string> translation_list = new HashSet<string>();
                foreach (string val in dic[word])
                {
                    translation_list.Add(val);
                    Console.WriteLine(val);
                }
                return translation_list;
            }
            else
            {
                Console.WriteLine("Словарь не содержит слово - '{0}'.", word);
                return null;
            }
        }

        public void PrintDic()
        {
            foreach (KeyValuePair<string, HashSet<string>> kvPair in dic)
            {
                foreach (string str in kvPair.Value)
                {
                    Console.WriteLine(kvPair.Key + " " + str);
                }
            }

        }
    }
}
