using DungeonMaster.status;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.dungeon.trap
{
    internal class Roper
    {
        private int roperAttack = 100;
        private int roperPower;
        private int CharactorPower;

        private Trapform trapform;
        private statusData statusdata;

        private Random random = new Random();

        public Roper(Trapform form, statusData statusdata) 
        {
            this.trapform = form;
            this.statusdata = statusdata;
            trapform.setLog("ローパーの罠だ！！");

        }
        public Boolean[] RoperTraps(Boolean[] bools) 
        {
            if (bools[0]) trapform.Close();

            if (!bools[1])
            {
                trapform.setLog("脱出を試みた！！");
                Thread.Sleep(500);
                int roperPower = random.Next(1, roperAttack);
                int charactorPower = (statusdata.attack + statusdata.weponAttack) * (statusdata.mental / 100);
                if (roperPower < charactorPower)
                {
                    trapform.setLog("脱出に成功した！！\r\n");
                    trapform.setButtonText("探索に戻る");
                    
                    return new Boolean[] { true, false };
                }
                else
                {
                    trapform.setLog("脱出に失敗した！！ローパーが襲い掛かる！！");
                    Thread.Sleep(500);
                    statusdata.mental -= 3;
                    roperPower = random.Next(1, roperAttack);
                    charactorPower = (statusdata.diffence + statusdata.armorDiffence + statusdata.clothDiffence) * (statusdata.mental / 100);
                    if (roperPower < charactorPower)
                    {
                        trapform.setLog("ローパーを振りほどいた！！");
                        trapform.setButtonText("脱出を試みる");
                        return new Boolean[] {false, false};
                    }
                    else
                    {
                        trapform.setLog("ローパーに絡みつかれた！！");
                        statusdata.mental -= 5;
                        trapform.setButtonText("ローパーを振りほどく");

                        return new Boolean[] {false, true};
                    }
                }
            }
            else
            {
                if (statusdata.mental > 0)
                {
                    roperPower = random.Next(1, roperAttack);
                    CharactorPower = (statusdata.diffence + statusdata.armorDiffence) * (statusdata.mental / 100);
                    trapform.setLog($"{statusdata.CharactorName} はローパーを振りほどこうとしている！！");
                    Thread.Sleep(500);
                    if (roperPower < CharactorPower)
                    {
                        trapform.setLog("ローパーを振りほどいた！！");
                        return new Boolean[] { false, false };
                    }
                    else
                    {
                        trapform.setLog("振りほどけなかった！！");
                        Thread.Sleep(500);
                        if (statusdata.armorLife > 0)
                        {
                            trapform.setLog($"ローパーは {statusdata.armor} を外そうとしている！！");
                            Thread.Sleep(500);
                            statusdata.armorLife -= (random.Next(1, roperAttack) - statusdata.armorDiffence) / 10;
                            if (statusdata.armorLife <= 0)
                            {
                                trapform.setLog($"{statusdata.armor} が壊れた！！");
                                statusdata.armor = "鎧なし";
                                statusdata.armorLife = 0;
                                statusdata.armorDiffence = 0;
                            }
                            else
                            {
                                trapform.setLog($"{statusdata.CharactorName} は抵抗した！！");
                            }
                            return new Boolean[] { false, true };
                        }
                        else
                        {
                            if (statusdata.clothLife > 0)
                            {
                                trapform.setLog($"ローパーは {statusdata.cloth} を脱がせようとしている！！");
                                Thread.Sleep(500);
                                statusdata.clothLife -= (random.Next(1, roperAttack) - statusdata.clothDiffence) / 10;
                                if (statusdata.clothLife <= 0)
                                {
                                    trapform.setLog($"{statusdata.cloth} を脱がされた！！");
                                    statusdata.clothLife = 0;
                                    statusdata.clothDiffence = 0;
                                    statusdata.cloth = "裸";
                                }
                                else
                                {
                                    trapform.setLog($"{statusdata.CharactorName} は抵抗した！！");
                                }
                                return new Boolean[] { false, true };
                            }
                            else
                            {
                                rape();
                                return new Boolean[] { false, true };
                            }
                        }
                    }
                }
                else
                {

                    rape();
                    return new Boolean[] { false, true };
                }
                

            }
            
        }

        private void rape()
        {
            if(statusdata.mental <= 0)
            {
                trapform.setButtonText("・・・");
            }

            switch (random.Next(0,3))
            {
                case 0:
                    Orgasm
                    (
                        ref statusdata.nipple, 
                        ref statusdata.nippleOrgasm,
                        ref statusdata.nippleOrgasmCount,
                        "はローパーに乳首をねぶられている！！",
                        "は全身を仰け反らせて絶頂した！！"
                    );
                    break;
                case 1:
                    Orgasm
                    (
                        ref statusdata.clitoris,
                        ref statusdata.clitorisOrgasm,
                        ref statusdata.clitorisOrgasmCount,
                        "はローパーにクリトリスを責められている！！",
                        "は全身を痙攣させながら絶頂した！！"
                    );
                    break;
                case 2:
                    Orgasm
                    (
                        ref statusdata.vagina,
                        ref statusdata.vaginaOrgasm,
                        ref statusdata.vaginaOrgasmCount,
                        "はローパーの触手で膣内をかき混ぜられている！！",
                        "は吠え叫びながら絶頂した！！"
                    );
                    break;
                default:
                    break;
            }
            trapform.statusUpdate();
        }

        private void Orgasm(ref int parts, ref int orgasm, ref int orgasmCount, string roperMsg, string orgasmMsg)
        {
            statusdata.excite++;
            orgasm += (statusdata.sexual * statusdata.excite) + parts;
            trapform.setLog($"{statusdata.CharactorName} {roperMsg} 絶頂指数:{orgasm} 絶頂回数:{orgasmCount}");
            statusdata.mental = statusdata.mental < 3 ? 0 :  statusdata.mental - 3;
            Thread.Sleep(500);
            if (orgasm >= 100)
            {
                trapform.setLog($"{statusdata.CharactorName} {orgasmMsg}");
                orgasmCount++;
                orgasm = 1;
                parts = (int)(orgasmCount / 5);
                statusdata.excite = 1;
                statusdata.sexual++;
                if (1 <= statusdata.mental && statusdata.mental <= 10)
                {
                    statusdata.mental = 0;
                    trapform.setLog($"{statusdata.CharactorName} は失神した・・・。");
                }
                else
                { 
                    statusdata.mental -= 10;
                }
                if(statusdata.mental <= 0)
                {
                    statusdata.HP -= 1;
                    if (statusdata.HP <= 0)
                    {
                        statusdata.HP = 0;
                        trapform.setLog($"{statusdata.CharactorName} は力尽きた・・・。");
                        trapform.Close();
                    }
                }
            }
        }
    }
}
