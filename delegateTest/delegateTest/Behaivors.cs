using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateTest
{
    class Behaivors
    {
        string QQQ = "!@!@!@"; // 代表delegate不僅把函數丟過去，函數裡面用到的變數也會一起丟過去執行。
        //丟過去的delegate函式，無法使用目標class裡面的成員變數。

        public void Action1(string x) {
            Console.WriteLine("QQQ: "+ x + QQQ);
        }
    }
}
