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

            Exercis1_1(text);

            //Exercis1_2(text);

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


    }
}
