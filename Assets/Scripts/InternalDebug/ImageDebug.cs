﻿using System;
using Terrain.Noise;
using UnityEngine;

namespace InternalDebug
{
    public class ImageDebug
    {
        public static void SaveImg(Vector2Int size, INoise noise, string name)
        {
            try
            {
                Texture2D texture = new Texture2D(size.x, size.y);
                for (int y = 0; y < texture.height; y++)
                {
                    for (int x = 0; x < texture.width; x++)
                    {
                        float v = (noise.GetNoise(x, y) + 1) * 0.5f;
                        Color color = new Color(v, v, v);
                        texture.SetPixel(x, y, color);
                    }
                }

                texture.Apply();
                SaveTextureAsPNG(texture, name);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error while trying to create image of noise " + name + ". " + Environment.NewLine + ex.ToString());
            }
        }
        
        
        public static void SaveTextureAsPNG(Texture2D _texture, string _path)
        {
            byte[] _bytes =_texture.EncodeToPNG();
            System.IO.File.WriteAllBytes("Debug/Images/" + _path, _bytes);
            Debug.Log(_bytes.Length/1024  + "Kb was saved as: Debug/Images/" + _path);
        }
    }
}