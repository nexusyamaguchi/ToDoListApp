using System;
using System.Text.RegularExpressions;

namespace Main
{
    class ToDoListApp
    {
        static void Main(string[] args)
        {
            string path = "./schedule.txt";
            //ファイル作成判定
            if (!File.Exists(path))
            {
                using FileStream fs = File.Create(path); ;
            }
            while (true)
            {
                Console.WriteLine("実行する番号を半角で入力してください。");
                Console.WriteLine("1:スケジュール確認\n");
                Console.WriteLine("2:スケジュール入力\n");
                Console.WriteLine("3:スケジュール削除\n");
                var v = Console.ReadLine();
                Console.WriteLine();
                switch (v)
                {
                    case "1":
                        read();
                        break;
                    case "2":
                        write();
                        break;
                    case "3":
                        delete();
                        break;
                    default:
                        Console.WriteLine("実行できない数字を入力しています。\n\n");
                        break;
                }
            }


            //読み込み処理
            void read()
            {
                Console.WriteLine("スケジュール確認を実行します。");
                string[] lines = File.ReadAllLines(path);
                if (lines.Length == 0)
                {
                    Console.WriteLine("スケジュールはありません。\n\n");
                }
                else {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        Console.WriteLine("No." + (i + 1) + " " + lines[i] + "\n");
                        Console.WriteLine("スケジュールは以上です。\n\n");
                    }
                }
            }


            //書き込み処理
            void write()
            {
                Console.WriteLine("スケジュール入力を受付を開始します。");
                //既存データ読み込み
                string input = File.ReadAllText(path);
                string[] lines = File.ReadAllLines(path);
                //入力受付,上書き
                bool b = true;
                string day;
                string doing;
                //日付入力
                do
                {
                    Console.WriteLine("日付を入力してください。(例:2021/1/1)");
                    day = Console.ReadLine();
                    if (Regex.IsMatch(day, @"\d{4}/\d{1,2}/\d{1,2}")) 
                    {
                        b = false;
                    }
                    else
                    {
                        Console.WriteLine("入力形式が間違っています。\n");
                    }
                } while (b);
                b = true;
                //予定入力
                do
                {
                    Console.WriteLine("\n予定を入力してください。");
                    doing = Console.ReadLine();
                    if(doing != "")
                    {
                        b=false;
                    }
                } while (b);
                StreamWriter sw = new StreamWriter(path);
                input = input + day + "　" + doing;
                sw.WriteLine(input);
                sw.Close();
                Console.WriteLine("入力を受け付けました。\n\n");
            }


            //削除機能
            void delete()
            {
                Console.WriteLine("削除したいスケジュール番号を半角数字で入力してください。(例:1)");
                string input = null;
                var deleteLine = Console.ReadLine();
                string[] lines = File.ReadAllLines(path);
                if (Int32.Parse(deleteLine) > lines.Length || deleteLine == "")
                {
                    Console.WriteLine("存在している番号を入力してください。\n\n");
                    
                }
                else
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (deleteLine != (i + 1).ToString())
                        {
                            if (i == lines.Length - 1)
                            {
                                input += lines[i];
                            }
                            else
                            {
                                input += "\n" + lines[i];
                            }
                                StreamWriter w = new StreamWriter(path);
                                w.Write(input);
                                w.Close();
                                Console.WriteLine("削除しました。\n\n");
                            }
                    }
                }
            }
        }
    }
}
