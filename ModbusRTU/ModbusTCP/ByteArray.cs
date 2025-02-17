using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTCPLib
{
    class ByteArray
    {

        private List<byte> _list= new List<byte>();

        public List<byte> List 
        {
            get { return _list; }
        }

        public byte[] Array
        {
            get { return _list.ToArray(); }
        }

        public int Length
        {
            get { return _list.Count(); }
        }

        public void Add(byte item)
        {
            _list.Add(item);
        }

        public void Add(byte[] items)
        {
            _list.AddRange(items);
        }

        public void Add(List<byte> items)
        {
            _list.AddRange(items);
        }

        public void Add(byte item1, byte item2)
        {
            Add(new byte[] { item1, item2 });
        }

        public void Add(byte item1, byte item2, byte item3)
        {
            Add(new byte[] { item1, item2, item3 });
        }

        public void Add(byte item1, byte item2, byte item3, byte item4)
        {
            Add(new byte[] { item1, item2, item3, item4 });
        }

        public void Add(byte item1, byte item2, byte item3, byte item4, byte item5)
        {
            Add(new byte[] { item1, item2, item3, item4, item5 });
        }

        public void Add(ByteArray byteArray)
        {
            Add(byteArray.Array);
        }

        public void Add(short value)
        {
            Add(((byte)(value >> 8)));
            Add(((byte)(value)));
        }

        public void Add(ushort value)
        {
            Add(((byte)(value >> 8)));
            Add(((byte)(value)));
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}
