using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {
    class YearMonth {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public bool Is21Century {
            get { return 2001 <= Year && Year <= 2100; }
        }

        //コンストラクタ
        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        public YearMonth AddOneMonth() {
            return new YearMonth(Month == 12 ? Year + 1 : Year,Month == 12 ? 1 : Month + 1);
        }

        public  override string ToString() {
            return Year + "年" + Month + "月";
        }
    }
}
