using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Roles;
using static ChallengerMod.Unity;


namespace ChallengerMod
{
    class EaterMark
    {
        private static List<EaterMark> eatedBodys = new List<EaterMark>();
        private static Sprite sprite;
        private Color color;
        private GameObject eatedBody;
        private SpriteRenderer spriteRenderer;
        private PlayerControl owner;

        public static Sprite getEatedBodySprite()
        {
            if (sprite) return sprite;
            sprite = BloodIco;
            return sprite;
        }

        public EaterMark(float eatedBodyDuration, PlayerControl player)
        {
            this.owner = player;
            this.color = Palette.PlayerColors[(int)player.CurrentOutfit.ColorId];

            eatedBody = new GameObject("EatedBody");
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1f);
            eatedBody.transform.position = position;
            eatedBody.transform.localPosition = position;
            eatedBody.transform.SetParent(player.transform.parent);


            spriteRenderer = eatedBody.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = getEatedBodySprite();
            spriteRenderer.color = color;

            eatedBody.SetActive(true);
            eatedBodys.Add(this);

            HudManager.Instance.StartCoroutine(Effects.Lerp(eatedBodyDuration, new Action<float>((p) => {
                Color c = color;
                if (owner != null)
                {
                    c = ChallengerMod.ColorTable.GreyColor;
                }

                if (spriteRenderer) spriteRenderer.color = new Color(c.r, c.g, c.b, Mathf.Clamp01(1 - p));

                if (ChallengerMod.Challenger.IsMeeting == true && ChallengerMod.Utils.Option.CustomOptionHolder.BodyRemove.getBool() == false)
                {
                    UnityEngine.Object.Destroy(eatedBody);
                    eatedBodys.Remove(this);
                }
                else
                {

                }
            })));
        }
    }
}