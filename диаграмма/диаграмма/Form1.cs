using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace диаграмма
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
          
            
        }




       

        private void Form1_Load(object sender, EventArgs e)
        {
            




        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int rowsCount = (int)numericUpDown1.Value;

            DataTable table = new DataTable();

            dataGridView1.DataSource = table;

            table.Columns.Add("№ п.п.", typeof(int));
            table.Columns.Add("Товар", typeof(string));
            table.Columns.Add("Цена", typeof(int));
            table.Columns.Add("Количество", typeof(int));
            table.Columns.Add("Стоимость", typeof(int));

            table.Rows.Add("1", "Бананы", 10, 50, 500);
            table.Rows.Add("2", "Киви", 20, 50, 1000);
            table.Rows.Add("3", "Яблоки", 30, 50, 1500);
            table.Rows.Add("4", "Апельсины", 15, 30, 450);
            table.Rows.Add("5", "Мандарины", 28, 15, 420);
            table.Rows.Add("6", "Виноград", 37, 22, 814);



            if (rowsCount < table.Rows.Count)
            {
                
                for (int i = table.Rows.Count - 1; i >= rowsCount; i--)
                {
                    table.Rows.RemoveAt(i);
                }
            }


            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart2.Series.Clear();
            chart2.Titles.Clear();

            var columnSeries = new Series("Стоимость");
            columnSeries.ChartType = SeriesChartType.Column;

            
            var pieSeries = new Series("Стоимость");
            pieSeries.ChartType = SeriesChartType.Pie;
            //var series = new Series("Стоимость");
            //series.ChartType = SeriesChartType.Column;//pie




            int totalCost = 0;
            foreach (DataRow row in table.Rows)
            {
                totalCost += Convert.ToInt32(row["Стоимость"]);
            }

            
            for (int i = 0; i < table.Rows.Count; i++)
            {

                double percentage = Convert.ToDouble(table.Rows[i]["Стоимость"]) / totalCost * 100;

                // Add points to the column series
                columnSeries.Points.AddXY(table.Rows[i]["Товар"].ToString(), percentage);
                columnSeries.Points[i].Label = "#PERCENT{P0}";
                columnSeries.Points[i].LegendText = table.Rows[i]["Товар"].ToString() + " - " + table.Rows[i]["Стоимость"].ToString() + " руб.";

                // Add points to the pie series
                pieSeries.Points.AddXY(table.Rows[i]["Товар"].ToString(), percentage);
                pieSeries.Points[i].Label = "#PERCENT{P0}";
                pieSeries.Points[i].LegendText = table.Rows[i]["Товар"].ToString() + " - " + table.Rows[i]["Стоимость"].ToString() + " руб.";
            }


            chart1.Series.Add(columnSeries);
            chart2.Series.Add(pieSeries);


            chart1.Titles.Add("Стоимость товаров");
            chart2.Titles.Add("Стоимость товаров");


            chart1.Update();
            chart2.Update();
        }



    }

          
    }

