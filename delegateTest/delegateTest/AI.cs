using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateTest
{
    class AI
    {
        public delegate void Actions(string x); // 名字不重要，只是要讓系統知道函式的輸入格式是什麼，資料型態是什麼。
        Actions mActions = null;

        public void SetAction(Actions func) {
            mActions = func;
        }

        public void DoAction(string x)
        {
            mActions(x);
        }

    }
}
