using DungeonMaster.dungeon;
using DungeonMaster.status;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DungeonMaster
{
    public partial class Form1 : Form
    {
        public int phase = 0;
        private statusData statusdata;
        private DungeonDive dive;

        int[] floor = new int[] { 1, 1 };

        public Form1()
        {
            InitializeComponent();
            statusdata = new statusData(this);
            Charactor.setData(0,statusdata,this);
            next.Visible = false;
            back.Visible = false;

            textBox1.AppendText("冒険の準備をしましょう。\r\n");
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (dungeon.Checked)
            {
                textBox1.AppendText("ダンジョンに潜ります。\r\n");
                dive = new DungeonDive(this, statusdata);
                phase = 1;
                next.Visible = true;
                back.Visible = true;
                button1.Enabled = false;
            }
            else if (city.Checked)
            {
                textBox1.AppendText("街で買い物をします。\r\n");
                phase = 2;
            }
            else if (bar.Checked)
            {
                textBox1.AppendText("酒場で情報収集をします。\r\n");
                phase = 3;
            }
        }

        public void next_Click_1(object sender, EventArgs e)
        {
            if (phase == 1)
            {
                floor = dive.ClickNext(statusdata, floor);
                if (statusdata.HP <= 0)
                {
                    textBox1.AppendText("あなたは力尽きました。街に戻ります。\r\n");
                    next.Visible = false;
                    back.Visible = false;
                    button1.Enabled = true;
                    phase = 0;
                }
            }
        }

        public void back_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("街に戻りました。\r\n");
            next.Visible = false;
            back.Visible = false;
            button1.Enabled = true;
            phase = 0;
        }

        public void status_Click(object sender, EventArgs e)
        {
            var status = new status.status(statusdata);
            status.Show();
        }

        public void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
