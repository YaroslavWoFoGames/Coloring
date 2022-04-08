using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Paint))]
public class PaintView : MonoBehaviour
{
    [SerializeField] private Button[] buttonsTool;
    [SerializeField] private Shader _shader;
    [SerializeField] private Texture2D _texture;
    private Texture2D _clearTexture;
    private Renderer _renderer;
    private Paint _paint;
    public Texture2D GetTexture()
    {
        return _texture;
    }

    public void ClearDrawn()
    {
        _texture = _clearTexture;
        _renderer.material.mainTexture = _texture;
        _clearTexture = Instantiate(_clearTexture);
    }

    public void ChangeTool(Button tool)
    {
        for (int i = 0; i < buttonsTool.Length; i++)
        {
            buttonsTool[i].interactable = true;
        }
        _paint.ChangeTool(tool.GetComponent<DrawingTools>());
        tool.interactable = false;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _clearTexture = Instantiate(GetTexture());
        _texture = Instantiate(GetTexture());
        _renderer.material.mainTexture = _texture;

        _paint = GetComponent<Paint>();
    }

}
