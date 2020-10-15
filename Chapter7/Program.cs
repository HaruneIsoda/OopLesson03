using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class Program {
        static void Main(string[] args) {

            var dict = new Dictionary<string, List<string>>();
            var num = "1";

            Console.WriteLine("**********************\n* 辞書登録プログラム *\n**********************");
            
            while(num != "3") {
                Console.WriteLine("１．登録　２．内容を表示　３．終了");
                Console.Write(">");
                num = Console.ReadLine();

                if(num == "1") {
                    Console.Write("KEYを入力：");
                    var key = Console.ReadLine();
                    Console.Write("VALUEを入力：");
                    var value = Console.ReadLine();

                    if(dict.ContainsKey(key)) {
                        dict[key].Add(value);
                    } else {
                        dict[key] = new List<string> { value };
                    }
                }else if(num == "2") {
                    foreach(var item in dict) {
                        foreach(var term in item.Value) {
                            Console.WriteLine($"{item.Key}：{term}");
                        }
                    }
                } else {
                    continue;
                }
            }
        }
    }
}
