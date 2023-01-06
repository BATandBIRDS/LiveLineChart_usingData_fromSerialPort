using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using Timer = System.Windows.Forms.Timer;


namespace @interface
{   //                                               xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    //                                               |  Written By: Savran Donmez    |
    //                                               |  Start Date: 12/10/2022       |
    //                                               |  Last Update: 24/10/2022      |
    //                                               xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    public partial class Form1 : Form
    {
        // Usefull Constants for future 
        Timer t; 
        int countAt500ms;  // graph edges
        int currCnt=0;     // graph edges
        private string whole_line;
        SerialPort choosenPort = new SerialPort();
        
        //  1 series per every constantly coming data.
        //  For graph
        Series df0 = new Series();
        Series df1 = new Series();
        Series df2 = new Series();
        Series df3 = new Series();
        Series df4 = new Series();
        Series df5 = new Series();
        Series df6 = new Series();
        Series df7 = new Series();
        Series df8 = new Series();

        

        public Form1()  
        {
            #region tick timer
            InitializeComponent();
            t = new Timer();
            t.Enabled = true;
            t.Interval = 50;   // must be syncronized with arduino delay value
            t.Tick += T_Tick;
            countAt500ms = 5000 / t.Interval; // graph edge.
            #endregion

            #region turning the graph into a line chart with series
            df0.ChartType = SeriesChartType.Line;
            df1.ChartType = SeriesChartType.Line;
            df2.ChartType = SeriesChartType.Line;
            df3.ChartType = SeriesChartType.Line;
            df4.ChartType = SeriesChartType.Line;
            df5.ChartType = SeriesChartType.Line;
            df6.ChartType = SeriesChartType.Line;
            df7.ChartType = SeriesChartType.Line;
            df8.ChartType = SeriesChartType.Line;

            
            
            //mainChart.ChartAreas[0].AxisX.Maximum =500;  // limitation graph area
            //mainChart.ChartAreas[0].AxisX.Minimum =0;
            




            // adding lines to graph
            mainChart.Series.Add(df0);
            mainChart.Series.Add(df1);
            mainChart.Series.Add(df2);
            mainChart.Series.Add(df3);
            mainChart.Series.Add(df4);
            mainChart.Series.Add(df5);
            mainChart.Series.Add(df6);
            mainChart.Series.Add(df7);
            mainChart.Series.Add(df8);
            #endregion

            #region connecting arduino
            


            string[] ports = SerialPort.GetPortNames();  //addin available port names to combo box
            cmb_ports.Items.AddRange(ports);            
            cmb_ports.SelectedItem= cmb_ports.Items[ports.Length - 1]; // Mostly last item in cmb_ports is the desired one.

            
            #endregion
        }
        



        void NextLine()    // Adding new line to the output txt_out
        {
            
            void MainWork(string whole_line)
            {
                #region printing values for raw data tab
                sns0.Text = whole_line.Substring(1, 3) + "." + whole_line[4] + "\n";
                sns1.Text = whole_line.Substring(5, 3) + "." + whole_line[8] + "\n";
                sns2.Text = whole_line.Substring(9, 3) + "." + whole_line[12] + "\n";
                sns3.Text = whole_line.Substring(13, 3) + "." + whole_line[16] + "\n";           /* -DIVISION OF THE DATA- */
                sns4.Text = whole_line.Substring(17, 3) + "." + whole_line[20] + "\n";
                sns5.Text = whole_line.Substring(21, 3) + "." + whole_line[24] + "\n";
                sns6.Text = whole_line.Substring(25, 3) + "." + whole_line[28] + "\n";
                sns7.Text = whole_line.Substring(29, 3) + "." + whole_line[32] + "\n";
                sns8.Text = whole_line.Substring(33, 3) + "." + whole_line[36] + "\n";
                #endregion

                #region defining numerical data to add to the graph
                float line_sns0 = float.Parse(sns0.Text);
                float line_sns1 = float.Parse(sns1.Text);
                float line_sns2 = float.Parse(sns2.Text);
                float line_sns3 = float.Parse(sns3.Text);
                float line_sns4 = float.Parse(sns4.Text);
                float line_sns5 = float.Parse(sns5.Text);
                float line_sns6 = float.Parse(sns6.Text);
                float line_sns7 = float.Parse(sns7.Text);
                float line_sns8 = float.Parse(sns8.Text);
                #endregion

                #region Checkbox Functions to Add data to GRAPH

                // when the checkbox checked, it turn the same color with related line
                // when unchecked, it turn black as default color

                if (btn_sns0.Checked)
                {
                    df0.Points.Add(line_sns0);
                    df0.Color = Color.Green;
                    btn_sns0.ForeColor = Color.Green;
                }
                else
                {
                    btn_sns0.ForeColor = Color.Black;
                    df0.Points.Add(0);
                }
                if (btn_sns1.Checked)
                {
                    df1.Points.Add(line_sns1);
                    df1.Color = Color.BlueViolet;
                    btn_sns1.ForeColor = Color.BlueViolet;
                }
                else
                {
                    btn_sns1.ForeColor = Color.Black;
                    df1.Points.Add(0);
                }
                if (btn_sns2.Checked)
                {
                    df2.Points.Add(line_sns2);
                    df2.Color = Color.DarkOrange;
                    btn_sns2.ForeColor = Color.DarkOrange;
                }
                else
                {
                    btn_sns2.ForeColor = Color.Black;
                    df2.Points.Add(0);
                }
                if (btn_sns3.Checked)
                {
                    df3.Points.Add(line_sns3);
                    df3.Color = Color.DarkRed;
                    btn_sns3.ForeColor = Color.DarkRed;
                }
                else
                {
                    btn_sns3.ForeColor = Color.Black;
                    df3.Points.Add(0);
                }
                if (btn_sns4.Checked)
                {
                    df4.Points.Add(line_sns4);
                    df4.Color = Color.DarkOliveGreen;
                    btn_sns4.ForeColor = Color.DarkOliveGreen;
                }
                else
                {
                    btn_sns4.ForeColor = Color.Black;
                    df4.Points.Add(0);
                }
                if (btn_sns5.Checked)
                {
                    df5.Points.Add(line_sns5);
                    df5.Color = Color.Gold;
                    btn_sns5.ForeColor = Color.Gold;
                }
                else
                {
                    btn_sns5.ForeColor = Color.Black;
                    df5.Points.Add(0);
                }
                if (btn_sns6.Checked)
                {
                    df6.Points.Add(line_sns6);
                    df6.Color = Color.Purple;
                    btn_sns6.ForeColor = Color.Purple;
                }
                else
                {
                    btn_sns6.ForeColor = Color.Black;
                    df6.Points.Add(0);
                }
                if (btn_sns7.Checked)
                {
                    df7.Points.Add(line_sns7);
                    df7.Color = Color.DarkSalmon;
                    btn_sns7.ForeColor = Color.DarkSalmon;
                }
                else
                {
                    btn_sns7.ForeColor = Color.Black;
                    df7.Points.Add(0);
                }
                if (btn_sns8.Checked)
                {
                    df8.Points.Add(line_sns8);
                    df8.Color = Color.SandyBrown;
                    btn_sns8.ForeColor = Color.SandyBrown;
                }
                else
                {
                    btn_sns8.ForeColor = Color.Black;
                    df8.Points.Add(0);
                }
                #endregion

                #region Switches_raw
                if (whole_line[37].ToString() == "1")
                {
                    sw0.Text = "ON";
                    sw0.ForeColor = Color.Green;
                }
                else { sw0.Text = "OFF"; sw0.ForeColor = Color.Red; }      // Adding Red for OFF
                if (whole_line[38].ToString() == "1")
                {
                    sw1.Text = "ON";                                    // Green for ON 
                    sw1.ForeColor = Color.Green;
                }
                else { sw1.Text = "OFF"; sw1.ForeColor = Color.Red; }    // to the switches.
                if (whole_line[39].ToString() == "1")
                {
                    sw2.Text = "ON";
                    sw2.ForeColor = Color.Green;
                }
                else { sw2.Text = "OFF"; sw2.ForeColor = Color.Red; }
                if (whole_line[40].ToString() == "1")
                {
                    sw3.Text = "ON";
                    sw3.ForeColor = Color.Green;
                }
                else { sw3.Text = "OFF"; sw3.ForeColor = Color.Red; }
                if (whole_line[41].ToString() == "1")
                {
                    sw4.Text = "ON";
                    sw4.ForeColor = Color.Green;
                }
                else { sw4.Text = "OFF"; sw4.ForeColor = Color.Red; }
                if (whole_line[42].ToString() == "1")
                {
                    sw5.Text = "ON";
                    sw5.ForeColor = Color.Green;
                }
                else { sw5.Text = "OFF"; sw5.ForeColor = Color.Red; }
                if (whole_line[43].ToString() == "1")
                {
                    sw6.Text = "ON";
                    sw6.ForeColor = Color.Green;
                }
                else { sw6.Text = "OFF"; sw6.ForeColor = Color.Red; }
                if (whole_line[44].ToString() == "1")
                {
                    sw7.Text = "ON";
                    sw7.ForeColor = Color.Green;
                }
                else { sw7.Text = "OFF"; sw7.ForeColor = Color.Red; }
                txt_out.Text += whole_line;
                #endregion
            }
            try                                     // checking if the data is recieved
            {
                whole_line = choosenPort.ReadLine();
                if (whole_line[0] == '$' && whole_line.Length == 46)    // string manipulation
                {

                    MainWork(whole_line);
                    lbl_signalMessage.Text = "Signal is Available.";
                    lbl_signalMessage.ForeColor= Color.Green;

                }
            }
            catch
            {
                // IF signal is interrupted, graph shows zero value
                whole_line = "$000000000000000000000000000000000000000000000 ";
                MainWork(whole_line);
                lbl_signalMessage.Text = "No Signal!";
                lbl_signalMessage.ForeColor = Color.Red;

            }   
            


        }
        private void T_Tick(object sender, EventArgs e)    // NextLine function working with timer.
        {
            Timer timer = (Timer)sender;

            if (choosenPort.IsOpen)
            {
                NextLine();
                if (currCnt % countAt500ms == 0)
                {
                    mainChart.ChartAreas[0].AxisX.Maximum += 100;//= edges+500;  // limitation graph area
                    mainChart.ChartAreas[0].AxisX.Minimum += 100;//edges;
                    currCnt = 0;
                }


                ++currCnt;

            }                                      
                    
        }           

        private void Form1_Load(object sender, EventArgs e)
        {
            // default port settings but the port name
            choosenPort.BaudRate = 9600;
            choosenPort.Parity = Parity.None;
            choosenPort.StopBits = StopBits.One;
            choosenPort.DataBits = 8;
            choosenPort.ReadTimeout = 50;
            choosenPort.WriteTimeout = 50;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // when the program is closed, port is also closed.
            if (choosenPort.IsOpen)
            {   
                choosenPort.Close();
            }
        }
        
        private void btn_start_Click(object sender, EventArgs e)
        {
            // START - STOP Button Functions.
            
            try // For unavailable ports elimination.
            {
                if (!choosenPort.IsOpen) 
                {
                    choosenPort.Open();
                    btn_start.Text = "STOP";                // when user clicks it turn red and "STOP"
                    btn_start.BackColor = Color.DarkRed;
                    btn_graph_start.Text = "STOP";
                    btn_graph_start.BackColor = Color.DarkRed;
                    cmb_ports.Enabled = false;
                }
                else
                {
                    choosenPort.Close();
                    btn_start.Text = "START";
                    btn_start.BackColor = Color.DarkGreen;      // Else, it turn green and "START"
                    btn_graph_start.Text = "START";
                    btn_graph_start.BackColor = Color.DarkGreen;
                    cmb_ports.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Device is not Available!");
            }

            
                
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {           //Same with above for the little button on graph tab.
            try
            {
                if (!choosenPort.IsOpen)
                {
                    choosenPort.Open();
                    btn_graph_start.Text = "STOP";
                    btn_graph_start.BackColor = Color.DarkRed;
                    btn_start.Text = "STOP";
                    btn_start.BackColor = Color.DarkRed;
                    cmb_ports.Enabled = false;
                }
                else
                {
                    choosenPort.Close();
                    btn_graph_start.Text = "START";
                    btn_graph_start.BackColor = Color.DarkGreen;
                    btn_start.Text = "START";
                    btn_start.BackColor = Color.DarkGreen;
                    cmb_ports.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Device is not Available!");
            }            
        }

        private void cmb_ports_SelectedIndexChanged(object sender, EventArgs e)
        {
            // For combo box 
            try
            {
                choosenPort.PortName = (string)cmb_ports.SelectedItem;
                

            }
            catch
            {
                MessageBox.Show("Device Unavailable");
            }
        }
    }
}
