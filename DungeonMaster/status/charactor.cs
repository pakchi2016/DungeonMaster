using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.status
{
    internal class Charactor
    {
        private static readonly string[] Name = { "エリカ", "アリーシャ", "ディアドラ", "クラサハ", "エレナ" };
        private static readonly string[] job = { "村娘", "奴隷", "傭兵", "狩人", "姫騎士" };
        private static readonly int[] HP = { 20, 20, 100, 50, 30 };
        private static readonly int[] MP = { 0, 20, 0, 50, 100 };
        private static readonly int[] SP = { 0, 10, 80, 50, 30 };
        private static readonly int[] attack = {5, 10, 40, 20, 20 };
        private static readonly int[] diffence = { 5, 10, 50, 10, 10 };
        private static readonly int[] speed = {5, 20, 15, 50, 30 };
        private static readonly string[] wepon = { "武器なし", "武器なし", "バスターソード", "ミスリルナイフ", "王家の剣" };
        private static readonly int[] weponAttack = { 0, 0, 30, 10, 50 };
        private static readonly int[] weponLife = { 0, 0, 30, 100, 100 };
        private static readonly string[] armor = { "鎧なし", "鎧なし", "ビキニアーマ", "胸当て", "ホーリーガード" };
        private static readonly int[] armorDiffence = { 0, 0, 5, 10, 50 };
        private static readonly int[] armorLife = { 0, 0, 5, 20, 100 };
        private static readonly string[] cloth = { "布の服", "ボロ", "マント", "シルフローブ", "パラディンドレス" };
        private static readonly int[] clothDiffence = { 10, 5, 10, 20, 15 };
        private static readonly int[] clothLife = { 5, 3, 30, 50, 50 };

        public static void setData(int number, statusData statusdata,Form1 form)
        {
            statusdata.CharactorName = Name[number];
            statusdata.CharactorJob = job[number];
            statusdata.HP = HP[number];
            statusdata.MP = MP[number];
            statusdata.SP = SP[number];
            statusdata.attack = attack[number];
            statusdata.diffence = diffence[number];
            statusdata.speed = speed[number];
            statusdata.wepon = wepon[number];
            statusdata.weponAttack = weponAttack[number];
            statusdata.weponLife = weponLife[number];
            statusdata.armor = armor[number];
            statusdata.armorDiffence = diffence[number];
            statusdata.armorLife = armorLife[number];
            statusdata.cloth = cloth[number];
            statusdata.clothDiffence = clothDiffence[number];
            statusdata.clothLife = clothLife[number];

            form.name.Text = Name[number];
            form.job.Text = job[number];

        }


    }
}
