using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsandCows
{
    class delegateMethod
    {
        bool _haveZero;
        int _digits;

        public delegateMethod() {
            _digits = 6;
            _haveZero = true;
        }

        public int get_digits() {
            return _digits;
        }

        public int randomAns_repeat()
        {
            Random random = new Random();

            // return repeated numbers
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

        public int randomAns_nonrepeat()
        {
            Random random = new Random();

            // return non repeated numbers
            int totalNum = 0;
            List<int> templist = new List<int>();
            while ((int)(totalNum / Math.Pow(10, _digits - 1)) <= 0)
            {
                int tempNum;
                if (_haveZero)
                {
                    tempNum = random.Next(0, 9);
                }
                else {
                    tempNum = random.Next(1, 9);
                }
                if (!templist.Contains(tempNum))
                {
                    templist.Add(tempNum);
                    totalNum = totalNum * 10 + tempNum;
                }
            }
            return totalNum;
        }

        public AB checkAns_repeat(int _correctAns, int enteredNumbers) //O(N)
        {
            AB mAB = new AB();

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
            mAB.A = _A_cnt;
            if (mAB.A == _digits)
            {
                mAB.B = 0;
                return mAB;
            }

            // check _B
            // remove _A numbers
            for (int i = 0; i < _A_index.Count; i++)
            {
                enteredNumbersDigits.RemoveAt(_A_index[i]);
                correctAnsNumbersDigits.RemoveAt(_A_index[i]);
            }

            // find method
            int _B_cnt = 0;
            for (int i = 0; i < enteredNumbersDigits.Count; i++)
            {
                int index = correctAnsNumbersDigits.IndexOf(enteredNumbersDigits[0]);
                if (index != -1)
                {
                    correctAnsNumbersDigits.Remove(index);
                    _B_cnt++;
                }
                enteredNumbersDigits.RemoveAt(0);
            }
            mAB.B = _B_cnt;
            return mAB;
        }

        public AB checkAns_nonrepeat(int _correctAns, int enteredNumbers) //O(N)
        {
            AB mAB = new AB();

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
            mAB.A = _A_cnt;
            if (mAB.A == _digits)
            {
                mAB.B = 0;
                return mAB;
            }

            // check _B
            // remove _A numbers
            for (int i = 0; i < _A_index.Count; i++)
            {
                enteredNumbersDigits.RemoveAt(_A_index[i]);
                correctAnsNumbersDigits.RemoveAt(_A_index[i]);
            }
            // _B = (original amount of numbers in two sets) - (amount of numbers in the merged set)
            var enteredNumbersSet = new HashSet<int>(enteredNumbersDigits);
            var correctAnsNumbersSet = new HashSet<int>(correctAnsNumbersDigits);
            int oriAmount = enteredNumbersSet.Count + correctAnsNumbersSet.Count;
            enteredNumbersSet.UnionWith(correctAnsNumbersSet);
            mAB.B = oriAmount - enteredNumbersSet.Count;
            return mAB;
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
    }
}
