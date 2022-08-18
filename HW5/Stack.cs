using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    partial class Stack
    {
        public Stack(params string[] str)
        {
            Add(str);
        }

        public int Size() { return strings.Count; }

        private List<string> strings = new();

        public void Add(params string[] str)
        {
            string p;
            for(int i = 0; i < str.Length; i++)
            {
                p = str[i];
                Console.WriteLine(p);
            }
        }


    }
}
