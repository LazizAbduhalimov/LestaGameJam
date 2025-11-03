using DamageNumbersPro;
using UnityEngine;

public class Damages : MonoBehaviour
{
    public RectTransform rectParent;
    public static Damages Instance => _instace;
    public static Damages _instace;

    public DamageNumber prefab1;
    public DamageNumber prefab2;
    public DamageNumber scorePrefab;

    private Camera _camera;

    public void Awake()
    {
        _instace = this;
        _camera = Camera.main;
    }

    public void SpawnNumber(string value, Vector3 worldPosition)
    {
        Spawn(prefab1, value, worldPosition);
    }

    public void SpawnNumber2(string value, Vector3 worldPosition)
    {
        Spawn(prefab2, value, worldPosition);
    }
    
    public void SpawnScore(string value, Vector3 worldPosition)
    {
        Spawn(scorePrefab, value, worldPosition);
    }

    private void Spawn(DamageNumber prefab, string value, Vector3 worldPosition)
    {
        if (prefab == null || _camera == null || rectParent == null) return;

        Vector3 screenPos = _camera.WorldToScreenPoint(worldPosition);

        if (screenPos.z <= 0) return; // объект за камерой

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, _camera, out var canvasPos);
        prefab.SpawnGUI(rectParent, canvasPos, value);
    }
}