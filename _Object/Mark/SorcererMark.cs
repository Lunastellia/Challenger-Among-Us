using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Roles;
using static ChallengerMod.Unity;


namespace ChallengerMod
{
    class SorcererMark
    {
        private static List<SorcererMark> destroyplayer = new List<SorcererMark>();
        private static Sprite sprite;
        private Color color;
        private GameObject Destroyed;
        private SpriteRenderer spriteRenderer;
        private PlayerControl owner;

        public static Sprite getdestroyplayerprite()
        {
            if (sprite) return sprite;
            sprite = sorcererprezIco;
            return sprite;
        }

        public SorcererMark(float DestroyedDuration, PlayerControl player)
        {
            this.owner = player;
            this.color = Palette.PlayerColors[(int)player.CurrentOutfit.ColorId];

            Destroyed = new GameObject("Destroyed");
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1f);
            Destroyed.transform.position = position;
            Destroyed.transform.localPosition = position;
            Destroyed.transform.SetParent(player.transform.parent);


            spriteRenderer = Destroyed.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = getdestroyplayerprite();
            spriteRenderer.color = color;

            Destroyed.SetActive(true);
            destroyplayer.Add(this);

            HudManager.Instance.StartCoroutine(Effects.Lerp(DestroyedDuration, new Action<float>((p) => {
                Color c = color;
                if (owner != null)
                {
                    c = ChallengerMod.ColorTable.GreyColor;
                }

                if (spriteRenderer) spriteRenderer.color = new Color(c.r, c.g, c.b, Mathf.Clamp01(1 - p));

                if (ChallengerMod.Challenger.IsMeeting == true && ChallengerMod.Utils.Option.CustomOptionHolder.BodyRemove.getBool() == false)
                {
                    UnityEngine.Object.Destroy(Destroyed);
                    destroyplayer.Remove(this);
                }
                else
                {

                }
            })));
        }
    }
}