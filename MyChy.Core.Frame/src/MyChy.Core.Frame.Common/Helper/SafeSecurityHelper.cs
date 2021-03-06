﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyChy.Core.Frame.Common.Helper
{
    public class SafeSecurityHelper
    {
        ///// <summary>
        ///// DES加密字符串
        ///// </summary>
        ///// <param name="pToEncrypt">待加密的字符串</param>
        ///// <param name="sKey">加密密钥,要求为8位</param>
        ///// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        //public static string EncryptDes(string pToEncrypt, string sKey)
        //{
        //    try
        //    {
        //        sKey = StringHelper.StringQuantity(sKey, 8);


        //        var des = new DESCryptoServiceProvider();
        //        var inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
        //        //建立加密对象的密钥和偏移量
        //        //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
        //        //使得输入密码必须输入英文文本
        //        des.Key = Encoding.ASCII.GetBytes(sKey);
        //        des.IV = RgbIv;
        //        var ms = new MemoryStream();
        //        var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
        //        cs.Write(inputByteArray, 0,
        //            inputByteArray.Length);
        //        cs.FlushFinalBlock();
        //        var ret = new StringBuilder();
        //        foreach (byte b in ms.ToArray())
        //        {
        //            ret.AppendFormat("{0:X2}", b);
        //        }
        //        return ret.ToString();
        //    }
        //    catch { return ""; }
        //}

        ///// <summary>
        ///// DES解密字符串
        ///// </summary>
        ///// <param name="pToDecrypt">待解密的字符串</param>
        ///// <param name="sKey">解密密钥,要求为8位,和加密密钥相同</param>
        ///// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        //public static string DecryptDes(string pToDecrypt, string sKey)
        //{
        //    try
        //    {
        //        sKey = StringHelper.StringQuantity(sKey, 8);

        //        var des = new
        //            DESCryptoServiceProvider();
        //        var inputByteArray = new byte
        //            [pToDecrypt.Length / 2];
        //        for (var x = 0; x < pToDecrypt.Length / 2; x++)
        //        {
        //            var i = (Convert.ToInt32
        //                (pToDecrypt.Substring(x * 2, 2), 16));
        //            inputByteArray[x] = (byte)i;
        //        }
        //        //建立加密对象的密钥和偏移量，此值重要，不能修改
        //        des.Key = Encoding.ASCII.GetBytes(sKey);
        //        des.IV = RgbIv;
        //        var ms = new MemoryStream();
        //        var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
        //        cs.Write(inputByteArray, 0, inputByteArray.Length);
        //        cs.FlushFinalBlock();

        //        //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象
        //        var ret = new StringBuilder();
        //        return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        //    }
        //    catch { return ""; }
        //}


        /// <summary>
        /// MD5加密字符串 32位
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Md5Encrypt(string strText, Encoding encoding)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(encoding.GetBytes(strText));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").ToLower();

            }
            //var x = new HMACMD5();
            //var data = encoding.GetBytes(strText);
            //data = x.ComputeHash(data);
            //return encoding.GetString(data);
        }

        /// <summary>
        /// MD5加密字符串 32位
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string Md5Encrypt(string strText)
        {
            return Md5Encrypt(strText, Encoding.UTF8);
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string Sha1(string strText)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(strText));
            var enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }
            return enText.ToString();
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "SHA1");
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string Sha512(string strText)
        {
            var sha1 = SHA512.Create();

            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(strText));
            var enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }
            return enText.ToString();
        }
    }
}
