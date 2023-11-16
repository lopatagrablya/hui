using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace бильярдный_шар
{
    public partial class Form1 : Form
    {
        int x = 0;
        int y = 0;
        int speed = 1;
        int directionX = 1; // направление движения по оси X
        int directionY = 1; // направление движения по оси Y
        Color currentColor = Color.Black;
        SoundPlayer player = new SoundPlayer("C:\\Users\\Maria\\Desktop\\Технология программирования\\сделанные\\бильярдный шар\\zvuk-udara-po-myachiku.wav");
        public Form1()
        {
            InitializeComponent();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            speed = (int)numericUpDown1.Value;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // очищаем PictureBox
            e.Graphics.Clear(Color.White);

            // рисуем шарик с текущими координатами
            e.Graphics.FillEllipse(new SolidBrush(currentColor), x, y, 20, 20);
            //e.Graphics.DrawEllipse(Pens.Black, x, y, 20, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // изменяем координаты шарика на заданную скорость
            x += speed * directionX;
            y += speed * directionY;

            // проверяем выход за пределы PictureBox по оси X
            if (x < 0 || x > pictureBox1.Width - 20)
            {
                directionX *= -1; // меняем направление движения
                currentColor = (currentColor == Color.Black) ? Color.Red : Color.Black;
                player.Play();
            }

            // проверяем выход за пределы PictureBox по оси Y
            if (y < 0 || y > pictureBox1.Height - 20)
            {
                directionY *= -1; // меняем направление движения
                currentColor = (currentColor == Color.Black) ? Color.Red : Color.Black;
                player.Play();
            }

            // перерисовываем PictureBox
            pictureBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // запускаем таймер для обновления PictureBox
            timer1.Start();
        }
    }
}
