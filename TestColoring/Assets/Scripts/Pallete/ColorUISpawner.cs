using UnityEngine;

public class ColorUISpawner : PalleteView
{
    [SerializeField] private ColorUI _colorUI;
    [SerializeField] private Transform _container;

    private void Start()
    {
        SpawnUIColor();
    }
    private void SpawnUIColor()
    {
        for (uint i = 0; i < Palette.CountColors; i++)
        {
            Instantiate(_colorUI, _container).GiveColor(Palette,Palette.GetPaletteColor(i));
        }
    }

}
