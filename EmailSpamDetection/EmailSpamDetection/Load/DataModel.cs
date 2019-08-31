using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSpamDetection.Load
{
    public class DataModel
    {
        public List<string> Data { get; set; }
        public List<int> Target { get; set; }

        public DataModel()
        {
            Data = new List<string>();
            Target = new List<int>();
        }

        public List<string> getData(int percent,bool fromFront=true)
        {
            int count = Data.Count;
            int startIndex = 0;
            int endIndex = count;
            if(fromFront)
            {
                int split = count * percent / 100;
                endIndex = split;
            }
            else
            {
                int split = count * (100 - percent) / 100;
                startIndex = split;
            }
            return Data.GetRange(startIndex, endIndex-startIndex);
        }

        public List<int> getTargets(int percent ,bool fromFront=true)
        {
            int count = Target.Count;
            int startIndex = 0;
            int endIndex = count;
            if (fromFront)
            {
                int split = count * percent / 100;
                endIndex = split;
            }
            else
            {
                int split = count * (100 - percent) / 100;
                startIndex = split;
            }
            return Target.GetRange(startIndex, endIndex-startIndex);
        }
    }
}
