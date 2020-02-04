using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    LetterPositioning letterPositioning;
    private void Start()
    {
        letterPositioning = transform.parent.GetComponent<LetterPositioning>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                letterPositioning.MoveBackward();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                letterPositioning.MoveForward();
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            letterPositioning.RemoveLetter();
        }
        
    }
}
