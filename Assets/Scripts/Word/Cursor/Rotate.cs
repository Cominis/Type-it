using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void Update()
    {
        Spin();
    }
    void Spin()
    {
        transform.Rotate(0, 0, 20 * Time.deltaTime);
    }

}
