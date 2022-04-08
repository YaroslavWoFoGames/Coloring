using System;
using System.Collections.Generic;
using UnityEngine;

public class Fill : DrawingTools
{
    public override void Draw(Texture2D texture, Point coordinate, Color futureСolor, Color currentColor, int brushSize)
    {
        FillAreaWithNewColor(texture, coordinate, futureСolor, currentColor);
    }

    private void FillAreaWithNewColor(Texture2D texture, Point coordinate, Color futureСolor, Color currentColor)
    {

        if (GetAverageColor(currentColor) > GetAverageColor(Color.black) + PIXEL_CAPTURE_RATE)
        {

            int[,] arrayOfValues = new int[texture.width, texture.height];

            List<Tuple<int, int>> pixels = new List<Tuple<int, int>>();

            pixels.Add(new Tuple<int, int>(coordinate.X, coordinate.Y));

            arrayOfValues[coordinate.X, coordinate.Y] = 1;

            while (pixels.Count > 0)
            {
                Tuple<int, int> pixel = pixels[0];
                int x = pixel.Item1;
                int y = pixel.Item2;
                Color pastColor = texture.GetPixel(x, y);
                texture.SetPixel(x, y, futureСolor);
                pixels.RemoveAt(0);
                float mediumColor = GetAverageColor(pastColor);

                for (int i = 0; i < 4; i++)
                {
                    int cx = x;
                    int cy = y;
                    switch (i)
                    {
                        case 0:
                            cx = x + 1;
                            break;
                        case 1:
                            cx = x - 1;
                            break;
                        case 2:
                            cy = y + 1;
                            break;
                        case 3:
                            cy = y - 1;
                            break;
                    }
                    if (IsCoordinatesValid(cx, cy, texture.width, texture.height, arrayOfValues, mediumColor, texture))
                    {
                        pixels.Add(new Tuple<int, int>(cx, cy));
                        arrayOfValues[cx, cy] = 1;
                    }
                }
            }

            pixels.Clear();
        }
    }
    private bool IsCoordinatesValid(int x, int y, int width, int height, int[,] arrayOfValues, float mediumColor, Texture2D texture)
    {
        if (x < 0 || y < 0)
            return false;
        if (x >= width || y >= height)
            return false;
        if(arrayOfValues[x, y] !=0)
            return false;
        if (mediumColor < GetAverageColor(texture.GetPixel(x,y)))
            return false;
        if (mediumColor - PIXEL_CAPTURE_RATE >= GetAverageColor(texture.GetPixel(x, y)))
            return false;

        return true;
    }
}
