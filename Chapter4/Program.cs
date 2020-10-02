using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {
    class Program {
        static void Main(string[] args) {
            var ymColection = new YearMonth[5] {
                new YearMonth(2020, 5),new YearMonth(2020,10),new YearMonth(2020,11),new YearMonth(2020,5),new YearMonth(2021,12)
            };

            Console.WriteLine("************4-2-2***********************************");
            foreach(var item in ymColection) {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n************4-2-4***********************************");
            Console.Write("最初に見つかった21世紀のデータは…");
            Console.WriteLine(FirstYearMonth21(ymColection)?.ToString() ?? "21世紀のデータはありません");


            Console.WriteLine("\n************4-2-5***********************************");
            var array = ymColection.Select(ym => ym.AddOneMonth()).ToArray();
                

            Console.WriteLine("一か月後の結果…");
            foreach(var item in array) {
                Console.WriteLine(item.ToString());
            }


        }

        public static YearMonth FirstYearMonth21(YearMonth[] ymArray) {
            YearMonth ym = null;
            foreach(var item in ymArray) {
                if(item.Is21Century) {
                    ym = item;
                    break;
                }
            }
            return ym;
        }
    }

}
