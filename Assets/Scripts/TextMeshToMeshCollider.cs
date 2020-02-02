using TMPro;
using UnityEngine;

public class TextMeshToMeshCollider : MonoBehaviour
{
    private MeshCollider MeshCollider;
    private TextMeshPro TextMeshPro;

    void Start()
    {
        MeshCollider = GetComponent<MeshCollider>();
        TextMeshPro = GetComponent<TextMeshPro>();
        //MeshCollider.sharedMesh = TextMeshPro.mesh;
    }

    void Update()
    {
        MeshCollider.sharedMesh = TextMeshPro.mesh;
    }
}
