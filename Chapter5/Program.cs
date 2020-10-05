using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter5 {
    class Program {
        static void Main(string[] args) {

            var text = "Jackdaws love my big sphinx of quartz";
            var noveText = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            Console.WriteLine("*********5-1*************************");
            #region 5-1
            Console.Write("文字を入力...");
            var str1 = Console.ReadLine();
            Console.Write("文字を入力...");
            var str2 = Console.ReadLine();

            if(string.Compare(str1, str2, true) == 0) {
                Console.WriteLine("二つの文字は一致しています");
            } else {
                Console.WriteLine("二つの文字は一致していません");
            }
            #endregion

            Console.WriteLine("\n*********5-2*************************");
            #region 5-2
            Console.Write("数値文字列…");
            var line = Console.ReadLine();
            int num;    //返還後の数値格納用
            if(int.TryParse(line, out num)) {
                Console.WriteLine(num.ToString("#,#"));
            } else {
                Console.WriteLine("数値文字列ではありません");
            }
            #endregion

            Console.WriteLine("\n*********5-3-1*************************");
            #region 5-3-1
            Console.WriteLine(text.Count(s => s == ' ') + "個空白があります。");
            #endregion

            Console.WriteLine("\n*********5-3-2*************************");
            #region 5-3-2
            Console.WriteLine(text.Replace("big", "small"));
            #endregion

            Console.WriteLine("\n*********5-3-3*************************");
            #region 5-3-3
            Console.WriteLine(text.Split(' ').Length + "個の単語があります");
            #endregion

            Console.WriteLine("\n*********5-3-4*************************");
            #region 5-3-4
            Console.WriteLine("4文字以下の単語は…");
            var strArray = text.Split(' ').Where(s => s.Length <= 4);
            foreach(var item in strArray) {
                Console.WriteLine(item);
            }
            #endregion

            Console.WriteLine("\n*********5-3-5*************************");
            #region 5-3-5
            var array = text.Split(' ').ToArray();
            if(array.Length > 0) {
                var sb = new StringBuilder();
                foreach(var word in array.Skip(1)) {
                    sb.Append(' ');
                    sb.Append(word);
                }
                Console.WriteLine(sb.ToString());
            }

            #endregion

            Console.WriteLine("\n*********5-4*************************");
            #region 5-4
            Console.WriteLine(noveText);
#if true
            foreach(var item in noveText.Split(';')){
                var word = item.Split('=');
                Console.WriteLine($"{ToJapanese(word[0])}:{word[1]}");
            }
#else
            var changeText = new string[3] { "作家　", "代表作", "誕生年" };
            var noveArray = noveText.Replace('=', ':').Split(';');

            for(int i = 0; i < changeText.Length; i++) {
                Console.Write(changeText[i]);
                Console.WriteLine(noveArray[i].SkipWhile(s => s != ':').ToArray());
            }
#endif

#endregion
        }

        static string ToJapanese(string key) {
            switch(key) {
                case "Novelist":
                    return "作家　";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
                default:
                    return "      ";
            }
        }
    }
}
