using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSpamDetection.Detect
{
    class TrainModel
    {
        public NumMessage num_messages;
        public LogClassPriois log_class_priors;
        public WordCounts word_counts;
        public Dictionary<string,int> vocab;

        public TrainModel()
        {
            num_messages = new NumMessage();
            log_class_priors = new LogClassPriois();
            word_counts = new WordCounts();
            vocab = new Dictionary<string, int>();
        }
    }

    class NumMessage
    {
        public int spam { get; set; }
        public int ham { get; set; }
    }

    class LogClassPriois
    {
        public double spam { get; set; }
        public double ham { get; set; }
    }

    class WordCounts
    {
        public Dictionary<string,int> spam { get; set; }
        public Dictionary<string,int> ham { get; set; }

        public WordCounts()
        {
            spam = new Dictionary<string, int>();
            ham = new Dictionary<string, int>();
        }
    }
}
