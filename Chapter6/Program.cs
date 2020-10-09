using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {

            #region 6-1
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };
            //6-1-1
            Console.WriteLine($"最大値…{numbers.Max()}");

            //6-1-2
            Console.Write("最後から2つの要素…");
            int pos = numbers.Length - 2;
            foreach(var number in numbers.Skip(pos)) {
                Console.Write(number + " ");
            }

            //6-1-3
            Console.Write("\n文字列に変換…");
            numbers.Select(x => x.ToString("000")).ToList().ForEach(x => Console.Write(x + " "));

            //6-1-4
            Console.Write("\n数の小さい数値を三つ…");
            numbers.Distinct().OrderBy(x => x).Take(3).ToList().ForEach(x => Console.Write(x + " "));

            //6-1-5
            Console.Write("\n10より大きい数がいくつあるか…");
            Console.WriteLine(numbers.Distinct().Count(x => x > 10));

            #endregion

            Console.WriteLine("***************************************************");

            #region 6-2
            var books = new List<Book> {
                new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };


            //6-2-1
            Console.Write($"ワンダフル・C#ライフ…");
            foreach(var book in books.Where(x => x.Title == "ワンダフル・C#ライフ")) {
                Console.WriteLine($"{book.Price}円 {book.Pages}ページ");
            }

            //6-2-2
            Console.Write("\n「C#」が含まれている書籍数…");
            Console.WriteLine(books.Count(x => x.Title.Contains("C#")) + "冊");

            //6-2-3
            Console.Write("\n「C#」が含まれている書籍の平均ページ…");
            Console.WriteLine(books.Where(x => x.Title.Contains("C#")).Average(x => x.Pages) + "ページ");

            //6-2-4
            Console.Write("\n価格が4000円以上の最初の本…");
            Console.WriteLine(books.FirstOrDefault(x => x.Price >= 4000).Title);

            //6-2-5
            Console.Write("\n価格が4000円未満で最大のページ数…");
            Console.WriteLine(books.Where(x => x.Price < 4000).Max(x => x.Pages) + "ページ");

            //6-2-6
            Console.WriteLine("\n400ページ以上の書籍を価格の高い順に…");
            foreach(var book in books.Where(x => x.Pages >= 400).OrderByDescending(x => x.Price)) {
                Console.WriteLine($"{book.Title}：{book.Price}円　");
            }

            //6-2-7
            Console.WriteLine("\n\n「C#」が含まれていて500ページ以下の本…");
            foreach(var book in books.Where(x => x.Title.Contains("C#") && x.Pages <= 500)) {
                Console.WriteLine($"{book.Title}　");
            } 
            #endregion
        }
    }
}