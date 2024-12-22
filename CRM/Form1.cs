using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Telegram.Bot.Types;
using Telegram.Bot;
using File = System.IO.File;

namespace CRM
{
    public partial class Form1 :Form
    {

        public Form1 ()
        {
            InitializeComponent();
         
        }
        string api = "7086185902:AAFKXbT6eizkElQyocoZ6olLQU2l_GA_fYw";
        string id = "1251198897";
        private void button1_Click (object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label3.Visible = false;
            textBox1.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            tabControl1.Visible = true;
            tabControl2.Visible = false;
            tabControl3.Visible = false;

        }

        private void Form1_Load (object sender, EventArgs e)
        {
            LoadContact();
            LoadZadacha();
            Combobox();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            pictureBox1.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
        }

        private void button2_Click (object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            textBox5.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = true;

        }

        private void button3_Click (object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            tabControl3.Visible = false;
            tabControl1.Visible = false;
            label3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            textBox4.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = true;
            tabControl3.Visible = false;
            textBox5.Visible = false;
        }

        private void button4_Click (object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            textBox1.Visible = false;
            textBox4.Visible = true;
            textBox5.Visible = false;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            label3.Visible = false;
        }

        private void button5_Click (object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            textBox1.Visible = false;
            textBox4.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            textBox5.Visible = true;
            label3.Visible = true;
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            Bitmap image; // открытие изображение

            OpenFileDialog open_dialog = new OpenFileDialog(); 
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; // формат 
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    this.pictureBox1.Size = new Size(100, 100); 
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click (object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Purple;
        }

        private void button7_Click (object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.DarkViolet;
        }

        private void button8_Click (object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.HotPink;
        }

        private void textBox8_TextChanged (object sender, EventArgs e)
        {
        }

        private void textBox9_TextChanged (object sender, EventArgs e)
        {
           
        }

        private void button9_Click (object sender, EventArgs e)
        {

            if (textBox6.Text == "" || textBox9.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;

            }
            else
            {
                //вывод профиля
                string user = $"Имя: {textBox6.Text}{Environment.NewLine}Телефон: {textBox7.Text}{Environment.NewLine}Email: {textBox8.Text}{Environment.NewLine}Пароль: {textBox9.Text}";
                textBox1.Text = user;

            }

            //пароль
            if (textBox9.Text.Length < 6)
                {
                    MessageBox.Show("Длина пароля должна быть больше 5 символов");
                return;
                } 
     
            //телефон
  
            if (textBox7.Text.Length!=11)
            {
                MessageBox.Show("Введите верный номер");
                return;
            }
           
       

        }

        private void textBox7_TextChanged (object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged (object sender, EventArgs e)
        {
          
        }
        //комбобокс добавление
        void Combobox()
        {
            comboBox1.Items.Clear();
            foreach (string obj in listBox1.Items)
            {
                comboBox1.Items.Add(obj);
            }
        }
        //сохранение в файл контакты
        private void SaveToFileCont ()
        {
          
            string filePath = "contacts.txt";
            List<string> contacts= new List<string>();

        
            for (int i =0; i < listBox1.Items.Count; i++)
            {
                contacts.Add(listBox1.Items[i].ToString());
            }

   
           File.WriteAllLines(filePath, contacts);
            MessageBox.Show("Контакт сохранен в файл " + filePath);
            return;
        }
        //чтение из файла контакты
        private void LoadContact ()
        {
            string filePath = "contacts.txt";

            if (File.Exists(filePath))
            {
                string[] contacts = File.ReadAllLines(filePath);
                foreach (string contact in contacts)
                {
                    listBox1.Items.Add(contact);
                }
            }
        }
        //контакт добавление
        private void button10_Click(object sender, EventArgs e)
        {

            if((textBox10.Text!= "") && (textBox11.Text != "") && (textBox11.Text.Length==11))
            {
                listBox1.Items.Add(textBox10.Text + " " + textBox11.Text);
                SaveToFileCont();
                Combobox();
                MessageBox.Show("Контакт добавлен в список");
                return;
            }
            else
            {
                MessageBox.Show("Заполните данные корректно");

    return; 
            }
        }
       //сохранене задачи в файл
        private void SaveToFileZadach ()
        {

            string filePath = "zadacha.txt";
            List<string> z = new List<string>();


            for (int i = 0; i < listBox2.Items.Count; i++)
            {
               z.Add(listBox2.Items[i].ToString());
            }


           File.WriteAllLines(filePath, z);
            MessageBox.Show("Задача добавлена" + " "+filePath);
        }
        //чтение из файла задачи
        private void LoadZadacha ()
        {
            string filePath = "zadacha.txt";

            if (File.Exists(filePath))
            {
                string[] z = File.ReadAllLines(filePath);
                foreach (string zd in z)
                {
                    listBox2.Items.Add(zd);
                }
            }
        }
        private void dateTimePicker1_ValueChanged (object sender, EventArgs e)
        {
           
            label4.Text = dateTimePicker1.Value.ToString("HH:mm");
        }

        //отправить смс о задачах
        private async void button11_Click(object sender, EventArgs e)
        {

            if ((textBox13.Text != "") && (textBox12.Text!="") && (comboBox1.Text!=""))
            {
                string selectedDate = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                string selectedTime = dateTimePicker1.Value.ToString("HH:mm");
                listBox2.Items.Add(textBox13.Text + " " + comboBox1.Text+ " "+ textBox12.Text+" "+selectedDate+ " "+selectedTime );
                SaveToFileZadach();
                var bot = new TelegramBotClient(api);
                await bot.SendTextMessageAsync(id, $"Название компании : { textBox13.Text} {Environment.NewLine}Ответственный: {comboBox1.Text}{Environment.NewLine}Текст задачи: { textBox12.Text} {Environment.NewLine}Дата и время: {selectedDate} {selectedTime}");
                MessageBox.Show("Задача создана");
            }
            else
            {
                MessageBox.Show("Заполните данные");
            }
        }

        private void button12_Click (object sender, EventArgs e)
        {
            button12.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy") + "/" + dateTimePicker1.Value.ToString("HH:mm");
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
