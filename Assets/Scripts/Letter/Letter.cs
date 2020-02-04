using UnityEngine;

public class Letter : MonoBehaviour
{
    public float LetterLength { get; set; }

    [SerializeField]
    private PhysicsMaterial2D _material;
    public PhysicsMaterial2D Material { get => _material; set => _material = value; }

}
