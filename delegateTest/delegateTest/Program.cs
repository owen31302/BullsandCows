using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AI mAI = new AI();
            Behaivors mBehaivors = new Behaivors();
            mAI.SetAction(mBehaivors.Action1);
            mAI.DoAction("555");

        }
    }
}
