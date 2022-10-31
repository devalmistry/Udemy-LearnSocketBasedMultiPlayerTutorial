﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;


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

        public void ReadMessge(int newDataAmount, Action<RequestCode, ActionCode, string> onProcessDataCallback)
        {
            startIndex += newDataAmount;
            if (startIndex <= 4)
            {
                return;
            }
            int count = BitConverter.ToInt32(data, 0);
            if (startIndex - 4 >= count)
            {
                RequestCode requestCode = (RequestCode)BitConverter.ToInt32(data, 4);
                ActionCode actionCode = (ActionCode)BitConverter.ToInt32(data, 8);
                string s = Encoding.UTF8.GetString(data, 12, count - 4);
                onProcessDataCallback(requestCode, actionCode, s);
                Array.Copy(data, count + 4, data, 0, startIndex - 4 - count);
                startIndex = count + 4;
            }
            else
            {
                return;
            }
        }

        public static byte[] PackData(ActionCode actionCode, string data)
        {
            byte[] actionCodeByte = BitConverter.GetBytes((int)actionCode);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int newDataAmount = actionCodeByte.Length + dataBytes.Length;
            byte[] newDataAmountBytes = BitConverter.GetBytes(newDataAmount);
            return newDataAmountBytes.Concat(actionCodeByte).ToArray().Concat(dataBytes).ToArray();
        }
    }
}