using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    [SerializeField] private Button _buttonChange;
    [SerializeField] private Image _image;
    private Palette _palette;
    private Color _thisColor;

    public void GiveColor(Palette palette, Color color)
    {
       _palette = palette;
       _thisColor = color;
       _image.color = _thisColor;
    }

    public void OnColorChange()
    {
        _palette.ChangeColor(_thisColor);
    }

    private void OnEnable()
    {
        _buttonChange.onClick.AddListener(OnColorChange);
    }

    private void OnDisable()
    {
        _buttonChange.onClick.RemoveListener(OnColorChange);
    }


}
