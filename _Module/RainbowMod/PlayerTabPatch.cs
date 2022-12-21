using System;
using HarmonyLib;
using UnityEngine;

namespace ChallengerMod.RainbowPlugin
{
    [HarmonyPatch(typeof(PlayerTab))]
    public static class PlayerTabPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(PlayerTab.OnEnable))]
        public static void OnEnablePostfix(PlayerTab __instance)
        {
           
            
            
            for (int i = 0; i < __instance.ColorChips.Count; i++)
            {
                var colorChip = __instance.ColorChips[i];
                colorChip.transform.localScale *= 0.65f;



                var x = __instance.XRange.Lerp((i % 6) / 5f) + 0.15f;
                var offset = 0.0f;
                if (i >= 18)
                {
                    offset = 0.25f;
                }
                var y = __instance.YStart - (i / 6 * 0.4f) - offset;
                colorChip.transform.localPosition = new Vector3(x, y, -1f);

                if (i <= 17)
                {
                    UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                    X.size = new Vector2(0.65f, 0.65f);
                    UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                    Z.sprite = ChallengerMod.Unity.ColorUnlock;
                }

                if (i >= 18)
                {
                    if (i == 18)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Bloody)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 19)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Earth)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 20)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Chedard)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 21)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Sun)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 22)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Leef)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 23)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Radian)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 24)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Swamp)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 25)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Ice)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 26)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Lagoon)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 27)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Ocean)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 28)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Night)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 29)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Dawn)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 30)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Candy)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 31)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Galaxy)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 32)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Snow)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 33)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Cender)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 34)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Dark)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }
                    if (i == 35)
                    {
                        if (!ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Rainbow)
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0f, 0f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorLock;
                        }
                        else
                        {
                            UnityEngine.BoxCollider2D X = colorChip.GetComponent<UnityEngine.BoxCollider2D>();
                            X.size = new Vector2(0.65f, 0.65f);
                            UnityEngine.SpriteRenderer Z = X.GetComponentInParent<SpriteRenderer>();
                            Z.sprite = ChallengerMod.Unity.ColorUnlock;
                        }
                    }





                }

                

            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(PlayerTab.Update))]
        public static void UpdatePostfix(PlayerTab __instance)
        {
            for (int i = 0; i < __instance.ColorChips.Count; i++)
            {
                if (RainbowUtils.IsRainbow(i))
                {
                    __instance.ColorChips[i].Inner.SpriteColor = RainbowUtils.Rainbow;
                    break;
                }
            }

        }
    }
}
