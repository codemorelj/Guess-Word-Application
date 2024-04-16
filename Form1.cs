using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    //AUTHOR: LJ Salazar || BSIT 202 C

namespace GuessWordApplication
{
    public partial class frmGuessWord : Form
    {
        public frmGuessWord()
        {
            InitializeComponent();
            displayWord();
        }

        static Random random = new Random();

        //array for set of words na pwede hulaan
        static string[] words =
        {
            "anger",
            "charcoal",
            "carbon",
            "sofa",
            "bottle",
            "guess"
        };

        int index = random.Next(words.Length);

        //for the underline/missing letters
        public void displayWord()
        {
            int pos1 = random.Next(words[index].Length);
            int pos2 = random.Next(words[index].Length);
            int pos3 = random.Next(words[index].Length);

            string word = words[index];
            StringBuilder wordBuilder = new StringBuilder(word);

            wordBuilder[pos1] = '_';
            wordBuilder[pos2] = '_';
            wordBuilder[pos3] = '_';

            //StringBuilder class used hehe
            wordz.Text = wordBuilder.ToString();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string userinput = answer.Text.ToLower();

            if (userinput.Equals(words[index]))
            {
                MessageBox.Show("Well done! You got it!", "Nice!");
                index = random.Next(words.Length);
                displayWord();
                label3.Text = "";
            }
            else
            {
                MessageBox.Show("You got it wrong :(", "Try again");
                label3.Text += answer.Text + "\n";
            }

            //auto delete sa sagot every after submitting the answer
            answer.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = random.Next(words.Length);
            displayWord();
            label3.Text = "";
            answer.Clear();
        }
    }
}