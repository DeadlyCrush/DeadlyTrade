using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace POExileDirection
{
    public static class DeadlyPriceAPI
    {
        public static void GetItemDataFromClipboard(string strItemClipboardText)
        {
            string[] arrSeparator = { "--------" };
            string[] arrLineSeparator = { "\r\n" };

            #region [[[[[ Item Clipboard Text ]]]]]
            /*
            Rarity: Unique
            Storm's Gift
            Synthesised Assassin's Mitts
            --------
            Quality: +5% (augmented)
            Evasion Rating: 381 (augmented)
            Energy Shield: 73 (augmented)
            --------
            Requirements:
            Level: 58
            Dex: 45
            Int: 45
            --------
            Sockets: B-B 
            --------
            Item Level: 82
            --------
            12% increased Cold Damage (implicit)
            --------
            21% increased Damage over Time
            261% increased Evasion and Energy Shield
            +25% to Lightning Resistance
            Enemies you kill are Shocked
            Shocks you inflict spread to other Enemies within a Radius of 15
            --------
            The power of lightning is a power best shared.
            --------
            Synthesised Item
            */
            /*
            Rarity: Rare
            Vortex Song
            Royal Skean
            --------
            Rune Dagger
            Physical Damage: 16-64
            Critical Strike Chance: 6.30%
            Attacks per Second: 1.45
            Weapon Range: 10
            --------
            Requirements:
            Level: 65
            Dex: 71
            Int: 102
            --------
            Sockets: G-R 
            --------
            Item Level: 82
            --------
            30% increased Global Critical Strike Chance (implicit)
            --------
            Socketed Gems are Supported by Level 20 Poison
            Socketed Gems are supported by Level 18 Increased Critical Damage
            +53 to Dexterity
            +25% to Global Critical Strike Multiplier
            0.28% of Physical Attack Damage Leeched as Life
            10% increased Poison Duration
            --------
            Elder Item

            ▶▶▶▶▶
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - Rarity: Rare
            Vortex Song
            Royal Skean

            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - 
            Rune Dagger
            Physical Damage: 16-64
            Critical Strike Chance: 6.30%
            Attacks per Second: 1.45
            Weapon Range: 10

            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - 
            Requirements:
            Level: 65
            Dex: 71
            Int: 102

            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - 
            Sockets: G-R 

            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - 
            Item Level: 82

            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - 
            30% increased Global Critical Strike Chance (implicit)

            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - 
            Socketed Gems are Supported by Level 20 Poison
            Socketed Gems are supported by Level 18 Increased Critical Damage
            +53 to Dexterity
            +25% to Global Critical Strike Multiplier
            0.28% of Physical Attack Damage Leeched as Life
            10% increased Poison Duration

            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - 
            Elder Item
            2020-02-20 04:28:29,878 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============

            ▶▶▶▶▶
            2020-02-20 04:30:38,625 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:30:38,625 [1] INFO POExileDirection.DeadlyLog4Net - Rarity: Rare
            Mystic Spires
            Defiled Cathedral Map

            2020-02-20 04:30:38,625 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - 
            Map Tier: 4
            Atlas Region: Lira Arthain
            Item Quantity: +95% (augmented)
            Item Rarity: +57% (augmented)
            Monster Pack Size: +37% (augmented)

            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - 
            Item Level: 71

            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - 
            Area has increased monster variety
            21% more Magic Monsters
            16% more Monster Life
            Monsters cannot be Stunned
            Monsters' skills Chain 2 additional times
            Magic Monster Packs each have a Bloodline Mod
            Monsters gain an Endurance Charge on Hit
            All Monster Damage from Hits always Ignites
            Players have Point Blank
            Players have 15% less Area of Effect

            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - 
            Travel to this Map by using it in a personal Map Device. Maps can only be used once.

            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing Start =============
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - 
            Corrupted
            2020-02-20 04:30:38,626 [1] INFO POExileDirection.DeadlyLog4Net - ============= Check Parsing End =============
            */
            #endregion
            
            string strRarity = string.Empty;
            string strName = string.Empty;
            string strBase = string.Empty;
            try
            {
                int nSection = 1;
                string[] arrSplitItemText = strItemClipboardText.Trim().Split(arrSeparator, StringSplitOptions.None);
                foreach(var item in arrSplitItemText)
                {
                    DeadlyLog4Net._log.Info("============= Check Parsing Start =============");
                    DeadlyLog4Net._log.Info(item.ToString());
                    DeadlyLog4Net._log.Info("============= Check Parsing End =============");

                    switch (nSection)
                    {
                        case 1:
                            #region [[[[[ Check - Rarity : Normal, Magic, Rare, Unique, ... ]]]]]
                            // 1st Section : Rarity,Name,Item Base or class(item,map,properchies,divination cards,...)
                            string[] arr1stSection = item.Trim().Split(arrLineSeparator, StringSplitOptions.None);
                            if (arr1stSection.Length > 0)
                            {
                                strRarity = arr1stSection[0].Split(':')[1].Trim();
                                strName = arr1stSection[1];
                                strBase = arr1stSection[2];
                                if (DeadlyPriceCommon.itemRarity.ContainsKey(strRarity))
                                {
                                    DeadlyLog4Net._log.Info(strRarity + " / " + strName + " / " + strBase);
                                }
                                //else if (nSplitCNT == 1)
                                //{

                                //}
                            }
                            #endregion
                            break;
                        case 2:
                            #region [[[[[ Check - Rarity : Normal, Magic, Rare, Unique, ... ]]]]]
                            /*
                            Rune Dagger
                            Physical Damage: 16-64
                            Critical Strike Chance: 6.30%
                            Attacks per Second: 1.45
                            Weapon Range: 10
                            */
                            #endregion
                            break;
                        default:
                            break;
                    }
                    
                    // Item Type or Map Tier, Default Options, Requirements or Item(Zone)Level

                    // Prefix Suffix or Detail map options

                    // Item League

                    // Corrupted and ETC...
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"Parse ItemClipboardText {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }
    }
}
