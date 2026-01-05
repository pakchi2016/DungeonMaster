using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonMaster.status
{
    public partial class status : Form
    {

        public status(statusData statusdata)
        {
            InitializeComponent();

            name.Text = statusdata.CharactorName;
            job.Text = statusdata.CharactorJob;
            HP.Text = statusdata.HP.ToString();
            MP.Text = statusdata.MP.ToString();
            SP.Text = statusdata.SP.ToString();
            attack.Text = statusdata.attack.ToString();
            diffence.Text = statusdata.diffence.ToString();
            speed.Text = statusdata.speed.ToString();
            mental.Text = statusdata.mental.ToString();
            sexual.Text = statusdata.sexual.ToString();
            excite.Text = statusdata.excite.ToString();
        }
    }
}
