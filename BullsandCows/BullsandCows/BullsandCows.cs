using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsandCows
{
    class BullsandCows
    {
        int _digits;
        bool _haveZero;
        int _canRepeat;
        int _correctAns;
        int _enteredNumbers;
        int _A;
        int _B;
        List<string> _Log;

        public BullsandCows() {
            _digits = 6;
            _haveZero = true;
            _canRepeat = (int)repeat.yes;
            _correctAns = randomAns();
            _A = 0;
            _B = 0;
            _enteredNumbers = 0;
            _Log = new List<string>();
        }

        public int get_A() {
            return _A;
        }
        public int get_B()
        {
            return _B;
        }
        public List<string> get_Log()
        {
            return _Log;
        }
        public int get_digits()
        {
            return _digits;
        }
        public int get_correctAns()
        {
            return _correctAns;
        }

        public void checkAns(int enteredNumbers) //O(N)
        {
            _enteredNumbers = enteredNumbers;
            // check _A
            var enteredNumbersDigits = TearNumbersToList(enteredNumbers);
            var correctAnsNumbersDigits = TearNumbersToList(_correctAns);
            int _A_cnt = 0;
            var _A_index = new List<int>(); // for _B
            for (int i = 0; i < _digits; i++)
            {
                if (enteredNumbersDigits[i].Equals(correctAnsNumbersDigits[i]))
                {
                    _A_index.Insert(0, i); // for _B
                    _A_cnt++;
                }
            }
            _A = _A_cnt;
            if (_A == _digits)
            {
                AddLog();
                _B = 0;
                return;
            }

            // check _B
            // remove _A numbers
            for (int i = 0; i < _A_index.Count; i++)
            {
                enteredNumbersDigits.RemoveAt(_A_index[i]);
                correctAnsNumbersDigits.RemoveAt(_A_index[i]);
            }
            // two different method accroding to repeated numbers or non-repeated numbers
            if (_canRepeat == (int)repeat.no)
            {
                // _B = (original amount of numbers in two sets) - (amount of numbers in the merged set)
                var enteredNumbersSet = new HashSet<int>(enteredNumbersDigits);
                var correctAnsNumbersSet = new HashSet<int>(correctAnsNumbersDigits);
                int oriAmount = enteredNumbersSet.Count + correctAnsNumbersSet.Count;
                enteredNumbersSet.UnionWith(correctAnsNumbersSet);
                _B = oriAmount - enteredNumbersSet.Count;

                AddLog();
            }
            else {
                // find method
                int _B_cnt = 0;
                for (int i = 0; i < enteredNumbersDigits.Count; i++) {
                    int index = correctAnsNumbersDigits.IndexOf(enteredNumbersDigits[0]);
                    if (index != -1) {
                        correctAnsNumbersDigits.Remove(index);
                        _B_cnt++;
                    }
                    enteredNumbersDigits.RemoveAt(0);
                }
                _B = _B_cnt;
                AddLog();
            }
        }

        void AddLog() {
            _Log.Add("您輸入: " + _enteredNumbers + " , 結果: " + _A + "A, " + _B + "B");
        }

        List<int> TearNumbersToList(int Numbers) // O(N)
        {
            List<int> retunList = new List<int>();
            int tempNumbers = Numbers;
            for (int i = 0; i < _digits; i++)
            {
                int pow = (int)Math.Pow(10, _digits - 1 - i);
                int tempNum = tempNumbers / pow;
                tempNumbers = tempNumbers - pow * tempNum;
                retunList.Add(tempNum);
            }
            return retunList;
        }

        int randomAns() {
            Random random = new Random();
            
            // return non repeated numbers
            if (_canRepeat == (int)repeat.no)
            {
                int totalNum = 0;
                List<int> templist = new List<int>();
                while ( (int)(totalNum / Math.Pow(10, _digits-1)) <= 0 ) {
                    int tempNum;
                    if (_haveZero)
                    {
                        tempNum = random.Next(0, 9);
                    }
                    else {
                        tempNum = random.Next(1, 9);
                    }
                    if (!templist.Contains(tempNum)) {
                        templist.Add(tempNum);
                        totalNum = totalNum * 10 + tempNum;
                    }
                }
                return totalNum;
            }
            // return repeated numbers
            else {
                if (_haveZero)
                {
                    return random.Next(0, (int)(Math.Pow(10, _digits) - 1));
                }
                else {
                    int totalNum = 0;
                    while ((int)(totalNum / Math.Pow(10, _digits - 1)) <= 0)
                    {
                        int tempNum;
                        tempNum = random.Next(1, 9);
                        totalNum = totalNum * 10 + tempNum;
                    }
                    return totalNum;
                }
            }
        }

    }

    public enum repeat
    {
        yes = 1,
        no,
    }
}
