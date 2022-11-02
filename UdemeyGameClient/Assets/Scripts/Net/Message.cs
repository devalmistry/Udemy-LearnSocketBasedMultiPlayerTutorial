using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Common;

public class Message : MonoBehaviour
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

    public void ReadMessge(int newDataAmount, Action<ActionCode, string> onProcessDataCallback)
    {
        startIndex += newDataAmount;

        while (true) {
            if (startIndex <= 4)
            {
                return;
            }
            int count = BitConverter.ToInt32(data, 0);
            if (startIndex - 4 >= count)
            {

                ActionCode actionCode = (ActionCode)BitConverter.ToInt32(data, 4);
                string s = Encoding.UTF8.GetString(data, 8, count - 4);
                onProcessDataCallback(actionCode, s);
                Array.Copy(data, count + 4, data, 0, startIndex - 4 - count);
                startIndex -= count + 4;
            }
            else
            {
                break;
            }
        }
    }

   // public static byte[] PackData(RequestCode requestCode, string data)
   // {
   //     byte[] requestCodeByte = BitConverter.GetBytes((int)requestCode);
   //     byte[] dataBytes = Encoding.UTF8.GetBytes(data);
   //     int newDataAmount = requestCodeByte.Length + dataBytes.Length;
   //     byte[] newDataAmountBytes = BitConverter.GetBytes(newDataAmount);
   //     return newDataAmountBytes.Concat(requestCodeByte).ToArray().Concat(dataBytes).ToArray();
   // }

    public static byte[] PackData(RequestCode requestCode,ActionCode actionCode, string data)
    {
        byte[] requestCodeByte = BitConverter.GetBytes((int)requestCode);
        byte[] actionCodeBytes  = BitConverter.GetBytes((int)actionCode);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        int newDataAmount = requestCodeByte.Length + dataBytes.Length+ actionCodeBytes.Length;
        byte[] DataAmountBytes = BitConverter.GetBytes(newDataAmount);
        byte[] newBytes = DataAmountBytes.Concat(requestCodeByte).ToArray().Concat(actionCodeBytes).ToArray();

        return newBytes.Concat(dataBytes).ToArray();
    }

}
