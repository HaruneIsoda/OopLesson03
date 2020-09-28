using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter3 {
    class Program {
        static void Main(string[] args) {

            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            Console.WriteLine("\n*********問題3-1-1*******************");
            #region 問題3-1-1
            var exists = numbers.Exists(n => (n % 8 == 0) || (n % 9 == 0));
            Console.Write("8か9で割り切れる数が");
            if(exists) {
                Console.Write("存在しています");
            } else {
                Console.Write("存在していません");
            }


            #endregion

            Console.WriteLine("\n*********問題3-1-2*******************");
            #region 問題3-1-2
            Console.Write("各要素を2.0で割った数…");
            numbers.ForEach(n => Console.Write($"{n / 2.0} "));
            #endregion

            Console.WriteLine("\n*********問題3-1-3*******************");
            #region 問題3-1-3
            var query = numbers.Where(n => n > 50);
            Console.Write("値が50以上の要素…");
            foreach(var item in query) {
                Console.Write($"{item} ");
            }
            #endregion

            Console.WriteLine("\n*********問題3-1-4*******************");
            #region 問題3-1-4
            List<int> intList = numbers.Select(n => n * 2).ToList();
            Console.Write("2倍の数…");
            foreach(var item in intList) {
                Console.Write($"{item} ");
            }
            #endregion

           var names = new List<string> {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Cangerra","Hong Kong"
            };

            Console.WriteLine("\n\n\n*********問題3-2-1*******************");
            #region 問題3-2-1改
            do {
                Console.Write("都市名を入力してください：");
                var line = Console.ReadLine();
                if(string.IsNullOrEmpty(line)) {
                    break;
                }
                var findIndex = names.FindIndex(s => s == line);
                if(findIndex == -1) {
                    Console.WriteLine("見つかりませんでした。");
                } else {
                    Console.WriteLine($"見つかった場所は{findIndex + 1}番目でした。");
                }
            } while(true);  //無限ループ

            Console.Write("終わり");
            #endregion

            Console.WriteLine("\n*********問題3-2-2*******************");
            #region 問題3-2-2
            var countO = names.Count(c => c.Contains("o"));
            Console.Write($"「o」が含まれている都市は{countO}個あります。");
            #endregion

            Console.WriteLine("\n*********問題3-2-3*******************");
            #region 問題3-2-3
            var inculudeOArray = names.Where(s => s.Contains("o")).ToArray();
            Console.Write("「o」が含まれている都市名は…");
            foreach(var item in inculudeOArray) {
                Console.Write($"{item}, ");
            }
            #endregion

            Console.WriteLine("\n*********問題3-2-4*******************");
            #region 問題3-2-4
            Console.Write("「B」で始まる都市名の文字数は…");
            names.Where(s => s.First() == 'B').Select(s => s.Length).ToList().ForEach(s => Console.Write($"{s}文字, "));
            #endregion


 

        }
    }
}
