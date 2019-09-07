"# EmailSpamDetectionWithNaiveBayes" 
เป็น Window Form ที่เขียนด้วยภาษา C# สำหรับในการตรวจจับ Email ว่า email ใหนเป็น Spam หรือไม่ใช้ Spam โดยใช้ naive bayes classifier

![](https://github.com/CakeNuthep/EmailSpamDetectionWithNaiveBayes/blob/master/image/Application.PNG)

## การทำงานของโปรแกรม
#### โคดส่วนของการโหลดข้อมูลในคลาสที่ชื่อว่า LoadData
```csharp
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

```
จากโคดข้างบนในคลาสที่ชื่อว่า LoadData จะมีฟังกชันที่ชื่อว่า get_data โดยจะทำการโหลดข้อความมาจากไฟล์ enron แล้ว return Object ที่เป็น DataModel ซึ่งภายใน DataModel จะมี 2 ตัวแปรคือ List ที่เก็บข้อความของ email กับ List ที่เก็บว่าเมล์ดังกล่าวเป็น Spam หรือไม่ (1 จะหมายถึงว่าเป็น Spam และ 0 หมายถึงไม่ใช่ Spam)

####โคดส่วนนของการจัดการ string ในคลาสที่ชื่อว่า SpamDetector
```csharp
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

```

หลังจากที่เราโหลดข้อความจากไฟล์ Enron เราจะต้องเอาข้อมความมาจัดการดังนี้
- 	**ฟังก์ชันที่ชื่อว่า clean** จะเป็นฟังก์ชันสำหรับการลบตัวอักษรที่เป็น punctuation (punctuation คือตัวอักษรที่ไม่ใช่ภาษาอังกฤษเช่น . , ‘ [ ] ( ) { } : ` - ! < > ? “ “ ; / เป็นต้น)
-	**ฟังก์ชันที่ชื่อว่า tokenize** คือฟังก์ชันสำหรับการตัดคำจากข้อความให้เป็น Array ของคำ
-	**ฟังก์ชันที่ชื่อว่า get_word_count** คือฟังก์ชันสำหรับการนับคำว่าแต่ละคำนั้นมีจำนวนซ้ำกันเท่าไหร่ เช่น มี Array ของคำเข้ามาเป็น [hi, please, enter, button,for,get,the,money,enter,button,now] เราจะสามารถนับได้เป็น
hi มี 1 ตัว
please มี 1 ตัว
enter มี 2 ตัว
button มี 2 ตัว
for มี 1 ตัว
get มี 1 ตัว
the มี 1 ตัว
money มี 1 ตัว
now มี 1 ตัว

#### โคดส่วนนของการ training ในคลาสที่ชื่อว่า SpamDetector

```csharp
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

```

ในฟังก์ชันที่ชื่อว่า fit จะเป็นฟังก์ชันสำหรับการ training โดยหลังจากที่เราทำการ training เราจะได้ค่ามาสามสิ่ง คือ
-	**Log class priors** ที่เกิดจากเอาจำนวนเมล์ที่เป็น Span/ham  (ในที่นี้ Ham หมายถึงสิ่งที่ไม่ใช่ Spam) มาหารด้วยจำนวนอีเมลล์ทั้งหมด

![](https://github.com/CakeNuthep/EmailSpamDetectionWithNaiveBayes/blob/master/image/log%20class%20prior.PNG)

-	**Vocab** ที่เกิดจากการนำคำทั้งหมดที่ไม่ซ้ำกันมาเก็บ ยกตัวอย่างเช่นมีคำว่า [hi, please, enter, button,for,get,the,money,enter,button,now] ใน Vocab จะเก็บเหลือเฉพาะ [hi, please, enter, button,for,get,the,money,now]
-	**Word counts** ที่เก็บจำนวนคำในเมล์ที่เป็น Spam/ham ว่าแต่ละคำซ้ำกันกี่คำ ยกตัวอย่างเช่น ในอีเมล์ที่เป็น Spam ทั้งหมดมีคำ [hi, please, enter, button,for,get,the,money,enter,button,now] เราจะเก็บได้ว่า
hi มี 1 ตัว
please มี 1 ตัว
enter มี 2 ตัว
button มี 2 ตัว
for มี 1 ตัว
get มี 1 ตัว
the มี 1 ตัว
money มี 1 ตัว
now มี 1 ตัว
ในการหา word count ใน Ham ก็เช่นเดียวกัน

#### โคดส่วนนของการ Predict ในคลาสที่ชื่อว่า SpamDetector

```csharp
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

```

ฟังก์ชันที่ชื่อว่า predictจะเป็นการนำข้อความในเมล์มาทำนายว่าแต่ละข้อความในเมล์เป็น Spam หรือไม่โดยใช้ Naïve Bayes Classification ในการคาดคะเน

**รูปแสดงสมการ Naïve Bayes Classification  ในการหาความน่าจะเป็นที่คาดว่าเป็น Spam**

![](https://github.com/CakeNuthep/EmailSpamDetectionWithNaiveBayes/blob/master/image/log%20spam%20naive%20bayes%20only.PNG)

**รูปแสดงสมการ Naïve Bayes Classification  ในการหาความน่าจะเป็นที่คาดว่าเป็น Ham**

![](https://github.com/CakeNuthep/EmailSpamDetectionWithNaiveBayes/blob/master/image/log%20ham%20naive%20bayes%20only.PNG)

จะเห็นว่าเราใช้ Log ในการคำนวณซึ่งจะมีข้อควรระวังคือ Log0 จะไม่สามารถนิยามค่าได้ดังนั้นเราจึงป้องกันวิธีนี้โดยการทำ Laplace Smoothing หรือก็คือการบวกค่า 1 เข้าไปทุกๆค่าดังโคดนี้

![Laplace Smoothing](https://github.com/CakeNuthep/EmailSpamDetectionWithNaiveBayes/blob/master/image/Laplace%20Smoothing.png)

หลังจากนั้นเราจะได้ค่า log⁡〖p(Spam│w_1,…,w_n )〗 และ log⁡〖p(Ham│w_1,…,w_n )〗 เราก็จะทำการเปรียบเทียบทั้ง 2 ค่าว่า ความน่าจะเป็นที่เป็น Spam มากกว่า Ham หรือไม่ ถ้ามากกว่าแสดงว่าเป็น Spam (ค่าเป็น 1) ถ้าน้อยกว่าแสดงว่าเป็น Ham  (ค่าเป็น 0)

#### โคดการใช้งาน Class SpamDetector

```csharp
private void Button_run_Click(object sender, EventArgs e)
        {
            DataModel data = LoadData.get_data(textBox_pathFolder.Text);
            SpamDetector.fit(data.getData(80), data.getTargets(80));

            List<int> pred = SpamDetector.predict(data.getData(20,false));
            List<int> true_y = data.getTargets(20,false);

            double accuracy = 0;
            for(int i=0;i< pred.Count;i++)
            {
                if(pred[i] == true_y[i])
                {
                    accuracy += 1;
                }
            }
            accuracy = accuracy / (pred.Count*1.0);
            textBox_accurency.Text = accuracy.ToString();
            MessageBox.Show(String.Format("tranning Data Complete. Accuracy is {0:0.0000}", accuracy));
        }

```

จากโคดด้านบนจะเป็นการนำข้อมูลทั้งหมดที่ได้จาก LoadData.get_data(textBox_pathFolder.Text); มาแบ่งข้อมูลเป็น 80% สำหรับการ training และอีก 20% สำหรับการ predict เพื่อดูว่ามีความแม่นยำในการทำนายเท่าไหร่ (accuracy)

**สามารถดูความรู้เพิ่มเติมได้ที่**
- http://cakeknowledgeblogs.blogspot.com/2019/08/naive-bayes-classification-1.html
- https://pythonmachinelearning.pro/text-classification-tutorial-with-naive-bayes/

