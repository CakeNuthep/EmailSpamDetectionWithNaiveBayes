using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSpamDetection.Load
{
    class LoadData
    {
        static string[] target_names = {"ham" , "spam"};
        static int maxFolder = 7;
        static public DataModel get_data(string data_dir)
        {
            List<string> subFolders = new List<string>();
            for(int i=0;i<maxFolder;i++)
            {
                subFolders.Add(string.Format("enron{0}",i+1));
            }

            DataModel data_target = new DataModel();
            foreach(string subfolder in subFolders)
            {
                //spam
                if (Directory.Exists(Path.Combine(data_dir, subfolder, "spam")))
                {
                    string[] spam_files = Directory.GetFiles(Path.Combine(data_dir, subfolder, "spam"));
                    foreach (string spam_file in spam_files)
                    {
                        data_target.Data.Add(string.Join(" ", File.ReadAllLines(spam_file, Encoding.UTF8)));
                        data_target.Target.Add(1);
                    }
                }

                //ham
                if (Directory.Exists(Path.Combine(data_dir, subfolder, "ham")))
                {
                    string[] ham_files = Directory.GetFiles(Path.Combine(data_dir, subfolder, "ham"));
                    foreach (string ham_file in ham_files)
                    {
                        data_target.Data.Add(string.Join(" ", File.ReadAllLines(ham_file, Encoding.UTF8)));
                        data_target.Target.Add(0);
                    }
                }
            }
            return data_target;
        }
    }
}
