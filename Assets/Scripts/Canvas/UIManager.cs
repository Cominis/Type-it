using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool _isCanvasOn = false;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isCanvasOn = !_isCanvasOn;
            transform.GetChild(0).gameObject.SetActive(_isCanvasOn);
            Cursor.visible = _isCanvasOn;

            if (_isCanvasOn)
            {
                //stop everyting
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                //resume everything
                Cursor.lockState = CursorLockMode.Locked;
                
            }
        }
    }
}
