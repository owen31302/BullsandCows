using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsandCows
{
    class AB {
        public int A;
        public int B;

        public AB() {
            A = 0;
            B = 0;
        }
    }

    class BullsandCowsDelegate
    {
        int _correctAns;
        int _enteredNumbers;
        AB _AB;
        List<string> _Log;

        public delegate int RandomAns();
        RandomAns _RandomAns = null;

        public delegate AB checkAns(int correctAns, int enteredNumbers);
        checkAns _checkAns = null;

        public BullsandCowsDelegate()
        {
            _enteredNumbers = 0;
            _AB = new AB();
            _Log = new List<string>();
        }

        public int get_A()
        {
            return _AB.A;
        }
        public int get_B()
        {
            return _AB.B;
        }
        public List<string> get_Log()
        {
            return _Log;
        }
        public int get_correctAns()
        {
            return _correctAns;
        }
        public void setFunction_RandomAns(RandomAns func) {
            _RandomAns = func;
        }

        public void setFunction_checkAns(checkAns func) {
            _checkAns = func;
        }

        public void generateAns() {
            _correctAns = _RandomAns();
        }

        public void checkAnswer(int enteredNumbers) {
            _enteredNumbers = enteredNumbers;
            _AB = _checkAns( _correctAns , enteredNumbers);
            AddLog();
        }

        public void reset() {
            _enteredNumbers = 0;
            _AB = new AB();
            _Log = new List<string>();
        }

        void AddLog()
        {
            _Log.Add("您輸入: " + _enteredNumbers + " , 結果: " + get_A() + "A, " + get_B() + "B");
        }
    }
}
