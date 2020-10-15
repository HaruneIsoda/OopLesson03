using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class Program {
        static void Main(string[] args) {
            #region
            //var employeeDict = new Dictionary<int, Employee> {
            //    {100, new Employee(100,"清水遼久")},
            //    {112, new Employee(112,"芹沢洋和") },
            //    {125, new Employee(125,"岩瀬奈央子") },
            //};

            //foreach(KeyValuePair<int,Employee> item in employeeDict) {
            //    Console.WriteLine($"{item.Value.Id} = {item.Value.Name}");
            //}


            //var employee = new List<Employee>() {
            //    new Employee(100,"清水遼久"),
            //    new Employee(112,"芹沢洋和"),
            //    new Employee(125,"岩瀬奈央子"),
            //    new Employee(143,"山田太郎"),
            //    new Employee(148,"池田次郎"),
            //    new Employee(152,"高田三郎"),
            //    new Employee(155,"石川幸也"),
            //    new Employee(161,"中沢信也"),
            //};

            ////IDが偶数のみディクショナリに変更する
            //var employeeDict = employee.Where(emp => emp.Id % 2 == 0).ToDictionary(emp => emp.Id);

            //foreach(KeyValuePair<int, Employee> item in employeeDict) {
            //    Console.WriteLine($"{item.Value.Id} = {item.Value.Name}");
            //}
            #endregion

            #region
            //var dict = new Dictionary<MonthDay, string> {
            //    {new MonthDay(3,5),"珊瑚の日" },
            //    {new MonthDay(8,4),"箸の日" },
            //    {new MonthDay(10,3),"登山の日" },
            //};

            //var md = new MonthDay(8, 4);
            //var s = dict[md];

            //Console.WriteLine(s);
            #endregion

            //var lines = File.ReadAllLines("sample.txt");
            //var we = new WordsExtractor(lines);

            //foreach(var word in we.Extract()) {
            //    Console.WriteLine(word);
            //}

            DuplicateKeySample();
        }

        public static void DuplicateKeySample() {
            // ディクショナリの初期化
            var dict = new Dictionary<string, List<string>>() {
               { "PC", new List<string> { "パーソナル コンピュータ", "プログラム カウンタ", } },
               { "CD", new List<string> { "コンパクト ディスク", "キャッシュ ディスペンサー", } },
            };

            // ディクショナリに追加
            var key = "EC";
            var value = "電子商取引";
            if(dict.ContainsKey(key)) {
                dict[key].Add(value);
            } else {
                dict[key] = new List<string> { value };
            }

            // ディクショナリの内容を列挙
            foreach(var item in dict) {
                foreach(var term in item.Value) {
                    Console.WriteLine("{0} : {1}", item.Key, term);
                }
            }
        }
    }
}
