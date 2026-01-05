using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonMaster.dungeon.trap;
using DungeonMaster.status;

namespace DungeonMaster.dungeon
{
    public partial class Trapform : Form
    {
        Boolean[] bools = { false, false };

        int phase = 0;

        int trapPower = 100;

        private Random random = new Random();
        private statusData statusdata;
        private Roper roper;

        public Trapform(statusData statusdata)
        {
            InitializeComponent();
            this.statusdata = statusdata;
            statusUpdate();
            textBox1.AppendText("罠が発動した！！\r\n");
            button1.Text = "脱出を試みる";

            if (random.Next(1, 100) > 0)
            {
                phase = 1;
                roper = new Roper(this, statusdata);
            }
        }

        public void setLog(string message) => textBox1.AppendText(message +  Environment.NewLine);

        public void setButtonText(string text) => button1.Text = text;

        public void statusUpdate()
        {
            if(statusdata.mental < 0) statusdata.mental = 0;

            HP.Text = statusdata.HP.ToString();
            MP.Text = statusdata.MP.ToString();
            SP.Text = statusdata.SP.ToString();
            mental.Text = statusdata.mental.ToString();
            sexual.Text = statusdata.sexual.ToString();
            excite.Text = statusdata.excite.ToString();
            nipple.Text = statusdata.nipple.ToString();
            clitoris.Text = statusdata.clitoris.ToString();
            vagina.Text = statusdata.vagina.ToString();
            masohism.Text = statusdata.masohism.ToString();
            exhibit.Text = statusdata.exhibit.ToString();
            wepon.Text = statusdata.wepon;
            armor.Text = statusdata.armor;
            cloth.Text = statusdata.cloth;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (phase == 1) bools = roper.RoperTraps(bools);
            statusUpdate();         
        }
    }
}
