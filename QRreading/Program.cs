using System;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QRreading
{
    class Program
    {
        static readonly StringBuilder sb = new StringBuilder();
        static readonly StringBuilder result =new StringBuilder();
        private static bool _readEnd;

        static void Main()
        {
            Timer timer = new Timer {Interval = 50};
            timer.Elapsed += Timer_Elapsed;

            sb.Append(Console.ReadKey().KeyChar);
            timer.Start();
            Task.Run(() =>
            {
                while (!_readEnd)
                {
                    sb.Append(Console.ReadKey().KeyChar);
                }
            });
            
            while (true)
                if (_readEnd)
                {
                    Console.WriteLine();
                    Console.WriteLine(result.ToString());
                    timer.Dispose();
                    break;
                }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (sb.Length != 0)
            {
                result.Append(sb.ToString());
                sb.Clear();
            }
            else
            {
                _readEnd = true;
            }
        }
    }
}
