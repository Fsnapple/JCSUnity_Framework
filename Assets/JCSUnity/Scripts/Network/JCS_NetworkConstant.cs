﻿/**
* $File: JCS_NetworkConstant.cs $
* $Date: 2017-08-21 16:38:46 $
* $Revision: $
* $Creator: Jen-Chieh Shen $
* $Notice: See LICENSE.txt for modification and distribution information 
*	                 Copyright (c) 2017 by Shen, Jen-Chieh $
*/
using UnityEngine;
using System.Collections;


namespace JCSUnity
{
    /// <summary>
    /// Store all the network constants.
    /// </summary>
    public class JCS_NetworkConstant : MonoBehaviour
    {
        public static string OFFICIAL_WEBSITE = "www.jcs-profile.com";

        public static int MAX_MESSAGE = 16 * 1024;      // 暂定一个消息最大为, [default: 16k bytes]
        public static int BLOCKSECONDS = 30;            // INIT函数阻塞时间, [default: 30 seconds]
        public static int INBUFSIZE = 64 * 1024;        // 具体尺寸根据剖面报告调整  接收数据的缓存, [default: 64k bytes]
        public static int OUTBUFSIZE = 8 * 1024;        // 具体尺寸根据剖面报告调整。 发送数据的缓存，当不超过8K时，FLUSH只需要SEND一次, [default: 8k bytes]

        //-- Default Value
        public static int DECODE_BUFFER_LEN = 4;
        public static byte[] DECODE_BUFFER = new byte[DECODE_BUFFER_LEN];

        public static int ENCODE_BUFFER_LEN = 4;
        public static byte[] ENCODE_BUFFER = new byte[ENCODE_BUFFER_LEN];

        public static int CONNECT_TIME = 5;     // default: 5 seconds

        // this must be the same as the server.
        public static long MAX_PACKET_NUMBER = 100000000L;

    }
}
