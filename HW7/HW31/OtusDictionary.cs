using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW31
{
    public class OtusDictionary
    {

        readonly int maxSize = (int)Math.Pow(2, 20);

        int size = 32;
        MyKeyValuePair[] values;

        public OtusDictionary()
        {
            values = new MyKeyValuePair[size];
        }

        public string this[int key]
        {
            get { return Get(key); }
            set { Add(key, value); }
        }

        public void Add(int key, string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var hash = GetHash(key);

            while (values[hash] != null)
            {
                if (values[hash].Key == key) throw new ArgumentException("Ключ уже существует.");

                values = IncreaseArray();
            }

            values[hash] = new MyKeyValuePair() { Key = key, Value = value };
        }

        public string Get(int key) => values[GetHash(key)] != null
            ? values[GetHash(key)].Value
            : throw new ArgumentOutOfRangeException(nameof(key));

        MyKeyValuePair[] IncreaseArray()
        {
            size *= 2;

            if (size > maxSize) throw new Exception("Хэш функция не справляется...");

            var newValues = new MyKeyValuePair[size];

            foreach (var pair in values)
            {
                if (pair == null) continue;

                var hash = GetHash(pair.Key);

                if (newValues[hash] != null) return IncreaseArray();

                newValues[hash] = pair;
            }

            return newValues;
        }

        int GetHash(int key) => key % size;

        class MyKeyValuePair
        {
            public int Key { get; set; }
            public string Value { get; set; } = null!;
        }

    }
}
