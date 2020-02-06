using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CursorPositioning : MonoBehaviour
{
    public float distanceBetweenCharacters = 0;
    public AudioClip[] cursorSounds;
    private float _currentXPosition = 0f;
    private int _currentCharacterIndex = 0;
    public static List<Transform> Characters = new List<Transform>();
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public bool MoveForward()
    {
        if (_currentCharacterIndex < Characters.Count)
        {
            _currentXPosition += (Characters[_currentCharacterIndex++].GetComponent<Character>().CharacterLength + distanceBetweenCharacters);
            ChangeCursorXPosition();
            return true;
        }
        return false;
    }

    public bool MoveBackward()
    {
        if (_currentCharacterIndex > 0)
        {
            _currentXPosition -= (Characters[--_currentCharacterIndex].GetComponent<Character>().CharacterLength + distanceBetweenCharacters);
            ChangeCursorXPosition();
            return true;
        }
        return false;
    }

    private void ResetCursor()
    {
        var firstCharacter = Characters[0];
        firstCharacter.tag = Tags.STRAINED_LETTER;
        InvokeCharacterPositioning(firstCharacter, 0);

        _currentXPosition = firstCharacter.GetComponent<Character>().CharacterLength / 2;
        ChangeCursorXPosition();

        _currentCharacterIndex = 1;
        Characters.Clear();
        Characters.Add(firstCharacter);
    }

    public string LooseCharacters()
    {
        string targetWord = Characters[0].GetComponent<TextMeshPro>().text;  // zone --> active
        for (int i = 1; i < Characters.Count; i++)
        {
            var character = Characters[i];
            character.SetParent(null);
            targetWord = string.Concat(targetWord, character.GetComponent<TextMeshPro>().text);

            var rb2d = character.gameObject.AddComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;
            rb2d.mass = 0.1f;

            character.GetComponent<RandomMovement>().Move();
        }

        if (Characters.Count > 0)
            ResetCursor();

        return targetWord;
    }
    //todo: update add and remove letter
    //todo: dont delete character but make it loose
    public void AddCharacter(char letter, Transform character)
    {
        character.tag = Tags.STRAINED_LETTER;
        character.SetParent(transform.parent);    //parent will be player
        Destroy(character.GetComponent<Rigidbody2D>());
        Characters.Insert(_currentCharacterIndex, character);

        var newCharacterLength = character.GetComponent<Character>().CharacterLength + distanceBetweenCharacters;

        //animate new character movement to desired location
        if (_currentCharacterIndex == 0)    // for first letter only
        {
            InvokeCharacterPositioning(character, _currentXPosition);
            newCharacterLength /= 2;
        }
        else
            InvokeCharacterPositioning(character, _currentXPosition + newCharacterLength / 2);

        //change cursor
        _currentCharacterIndex++;
        _currentXPosition += newCharacterLength;
        ChangeCursorXPosition();

        //update all subsequent characters
        for (int i = _currentCharacterIndex; i < Characters.Count; i++)
        {
            Characters[i].localPosition = new Vector2(Characters[i].localPosition.x + newCharacterLength, Characters[i].localPosition.y);
        }
    }

    public void AddCharacterInstantly(Transform letterTransform)
    {
        letterTransform.SetParent(transform.parent);    //parent will be player
        Destroy(letterTransform.GetComponent<Rigidbody2D>());
        Characters.Insert(_currentCharacterIndex, letterTransform);

        var newLetterLength = letterTransform.GetComponent<Character>().CharacterLength + distanceBetweenCharacters;

        if (_currentCharacterIndex == 0)    // for first letter only
        {
            letterTransform.localPosition = new Vector2(_currentXPosition, 0);
            newLetterLength /= 2;
        }
        else
            letterTransform.localPosition = new Vector2(_currentXPosition + newLetterLength / 2, 0);

        _currentCharacterIndex++;
        _currentXPosition += newLetterLength;
        ChangeCursorXPosition();

        for (int i = _currentCharacterIndex; i < Characters.Count; i++)
        {
            Characters[i].localPosition = new Vector2(Characters[i].localPosition.x + newLetterLength, Characters[i].localPosition.y);
        }
    }

    public void DeleteCharacter()
    {
        if (_currentCharacterIndex > 0)
        {
            var letterWidth = Characters[--_currentCharacterIndex].GetComponent<Character>().CharacterLength + distanceBetweenCharacters;
            _currentXPosition -= letterWidth;

            for (int i = _currentCharacterIndex; i < Characters.Count; i++)
            {
                Characters[i].localPosition = new Vector2(Characters[i].localPosition.x - letterWidth, Characters[i].localPosition.y);
            }

            DestroyCharacter();
            ChangeCursorXPosition();
        }
    }

    private void DestroyCharacter()
    {
        Characters[_currentCharacterIndex].tag = Tags.LOOSE_LETTER;
        Destroy(Characters[_currentCharacterIndex].gameObject);
        Characters.RemoveAt(_currentCharacterIndex);
    }

    private void InvokeCharacterPositioning(Transform character, float xAxisPosition)
    {
        var trigger = character.GetComponent<Trigger>();
        trigger.ToPosition = new Vector2(xAxisPosition, 0);
        trigger.IsToChangePosition = true;
    }

    private void ChangeCursorXPosition()
    {
        transform.localPosition = new Vector2(_currentXPosition, 0);
        PlaySound();
    }

    private void ChangeCursorXPosition(float xPosition)
    {
        transform.localPosition = new Vector2(xPosition, 0);
        PlaySound();
    }

    private void PlaySound()
    {
        audioSource.clip = cursorSounds[UnityEngine.Random.Range(0, cursorSounds.Length)];
        audioSource.Play();
    }
}
