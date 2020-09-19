using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionatyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EngRusDic dic = new EngRusDic();
            Console.WriteLine("Проверка на неверный формат пары 'слово-перевод':");
            dic.AddWord("hello", "hello");
            dic.AddWord("привет", "привет");
            dic.AddWord("привет", "");
            dic.AddWord("", "привет");
            dic.AddWord("", "");
            dic.AddWord("пр3ивет", "abs");
            dic.AddWord("привет", "abs4");
            dic.AddWord("прdвет", "abs");
            dic.AddWord("Sрdвет", "abs");
            dic.AddWord("привет", "absв");

            Console.WriteLine("\nПроверка на чувствительность к регистру:");
            dic.AddWord("hello", "привет");
            dic.AddWord("Hello", "привет");


            Console.WriteLine("\nПроверка на дубликат:");
            dic.AddWord(" плохой", "Bad ");
            dic.AddWord(" плохой", "Bad ");

            Console.WriteLine("\nДобавим слова в словарь и распечатаем его содержимое:");
            dic.AddWord("hello", "приветствие");
            dic.AddWord("пока", "Goodbye");
            dic.AddWord(" плохой", "poor");
            dic.PrintDic();

            Console.WriteLine();
            Console.WriteLine("Перевод слова '{0}':", "hello");
            dic.GetTranslation("hello");
            Console.WriteLine("Перевод слова '{0}':", "пока");
            dic.GetTranslation("пока");
            Console.WriteLine("Перевод слова '{0}':", "плохой");
            dic.GetTranslation("плохой");
            dic.GetTranslation("зеленый");

            Console.ReadLine();
        }
    }
}
