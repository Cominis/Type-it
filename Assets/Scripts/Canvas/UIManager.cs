using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool _isCanvasOn = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isCanvasOn = !_isCanvasOn;
            transform.GetChild(0).gameObject.SetActive(_isCanvasOn);
            if (_isCanvasOn)
            {
                //stop everyting
            }
            else
            {
                //resume everything
            }
        }
    }
}
