using UnityEngine;

public class Eraser : DrawingTools
{
    public override void Draw(Texture2D texture, Point point, Color futureСolor, Color currentColor, int brushSize)
    {
        Erase(texture, point);
    }
    private void Erase(Texture2D texture, Point point)
    {
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                Color erasableСolor = texture.GetPixel(point.X + x - Size / 2, point.Y + y - Size / 2);

                if (GetAverageColor(erasableСolor) > GetAverageColor(Color.black) + PIXEL_CAPTURE_RATE)
                texture.SetPixel(point.X + x - Size / 2, point.Y + y - Size / 2, Color.white);
            }
        }
    }
}
