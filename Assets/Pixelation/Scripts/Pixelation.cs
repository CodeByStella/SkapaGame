using System;
using Assets.Pixelation.Example.Scripts;
using UnityEngine;

namespace Assets.Pixelation.Scripts
{
    //[ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Pixelation")]
    public class Pixelation : ImageEffectBase
    {
        public static bool shdplus = false;
        [Range(64.0f, 600.0f)] public static float BlockCount = 600.0f;

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            float k = Camera.main.aspect;
            Vector2 count = new Vector2(BlockCount, BlockCount/k);
            Vector2 size = new Vector2(1.0f/count.x, 1.0f/count.y);
            //
            material.SetVector("BlockCount", count);
            material.SetVector("BlockSize", size);
            Graphics.Blit(source, destination, material);
        }

        private void FixedUpdate()
        {
            if (shdplus)
            {
                if (BGMain.pixel && BlockCount >= 120f)
                {
                    BlockCount -= 60f;
                }
                else if (!BGMain.pixel && BlockCount <= 600f)
                {
                    BlockCount += 20f;
                }
            }
            
        }
    }
}