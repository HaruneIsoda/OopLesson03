using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class Program {
        static void Main(string[] args) {

            var text = "Cozy lummox gives smart squid who asks for job pen";
            //Exercis1_1(text);
            //Exercis1_2(text);


            // コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            // Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            //問題7-2-3
            //Countプロパティを呼び出して数を出力させる
            Console.WriteLine($"登録されている用語の数：{abbrs.Count}");
            //Removeメソッドを呼び出して要素を削除する
            Console.Write("削除する省略語を入力してください。：");
            if(abbrs.Remove(Console.ReadLine())) {
                Console.WriteLine("削除しました。");
            } else {
                Console.WriteLine("削除する省略語が見つかりませんでした。");
            }
            Console.WriteLine();
            

            // インデクサの利用例
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach(var name in names) {
                var fullname = abbrs[name];
                if(fullname == null)
                    Console.WriteLine("{0}は見つかりません", name);
                else
                    Console.WriteLine("{0}={1}", name, fullname);
            }
            Console.WriteLine();

            // ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if(abbreviation == null)
                Console.WriteLine("{0} は見つかりません", japanese);
            else
                Console.WriteLine("「{0}」の略語は {1} です", japanese, abbreviation);
            Console.WriteLine();

            // FindAllメソッドの利用例
            foreach(var item in abbrs.FindAll("国際")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            Console.WriteLine();

            //7-2-4
            //Keyが三文字のものだけを表示
            abbrs.out3LettersKey();
        }

        //1-1
        public static void Exercis1_1(string text) {
            var dict = new Dictionary<char, int>();
            //格納
            foreach(var ch in text) {
                char upc = char.ToUpper(ch);
                if('A' <= upc && upc <= 'Z') {
                    if(dict.ContainsKey(upc)) {
                        dict[upc]++;
                    } else {
                        dict[upc] = 1;
                    }
                }
            }

            //出力            
            foreach(var item in dict.OrderBy(x => x.Key)) {
                Console.WriteLine($"'{item.Key}'：{item.Value}");
            }
        }

        //1-2
        public static void Exercis1_2(string text) {
            var sDict = new SortedDictionary<char, int>();
            var chers = text.ToUpper().ToArray();
            //格納
            foreach(var ch in chers) {
                if('A' <= ch && ch <= 'Z') {
                    if(sDict.ContainsKey(ch)) {
                        sDict[ch] += 1;
                    } else {
                        sDict[ch] = 1;
                    }
                }
            }

            //出力            
            foreach(var item in sDict) {
                Console.WriteLine($"'{item.Key}'：{item.Value}");
            }
        }

        //2-1
        public static void Exercis2_1() {

        }
    }
}
