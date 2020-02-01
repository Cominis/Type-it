using TMPro;
using UnityEngine;

public class TextMeshToMeshCollider : MonoBehaviour
{
    private MeshCollider meshCollider;
    private TextMeshPro textMeshPro;

    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        textMeshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        meshCollider.sharedMesh = textMeshPro.mesh;
    }
}
