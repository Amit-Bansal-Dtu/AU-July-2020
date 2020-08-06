using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Handlers
{
    class CallBack
    {
        public void Completion()
        {
            Console.WriteLine("Program Completed!!");
        }
        public delegate void CallDel();

        public void Running(CallDel d)
        {
            Console.WriteLine("Program Running.....");
            d();
        }
        public void call()
        {
            Console.WriteLine("Program started!!");
            CallDel obj = Completion;
            Running(obj);
        }
    }
}
