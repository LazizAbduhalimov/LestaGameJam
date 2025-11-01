using UnityEngine;

public class BrickBuilder : MonoBehaviour {
    public GameObject BrickPrefab;
    public GameObject PreviewBrick;

    [SerializeField]
    private float _spawnDistance = 1f;

    private void Start()
    {
        // nothing for now; PreviewBrick can be assigned in the Inspector
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Build();
        }

        PreviewBuild();
    }

    public void PreviewBuild()
    {
        if (PreviewBrick == null) return;

        Vector3 previewPos = transform.position + transform.forward * _spawnDistance;
        PreviewBrick.transform.position = previewPos;
        PreviewBrick.transform.rotation = transform.rotation;
    }

    public void Build()
    {
        if (BrickPrefab == null)
        {
            Debug.LogWarning("BrickPrefab is not assigned on BrickBuilder.");
            return;
        }

        Vector3 spawnPos = transform.position + transform.forward * _spawnDistance;
        Instantiate(BrickPrefab, spawnPos, transform.rotation);
    }
}