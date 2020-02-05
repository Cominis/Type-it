using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    private CursorPositioning _cursorPositioning;
    private void Awake()
    {
        _cursorPositioning = GetComponent<CursorPositioning>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && _cursorPositioning.MoveBackward())
            {
                //play typed sound
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && _cursorPositioning.MoveForward())
            {
                //play back sound
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _cursorPositioning.DeleteCharacter();    //todo: cursor sounds
            //play delete sound
        }
        
    }
}
