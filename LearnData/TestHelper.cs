using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LearnData
{
    /// <summary>
    /// 测试辅助类
    /// </summary>
    class TestHelper
    {
        /// <summary>
        /// 读取文件，将其分词，分词后存入list中返回使用
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static List<string> ReadFile(string filename)
        {
            //使用FileStream类打开文件名为filename的文件
            FileStream fs = new FileStream(filename, FileMode.Open);

            //使用StreamReader读取文件名为filename的文件信息
            StreamReader sr = new StreamReader(fs);


            List<string> words = new List<string>();

            //分词操作，简陋的分词方式
            //只要单词拼写不一致，我们就认为是不同的单词，不考虑单词的词性和时态
            while (!sr.EndOfStream)//是否读到文件末尾
            {
                //读取一行字符串并去除字符串的头部和尾部的空白符号
                string contents = sr.ReadLine().Trim();

                //寻找contents第一个字母的位置
                int start = FirstCharacterIndex(contents, 0);

                for (int i = start + 1; i <= contents.Length;)
                {
                    if (i == contents.Length || !Char.IsLetter(contents[i]))
                    {
                        string word = contents.Substring(start, i - start).ToLower();
                        words.Add(word);
                        start = FirstCharacterIndex(contents, i);
                        i = start + 1;
                    }
                    else
                        i++;
                }
            }

            //关闭流
            fs.Close();
            sr.Close();

            return words;
        }

        /// <summary>
        /// 寻找字符串中，从start的位置开始的第一个字母字符的位置
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        private static int FirstCharacterIndex(string s, int start) 
        {
            for (int i = start; i < s.Length; i++)
                if (Char.IsLetter(s[i]))
                    return i;

            return s.Length;

        }


    }
}
