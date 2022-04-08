using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Palette))]
public class PalleteView : MonoBehaviour
{
    protected Palette Palette;
    private Image _currentImageColor;

    public void OnChangedColor(Color newColor)
    {
        _currentImageColor.color = newColor;
    }
    private void OnEnable()
    {
        Palette = GetComponent<Palette>();
        _currentImageColor = GetComponent<Image>();
        Palette.WillСhangeСolor += OnChangedColor;
    }
    private void OnDisable()
    {
        Palette.WillСhangeСolor -= OnChangedColor;
    }

}
