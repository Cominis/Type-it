using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPositioning : MonoBehaviour
{
    [SerializeField]
    private float _distanceBetweenLetters;
    private float DistanceBetweenLetters { get => _distanceBetweenLetters; set => _distanceBetweenLetters = value; }
    public List<Transform> Letters { get; set; } = new List<Transform>();
    private float CurrentXPosition { get; set; } = 0f;
    private int CurrentLetterIndex { get; set; } = 0;

    private Transform _cursor;
    void Start()
    {
        _cursor = transform.GetChild(0).transform;
    }

    public void MoveForward()
    {
        if (CurrentLetterIndex < Letters.Count)
        {
            CurrentXPosition += (Letters[CurrentLetterIndex++].GetComponent<Letter>().LetterLength + DistanceBetweenLetters);
            ChangeCursorPosition();
        }
    }

    public void MoveBackward()
    {
        if (CurrentLetterIndex > 0)
        {
            CurrentXPosition -= (Letters[--CurrentLetterIndex].GetComponent<Letter>().LetterLength + DistanceBetweenLetters);
            //update Cursor;
            ChangeCursorPosition();
        }
    }

    public void AddLetter(char letter, Transform letterTransform)
    {
        letterTransform.tag = Constants.LOCKED_LETTER;
        letterTransform.SetParent(transform);
        Destroy(letterTransform.GetComponent<Rigidbody2D>());
        Letters.Insert(CurrentLetterIndex++, letterTransform);

        var newLetterLength = letterTransform.GetComponent<Letter>().LetterLength + DistanceBetweenLetters;

        if (CurrentLetterIndex == 0)    // for first letter only
        {
            InvokeLetterPositioning(letterTransform, 0);
            newLetterLength /= 2;
        } else
            InvokeLetterPositioning(letterTransform, newLetterLength);

        CurrentXPosition += newLetterLength;
        ChangeCursorPosition();

        for (int i = CurrentLetterIndex; i < Letters.Count; i++)
        {
            Letters[i].localPosition = new Vector2(Letters[i].localPosition.x + newLetterLength, Letters[i].localPosition.y);
        }
    }

    public void AddLetterInstantly(Transform letterTransform)
    {
        letterTransform.tag = Constants.LOCKED_LETTER;
        letterTransform.SetParent(transform);
        Destroy(letterTransform.GetComponent<Rigidbody2D>());
        Letters.Insert(CurrentLetterIndex++, letterTransform);
        
        var newLetterLength = letterTransform.GetComponent<Letter>().LetterLength + DistanceBetweenLetters;
        //var newLetterLength = letterTransform.GetComponent<BoxCollider2D>().size.x + DistanceBetweenLetters;
        Debug.Log("Letter length: " + newLetterLength);
        if (CurrentLetterIndex == 0)    // for first letter only
        {
            letterTransform.localPosition = new Vector2(CurrentXPosition, 0);
            newLetterLength /= 2;
        }
        else
            letterTransform.localPosition = new Vector2(CurrentXPosition + newLetterLength / 2, 0);

        CurrentXPosition += newLetterLength;
        ChangeCursorPosition();

        for (int i = CurrentLetterIndex; i < Letters.Count; i++)
        {
            Letters[i].localPosition = new Vector2(Letters[i].localPosition.x + newLetterLength, Letters[i].localPosition.y);
        }
    }

    public void RemoveLetter()
    {
        if(CurrentLetterIndex > 0)
        {
            var letterWidth = Letters[--CurrentLetterIndex].GetComponent<Letter>().LetterLength + DistanceBetweenLetters;
            CurrentXPosition -= letterWidth;

            for (int i = CurrentLetterIndex; i < Letters.Count; i++)
            {
                Letters[i].localPosition = new Vector2(Letters[i].localPosition.x - letterWidth, Letters[i].localPosition.y);
            }

            DestroyLetter();
            ChangeCursorPosition();
        }
    }

    private void DestroyLetter()
    {
        Letters[CurrentLetterIndex].tag = Constants.FREE_LETTER;
        Destroy(Letters[CurrentLetterIndex].gameObject);
        Letters.RemoveAt(CurrentLetterIndex);
    }

    private void InvokeLetterPositioning(Transform letterTransform, float letterWidth)
    {
        var trigger = letterTransform.GetComponent<Trigger>();
        trigger.ToPosition = new Vector2(CurrentXPosition + letterWidth / 2, 0);
        trigger.IsToChangePosition = true;
    }

    private void ChangeCursorPosition()
    {
        _cursor.transform.localPosition = new Vector2(CurrentXPosition, 0);
    }

    private void ChangeCursorPosition(float position)
    {
        _cursor.transform.localPosition = new Vector2(position, 0);
    }
}
