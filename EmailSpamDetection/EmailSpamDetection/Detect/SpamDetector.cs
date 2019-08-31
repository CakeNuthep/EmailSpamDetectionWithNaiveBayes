using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailSpamDetection.Detect
{
    public static class SpamDetector
    {
        static TrainModel trainModel = new TrainModel();


        public static string clean(string s)
        {
            return Regex.Replace(s, @"\p{P}", "");
        }

        public static string[] tokenize(string text)
        {
            text = clean(text).ToLower();
            return Regex.Split(text, @"\W+");
        }

        public static Dictionary<string,int> get_word_count(string[] words)
        {
            Dictionary<string, int> word_counts = new Dictionary<string, int>();
            foreach(string word in words)
            {
                if(!word_counts.ContainsKey(word))
                {
                    word_counts.Add(word, 0);
                }
                word_counts[word] = word_counts[word] + 1;
            }
            return word_counts;
        }

        public static void fit(List<string> X, List<int> Y)
        {
            double n = X.Count;

            trainModel.num_messages.spam = Sum(1, Y, 1);
            trainModel.num_messages.ham = Sum(1, Y, 0);
            trainModel.log_class_priors.spam = Math.Log10(trainModel.num_messages.spam / n);
            trainModel.log_class_priors.ham = Math.Log10(trainModel.num_messages.ham/ n);

            for(int i=0;i<n;i++)
            {
                string c = (Y[i]==1) ? "spam" : "ham";
                Dictionary<string,int> counts = get_word_count(tokenize(X[i]));
                foreach (var kvp in counts.ToArray())
                {
                    int count = kvp.Value;
                    string word = kvp.Key;
                    if(!trainModel.vocab.ContainsKey(word))
                    {
                        trainModel.vocab.Add(word, 1);
                    }
                    if(c == "spam")
                    {
                        if(!trainModel.word_counts.spam.ContainsKey(word))
                        {
                            trainModel.word_counts.spam.Add(word, 0);
                        }
                        trainModel.word_counts.spam[word] += count;
                    }
                    else
                    {
                        if (!trainModel.word_counts.ham.ContainsKey(word))
                        {
                            trainModel.word_counts.ham.Add(word, 0);
                        }
                        trainModel.word_counts.ham[word] += count;
                    }

                    
                }

            }
            
        }

        public static List<int> predict(List<string> X)
        {
            List<int> result = new List<int>();
            foreach (string x in X)
            {
                Dictionary<string, int> counts = get_word_count(tokenize(x));
                double spam_score = 0;
                double ham_score = 0;

                foreach (var kvp in counts.ToArray())
                {
                    string word = kvp.Key;
                    if (trainModel.vocab.ContainsKey(word))
                    {
                        // add Laplace smoothing
                        double log_w_given_spam = Math.Log10(GetValueOrDefault(trainModel.word_counts.spam, word, 0) + 1)*1.0 / trainModel.num_messages.spam;
                        double log_w_given_ham = Math.Log10(GetValueOrDefault(trainModel.word_counts.ham, word, 0) + 1)*1.0 / trainModel.num_messages.ham;

                        spam_score += log_w_given_spam;
                        ham_score += log_w_given_ham;
                    }
                }
                spam_score += trainModel.log_class_priors.spam;
                ham_score += trainModel.log_class_priors.ham;

                if (spam_score > ham_score)
                    result.Add(1);
                else
                    result.Add(0);
            }
            return result;

        }


        public static bool predictIsSpam(string x)
        {
                Dictionary<string, int> counts = get_word_count(tokenize(x));
                double spam_score = 0;
                double ham_score = 0;

                foreach (var kvp in counts.ToArray())
                {
                    string word = kvp.Key;
                    if (trainModel.vocab.ContainsKey(word))
                    {
                        // add Laplace smoothing
                        double log_w_given_spam = Math.Log10((GetValueOrDefault(trainModel.word_counts.spam, word, 0) + 1)*1.0 / trainModel.num_messages.spam);
                        double log_w_given_ham = Math.Log10((GetValueOrDefault(trainModel.word_counts.ham, word, 0) + 1)*1.0 / trainModel.num_messages.ham);

                        spam_score += log_w_given_spam;
                        ham_score += log_w_given_ham;
                    }
                }
                spam_score += trainModel.log_class_priors.spam;
                ham_score += trainModel.log_class_priors.ham;

            if (spam_score > ham_score)
                return true;
            else
                return false;

        }


        private static int Sum(int number, List<int> Y, int equareCondition)
        {
            int sum_result = 0;
            foreach(int y in Y)
            {
                if(y == equareCondition)
                {
                    sum_result += number;
                }
            }
            return sum_result;
        }

        private static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,TKey key,TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }
    }
}
