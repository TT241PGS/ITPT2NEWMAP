using System;
using System.IO;

namespace TS_ITPT2MAP_PARSER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************FILE CONVERSION *********************");
            ConvertITPT2(@"D:\05.TT251\ITPT2NEWMAP\ROAD_LTA_SEGMENT.txt");
        }

        public static void ConvertITPT2(string file)
        {
            
            
                if (File.Exists(file))
                {
                    string[] data = File.ReadAllLines(file);
                    var newFile = Path.GetFullPath(file).Replace(".txt","_NEW.txt");
                    foreach (var d in data)
                    {
                        WriteData(newFile, ConvertData( d));
                    }
                }
            Console.WriteLine("****************COMPLETED *********************");
        }
        public static void WriteData(string path,string data)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine(data);
                sw.Close();
            }
            else
            {
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine(data);
                sw.Close();
            }
        }

        public static string ConvertData(string inputData)
        {
            string[] data = inputData.Split('\t');
            if (data.Length == 6)
            {
                return data[0] + "\t" + GetEquivalentData(data[2])+"\t" + data[3] + "\t" + data[4] + "\t" + data[5];
            }
           
            return inputData;
        }
        public static string GetEquivalentData(string data)
        {
            return data switch
            {
                "1" => "CATA",
                "2" => "CATB",
                "3" => "CATC",
                "4" => "CATD",
                "5" => "CATE",
                "6" => "SLIP_ROAD",
                "7" => "CAT7",
                "8" => "CAT8",
                "9" => "CAT9",
                _ => data
            };
        }
    }
}
