using UnityEngine;

public class Brush : DrawingTools
{
    public override void Draw(Texture2D texture, Point point, Color futureСolor, Color currentColor, int brushSize)
    {
        Draw(texture, point, futureСolor, brushSize);
    }
    private void Draw(Texture2D texture, Point point, Color futureColor, int brushSize)
    {
        for (int y = 0; y < brushSize; y++)
        {
            for (int x = 0; x < brushSize; x++)
            {

                float x2 = Mathf.Pow(x - brushSize / 2, 2);
                float y2 = Mathf.Pow(y - brushSize / 2, 2);
                float r2 = Mathf.Pow(brushSize / 2 - 0.5f, 2);

                if (x2 + y2 < r2)
                {
                    int pixelX = point.X + x - brushSize / 2;
                    int pixelY = point.Y + y - brushSize / 2;

                    if (pixelX >= 0 && pixelX < texture.width && pixelY >= 0 && pixelY < texture.height)
                    {
                        Color oldColor = texture.GetPixel(pixelX, pixelY);
                        Color resultColor = Color.Lerp(oldColor, futureColor, futureColor.a);
                        if (GetAverageColor(oldColor) > GetAverageColor(Color.black) + PIXEL_CAPTURE_RATE)
                        texture.SetPixel(pixelX, pixelY, resultColor);
                    }

                }
            }
        }
    }
}


