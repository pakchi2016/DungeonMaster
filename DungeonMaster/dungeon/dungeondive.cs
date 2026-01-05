using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DungeonMaster;
using DungeonMaster.status;

namespace DungeonMaster.dungeon
{
    internal class DungeonDive
    {
        int laststep = 10;
        private Form1 form;
        private Trapform trapform;

        public DungeonDive(Form1 form, statusData statusdata)
        {
            this.form = form;
            this.trapform = new Trapform(statusdata);
            form.textBox1.AppendText("第1階層へ到達しました。\r\n");
        }

        public int[] ClickNext(statusData statusdata, int[] count)
        {
            var getstep = new getStep();
            int step = count[0];
            int getStep = getstep.getRandomStep(statusdata.speed);
            int floor = count[1];
            if ((step + getStep ) > (laststep * floor))
            {
                form.textBox1.AppendText($"第{floor + 1}階層への階段を見つけました。\r\n");
                return new int[] { 1, floor + 1 };
            }
            else
            {
                string[] lines = form.textBox1.Lines;
                string textline = "";
                if (step > 1)
                {
                    for (int i = 0; i < lines.Length - 2; i++)
                    {
                        textline += $"{lines[i]}\r\n";
                    }

                    form.textBox1.Text = textline;
                }
                var encanto = new Encanto();
                int encantoPoint = encanto.setEncanto();
                string encantoType = encanto.encantoType[encantoPoint];
                form.textBox1.AppendText($"第{floor}階層を探索しています。(×{step})\r\n");
                switch (encantoPoint)
                {
                    case 1:
                        trapform.ShowDialog();
                        break;
                    case 2:
                        form.textBox1.AppendText("モンスターと遭遇した。\r\n");
                        break;
                    case 3:
                        form.textBox1.AppendText("宝箱を開けて、50ゴールドを手に入れた。\r\n");
                        break;
                    default:
                        break;
                }
                return new int[] { step + getStep, floor };
            }
        }
    }
}
