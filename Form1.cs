using System;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;


namespace Compacting_Press_Cut_Weight_Assistant
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class Form1 : Form
    {
        private object averageLabel;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e, averageLabel);
        }

        private void button1_Click(object sender, EventArgs e, object averageLabel)
        {

            {
                double[] numbers = new double[5];
                bool allInputsValid = true;

                // Attempt to parse the numbers from the TextBoxes, check for validity
                allInputsValid &= double.TryParse(textBox1.Text, out numbers[0]);
                allInputsValid &= double.TryParse(textBox2.Text, out numbers[1]);
                allInputsValid &= double.TryParse(textBox3.Text, out numbers[2]);
                allInputsValid &= double.TryParse(textBox4.Text, out numbers[3]);
                allInputsValid &= double.TryParse(textBox5.Text, out numbers[4]);

                if (!allInputsValid)
                {
                    MessageBox.Show("Please enter valid numbers for all 5 Preform Total Weights", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the event handler early
                }

                // Calculate the average
                double average = numbers.Average();
                Labelaverage.Text = "Average Preform Weight: " + average.ToString("F2");

                // Find the number closest to the average
                double closest = numbers.OrderBy(number => Math.Abs(number - average)).First();

                // Reset highlights
                textBox1.BackColor = System.Drawing.Color.White;
                textBox2.BackColor = System.Drawing.Color.White;
                textBox3.BackColor = System.Drawing.Color.White;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox5.BackColor = System.Drawing.Color.White;

                // Highlight the closest number
                HighlightClosestNumber(closest, numbers);

                // Set the closest number in textBox6
                textBox6.Text = closest.ToString("F2");

                // Make the Average Label Visible
                Labelaverage.Visible = true;

                // Disable the preform weight entry boxes
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

                // Hide the initial weight steps
                label6.Visible = false;
                label7.Visible = false;
                label12.Visible = false;
                button1.Visible = false;

                // Show the Cut Weight Steps
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                button2.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;

            }

        }

        private void HighlightClosestNumber(double closest, double[] numbers)
        {
            // This method assumes textBox1 to textBox5 and numbers array are correctly aligned in terms of their indices.
            TextBox[] textBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5 };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (numbers[i] == closest)
                {
                    textBoxes[i].BackColor = System.Drawing.Color.LightGreen;
                    break; // Exit the loop once the closest number is found and highlighted
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Clear the TextBoxes
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox12.Text = string.Empty;
            textBox13.Text = string.Empty;


            // Enable the preform weight textboxes
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;

            // Unhide the initial weight steps
            label6.Visible = true;
            label7.Visible = true;
            label12.Visible = true;
            button1.Visible = true;

            // Reset background colors if highlighting was used
            textBox1.BackColor = System.Drawing.Color.White;
            textBox2.BackColor = System.Drawing.Color.White;
            textBox3.BackColor = System.Drawing.Color.White;
            textBox4.BackColor = System.Drawing.Color.White;
            textBox5.BackColor = System.Drawing.Color.White;
            textBox10.BackColor = System.Drawing.Color.White;
            textBox11.BackColor = System.Drawing.Color.White;
            textBox12.BackColor = System.Drawing.Color.White;
            textBox13.BackColor = System.Drawing.Color.White;

            // Clear the average Label
            Labelaverage.Text = "";
            Labelaverage.Visible = false;

            // Hide the cut weight instructions & enable textboxes
            textBox7.Enabled = true;
            textBox9.Enabled = true;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            button2.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Parse the numbers from textBox6, textBox7, and textBox9
            if (double.TryParse(textBox6.Text, out double valueInTextBox6) &&
                double.TryParse(textBox7.Text, out double valueInTextBox7) &&
                double.TryParse(textBox9.Text, out double valueInTextBox9))
            {
                // Calculate textBox8, textBox10, textBox11, textBox12, and textBox13 values
                double textBox8Value = valueInTextBox6 - valueInTextBox7 - valueInTextBox9;
                double textBox10Value = valueInTextBox6 - 697;
                double textBox11Value = valueInTextBox7 - 391;
                double textBox12Value = textBox8Value - 209;
                double textBox13Value = valueInTextBox9 - 97;

                // Set textBox8, textBox10, textBox11, textBox12, and textBox13 values
                textBox8.Text = textBox8Value.ToString("F2");
                textBox10.Text = textBox10Value.ToString("F2");
                textBox11.Text = textBox11Value.ToString("F2");
                textBox12.Text = textBox12Value.ToString("F2");
                textBox13.Text = textBox13Value.ToString("F2");

                // Check if textBox10, textBox11, textBox12, and textBox13 are within their ranges for color highlighting
                HighlightTextbox(textBox10, textBox10Value, -3, 3);
                HighlightTextbox(textBox11, textBox11Value, -1.5, 1.5);
                HighlightTextbox(textBox12, textBox12Value, -1, 1);
                HighlightTextbox(textBox13, textBox13Value, -0.5, 0.5);

                // Hide the cut weight instructions & disable textboxes
                textBox7.Enabled = false;
                textBox9.Enabled = false;
                label13.Visible = false;
                label14.Visible = false;
                button2.Visible = false;

                // Show the Deviation from Nominal
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                label15.Visible = true;

                // Check if all TextBoxes are green
                if (textBox10.BackColor == System.Drawing.Color.LightGreen &&
                    textBox11.BackColor == System.Drawing.Color.LightGreen &&
                    textBox12.BackColor == System.Drawing.Color.LightGreen &&
                    textBox13.BackColor == System.Drawing.Color.LightGreen)
                {
                    // Make label16 visible
                    label16.Visible = true;
                }
                else
                {
                    // If any of the TextBoxes contain invalid numbers, show an error message

                }
            }
        }

        private void HighlightTextbox(TextBox textBox, double value, double lowerLimit, double upperLimit)
        {
            if (value >= lowerLimit && value <= upperLimit)
            {
                textBox.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                textBox.BackColor = System.Drawing.Color.Red;

                // Show NOK banner
                label17.Visible = true;
            }
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}