using DamageNumbersPro;
using UnityEngine;

public class Damages : MonoBehaviour
{
    public RectTransform rectParent;
    public static Damages Instance => _instace;
    public static Damages _instace;

    public DamageNumber prefab1;
    private Camera _camera;

    public void Awake()
    {
        _instace = this;
        _camera = Camera.main;
    }

    public void SpawnNumber(string value, Vector3 worldPosition)
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(worldPosition);

        if (screenPos.z > 0) // объект перед камерой
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, _camera, out var canvasPos);
            
            prefab1.SpawnGUI(rectParent, canvasPos, $"{value}");
        }
    }
}