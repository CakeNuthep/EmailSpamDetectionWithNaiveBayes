using EmailSpamDetection.Detect;
using EmailSpamDetection.Load;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSpamDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_browse_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_pathFolder.Text = folderBrowserDialog1.SelectedPath;
               
            }
        }

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

        private void Button_predict_Click(object sender, EventArgs e)
        {
            if(SpamDetector.predictIsSpam(textBox_testPredict.Text))
            {
                MessageBox.Show("Spam");
            }
            else
            {
                MessageBox.Show("Not Spam");
            }
        }
    }
}
