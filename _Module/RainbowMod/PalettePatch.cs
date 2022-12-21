using UnityEngine;

namespace ChallengerMod.RainbowPlugin
{
    public static class PalettePatch
    {
        public static void Load()
        {
            Palette.ColorNames = new[]
            {
                StringNames.ColorRed,
                StringNames.ColorBlue,
                StringNames.ColorGreen,
                StringNames.ColorPink,
                StringNames.ColorOrange,
                StringNames.ColorYellow,
                StringNames.ColorBlack,
                StringNames.ColorWhite,
                StringNames.ColorPurple,
                StringNames.ColorBrown,
                StringNames.ColorCyan,
                StringNames.ColorLime,
                StringNames.ColorMaroon,
                StringNames.ColorRose,
                StringNames.ColorBanana,
                StringNames.ColorGray,
                StringNames.ColorTan,
                StringNames.ColorCoral,
               
                // New colours
                
                (StringNames)999982,
                (StringNames)999983,
                (StringNames)999984,
                (StringNames)999985,
                (StringNames)999986,
                (StringNames)999987,
                
                (StringNames)999988,
                (StringNames)999989,
                (StringNames)999990,
                (StringNames)999991,
                (StringNames)999992,
                (StringNames)999993,
               
                (StringNames)999994,
                (StringNames)999995,
                (StringNames)999996,
                (StringNames)999997,
                (StringNames)999998,
                (StringNames)999999,

            };
            
            Palette.PlayerColors = new[]
            {
                new Color32(198, 17, 17, byte.MaxValue),
                new Color32(19, 46, 210, byte.MaxValue),
                new Color32(17, 128, 45, byte.MaxValue),
                new Color32(238, 84, 187, byte.MaxValue),
                new Color32(240, 125, 13, byte.MaxValue),
                new Color32(246, 246, 87, byte.MaxValue),
                new Color32(63, 71, 78, byte.MaxValue),
                new Color32(215, 225, 241, byte.MaxValue),
                new Color32(107, 47, 188, byte.MaxValue),
                new Color32(113, 73, 30, byte.MaxValue),
                new Color32(56, byte.MaxValue, 221, byte.MaxValue),
                new Color32(80, 240, 57, byte.MaxValue),
                Palette.FromHex(6233390),
                Palette.FromHex(15515859),
                Palette.FromHex(15787944),
                Palette.FromHex(7701907),
                Palette.FromHex(9537655),
                Palette.FromHex(14115940),
                
                // New colours

                new Color32(215, 0, 0, byte.MaxValue),//TrueRed
                new Color32(125, 80, 0, byte.MaxValue),//TrueBrown
                new Color32(255, 130, 40, byte.MaxValue),//TrueOrange
                new Color32(255, 220, 0, byte.MaxValue),//TrueYellow
                new Color32(125, 255, 0, byte.MaxValue),//TrueLGreen
                new Color32(0, 180, 0, byte.MaxValue),//TrueMGreen
               
                new Color32(60, 110, 60, byte.MaxValue),//TrueDGreen
                new Color32(65, 255, 180, byte.MaxValue),//TrueBlueGreen
                new Color32(0, 255, 255, byte.MaxValue),//TrueLBlue
                new Color32(125, 125, 255, byte.MaxValue),//TrueMBlue
                new Color32(60, 60, 180, byte.MaxValue),//TrueDBlue
                new Color32(160, 0, 220, byte.MaxValue),//TrueDPurple
               
                new Color32(250, 120, 250, byte.MaxValue),//TrueLPink
                new Color32(255, 0, 255, byte.MaxValue),//TrueDPink
                new Color32(255, 255, 255, byte.MaxValue),//TrueWhite
                new Color32(125, 125, 125, byte.MaxValue),//TrueGrey
                new Color32(15, 15, 15, byte.MaxValue), //TrueBlack
                new Color32(0, 0, 0, byte.MaxValue), //Rainbow


            };
            Palette.ShadowColors = new[]
            {
                new Color32(122, 8, 56, byte.MaxValue),
                new Color32(9, 21, 142, byte.MaxValue),
                new Color32(10, 77, 46, byte.MaxValue),
                new Color32(172, 43, 174, byte.MaxValue),
                new Color32(180, 62, 21, byte.MaxValue),
                new Color32(195, 136, 34, byte.MaxValue),
                new Color32(30, 31, 38, byte.MaxValue),
                new Color32(132, 149, 192, byte.MaxValue),
                new Color32(59, 23, 124, byte.MaxValue),
                new Color32(94, 38, 21, byte.MaxValue),
                new Color32(36, 169, 191, byte.MaxValue),
                new Color32(21, 168, 66, byte.MaxValue),
                Palette.FromHex(4263706),
                Palette.FromHex(14586547),
                Palette.FromHex(13810825),
                Palette.FromHex(4609636),
                Palette.FromHex(5325118),
                Palette.FromHex(11813730),
                
                // New colours

                new Color32(215, 0, 0, byte.MaxValue),//TrueRed
                new Color32(125, 80, 0, byte.MaxValue),//TrueBrown
                new Color32(255, 130, 40, byte.MaxValue),//TrueOrange
                new Color32(255, 220, 0, byte.MaxValue),//TrueYellow
                new Color32(125, 255, 0, byte.MaxValue),//TrueLGreen
                new Color32(0, 180, 0, byte.MaxValue),//TrueMGreen
               
                new Color32(60, 110, 60, byte.MaxValue),//TrueDGreen
                new Color32(65, 255, 180, byte.MaxValue),//TrueBlueGreen
                new Color32(0, 255, 255, byte.MaxValue),//TrueLBlue
                new Color32(125, 125, 255, byte.MaxValue),//TrueMBlue
                new Color32(60, 60, 180, byte.MaxValue),//TrueDBlue
                new Color32(160, 0, 220, byte.MaxValue),//TrueDPurple
               
                new Color32(250, 120, 250, byte.MaxValue),//TrueLPink
                new Color32(255, 0, 255, byte.MaxValue),//TrueDPink
                new Color32(255, 255, 255, byte.MaxValue),//TrueWhite
                new Color32(125, 125, 125, byte.MaxValue),//TrueGrey
                new Color32(15, 15, 15, byte.MaxValue), //TrueBlack
                new Color32(0, 0, 0, byte.MaxValue), //Rainbow


                
            };
        }
    }
}
