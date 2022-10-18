using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer01.Servers
{
    class Message
    {
        public byte[] data = new byte[1024];
        private int startIndex = 0;

        public byte[] Data
        {
            get { return data; }
        }

        public int StartIndex
        {
            get { return startIndex; }
        }

        public int RemainSize
        {
            get
            {
                return data.Length - startIndex;
            }
        }

        public void ReadMessge(int newDataAmount)
        {
            startIndex += newDataAmount;
            if (startIndex <= 4)
            {
                return;
            }
            int count = BitConverter.ToInt32(data, 0);
            if (startIndex - 4 >= count)
            {
                string s = Encoding.UTF8.GetString(data, 4, count);
                Array.Copy(data, count + 4, data, 0, startIndex - 4 - count);
                startIndex = count + 4;
            }
            else
            {
                return;
            }
        }
    }
}
