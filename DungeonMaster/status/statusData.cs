namespace DungeonMaster.status
{
    public class statusData
    {
        private Form1 form;
        Random random = new Random();

        public string CharactorName = "";
        public string CharactorJob = "";
        public int HP;
        public int MP;
        public int SP;
        public int attack;
        public int diffence;
        public int speed;
        public string wepon = "";
        public int weponAttack;
        public int weponLife;
        public string armor = "";
        public int armorDiffence;
        public int armorLife;
        public string cloth = "";
        public int clothDiffence;
        public int clothLife;
        public int mental = 100;
        public int sexual = 1;
        public int excite = 1;
        public int nipple;
        public int nippleOrgasm;
        public int nippleOrgasmCount;
        public int clitoris;
        public int clitorisOrgasm;
        public int clitorisOrgasmCount;
        public int vagina;
        public int vaginaOrgasm;
        public int vaginaOrgasmCount;
        public int masohism;
        public int exhibit;
        public int totalOrgasmCount;

        public statusData(Form1 form)
        {
            this.form = form;
        }
    }
}