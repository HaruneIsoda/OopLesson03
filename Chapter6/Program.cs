using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {
            //整数の例
            var numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 12, 28, 19, 30, 24 };

            numbers.Distinct().Select(n => n.ToString("0000")).ToList().ForEach(s => Console.Write(s + " "));

            Console.WriteLine("\n***************************************************");
            var strings = numbers.Distinct().ToArray();
            foreach(var str in strings) {
                Console.Write(str + " ");
            }

            Console.WriteLine("\n***************************************************");
            numbers.Distinct().OrderBy(n => n).ToList().ForEach(n => Console.Write(n + " "));

            //文字列の例
            Console.WriteLine("\n***************************************************");
            var words = new List<string> { "Microsoht", "Apple", "Google", "Oracle", "Facebook", };

            var lower = words.Select(s => s.ToLower()).ToArray();


            //オブジェクトの例
            var books = Books.GetBooks();
            //タイトルリスト
            var titles = books.Select(x => x.Title).ToArray();
            foreach(var title in titles) {
                Console.Write(title + " ");
            }

            Console.WriteLine("\n***************************************************");
            //ページの多い順に並べ替え
            Console.WriteLine("ページの多い順…");
            books.OrderByDescending(x => x.Pages).Take(3).ToList().ForEach(x => Console.Write($"{x.Title}:{x.Pages}p　"));

            Console.WriteLine("\n金額の高い順…");
            books.OrderByDescending(x => x.Price).Take(3).ToList().ForEach(x => Console.Write($"{x.Title}:{x.Price}円　"));

        }
    }
}
