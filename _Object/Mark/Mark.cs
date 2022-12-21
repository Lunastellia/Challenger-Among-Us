using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Roles;
using static ChallengerMod.Unity;
using static ChallengerMod.HarmonyMain;
using static ChallengerMod.Utils.Option.CustomOptionHolder;

namespace ChallengerMod
{
    class Footprint
    {
        private static List<Footprint> footprints = new List<Footprint>();
        private static Sprite sprite;
        private Color color;
        private GameObject footprint;
        private SpriteRenderer spriteRenderer;
        private PlayerControl owner;
        private bool anonymousFootprints;

        public static Sprite getFootprintSprite()
        {
            if (sprite) return sprite;
            sprite = FPrint;
            return sprite;
        }

        public Footprint(float footprintDuration, bool anonymousFootprints, PlayerControl player)
        {
            this.owner = player;
            this.anonymousFootprints = anonymousFootprints;
            if (anonymousFootprints)
                this.color = Palette.PlayerColors[6];
            else
                this.color = Palette.PlayerColors[(int)player.CurrentOutfit.ColorId];

            footprint = new GameObject("Footprint");
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1f);
            footprint.transform.position = position;
            footprint.transform.localPosition = position;
            footprint.transform.SetParent(player.transform.parent);
            footprint.transform.Rotate(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f));


            spriteRenderer = footprint.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = getFootprintSprite();
            spriteRenderer.color = color;

            footprint.SetActive(true);
            footprints.Add(this);

            HudManager.Instance.StartCoroutine(Effects.Lerp(footprintDuration, new Action<float>((p) => {
                Color c = color;
                if (!anonymousFootprints && owner != null)
                {
                    if (owner == Morphling.Role && Morphling.Morphed == true && Morphling.Morph != null)
                        c = Palette.ShadowColors[Morphling.Morph.CurrentOutfit.ColorId];
                    else if (Scrambler.Role != null && Scrambler.Camo == true)
                        c = Palette.ShadowColors[7];
                    else if (CommsSabotageAnonymous.getSelection() == 1)
                    {
                        foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                        {
                            if (task.TaskType == TaskTypes.FixComms)
                            {
                                c = Palette.ShadowColors[6];

                            }
                        }
                    }




                }

                if (spriteRenderer) spriteRenderer.color = new Color(c.r, c.g, c.b, Mathf.Clamp01(1 - p));

                if (p == 1f && footprint != null)
                {
                    UnityEngine.Object.Destroy(footprint);
                    footprints.Remove(this);
                }
            })));
        }
    }
}