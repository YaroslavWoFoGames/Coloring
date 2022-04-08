using UnityEngine;

[RequireComponent(typeof(PaintView))] 
public class Paint : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Collider _collider;

    [SerializeField] private Palette _palette;

    [SerializeField] private DrawingTools[] _tools;

    private PaintView _paintView;
    private DrawingTools _currentTool;

    private int _oldRayX, _oldRayY;

    public void ChangeTool(DrawingTools tool)
    {
        _currentTool = tool;
    }
    private  void Start()
    {
        _currentTool = _tools[0];
        _paintView = GetComponent<PaintView>();
    }

    private void Update()
    {       
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (_collider.Raycast(ray, out hit, 100f))
            {
                int rayX = (int)(hit.textureCoord.x * _paintView.GetTexture().width);
                int rayY = (int)(hit.textureCoord.y * _paintView.GetTexture().height);

                if (_oldRayX != rayX || _oldRayY != rayY)
                {
                   
                    _currentTool.Draw(_paintView.GetTexture(), new Point(rayX, rayY), _palette.CurrentColor , _paintView.GetTexture().GetPixel(rayX, rayY), _currentTool.CurrentToolSize);
                    _oldRayX = rayX;
                    _oldRayY = rayY;
                }

                _paintView.GetTexture().Apply();
            }
        }
    }
}
