using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POExileDirection
{
    public static class DeadlyPriceCommon
    {
        public static Dictionary<string, string> itemRarity = new Dictionary<string, string>();

        public static void InitDeadlyPriceCommon()
        {
            InitRarity();
        }

        private static void InitRarity()
        {
            itemRarity.Add("Normal", "일반");
            itemRarity.Add("Magic", "마법");
            itemRarity.Add("Rare", "희귀");
            itemRarity.Add("Unique", "고유");
        }
    }
}
