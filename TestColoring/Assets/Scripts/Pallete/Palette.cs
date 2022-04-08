using UnityEngine;
using UnityEngine.Events;

public class Palette : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    private Color _currentColor;

    [SerializeField] private ColorUISpawner _colorView;

    public event UnityAction<Color> WillСhangeСolor;
    public Color CurrentColor => _currentColor;
    public int CountColors => _colors.Length;


    public Color GetPaletteColor(uint index)
    {
        if(index< _colors.Length)
        return _colors[index];
        else
        return _colors[0];
    }
    public void ChangeColor(Color newColor)
    {
        _currentColor = newColor;
        WillСhangeСolor?.Invoke(newColor);
    }

    private void Start()
    {
        ChangeColor(_colors[0]);
    }

}
