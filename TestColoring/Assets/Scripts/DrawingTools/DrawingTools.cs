using UnityEngine;
using UnityEngine.UI;
public abstract class DrawingTools : MonoBehaviour
{
    [SerializeField] protected float PIXEL_CAPTURE_RATE;
    [SerializeField] protected Slider СoloringSizeSlider;

    [SerializeField] protected int Size = 1;
    public int CurrentToolSize => Size;
    public abstract void Draw(Texture2D texture, Point point, Color futureСolor, Color currentColor, int brushSize = 1);
    public float GetAverageColor(Color color)
    {
        return (color.r + color.g + color.b) / 3;
    }

    public virtual void ChangeSize()
    {
        Size = (int)СoloringSizeSlider.value;
    }
}
