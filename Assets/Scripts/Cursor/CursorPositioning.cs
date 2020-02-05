using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CursorPositioning : MonoBehaviour
{
    public float distanceBetweenCharacters = 0;
    public AudioClip[] cursorSounds;
    private float _currentXPosition = 0f;
    private int _currentCharacterIndex = 0;
    private List<Transform> _characters = new List<Transform>();
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public bool MoveForward()
    {
        if (_currentCharacterIndex < _characters.Count)
        {
            _currentXPosition += (_characters[_currentCharacterIndex++].GetComponent<Character>().CharacterLength + distanceBetweenCharacters);
            ChangeCursorXPosition();
            return true;
        }
        return false;
    }

    public bool MoveBackward()
    {
        if (_currentCharacterIndex > 0)
        {
            _currentXPosition -= (_characters[--_currentCharacterIndex].GetComponent<Character>().CharacterLength + distanceBetweenCharacters);
            ChangeCursorXPosition();
            return true;
        }
        return false;
    }

    private void ResetCursor()
    {
        var firstCharacter = _characters[0];
        firstCharacter.tag = Tags.STRAINED_LETTER;
        InvokeCharacterPositioning(firstCharacter, 0);

        _currentXPosition = firstCharacter.GetComponent<Character>().CharacterLength / 2;
        ChangeCursorXPosition();

        _currentCharacterIndex = 1;
        _characters.Clear();
        _characters.Add(firstCharacter);
    }

    public string LooseCharacters()
    {
        string targetWord = _characters[0].GetComponent<TextMeshPro>().text;  // zone --> active
        for (int i = 1; i < _characters.Count; i++)
        {
            var character = _characters[i];
            character.SetParent(null);
            targetWord = string.Concat(targetWord, character.GetComponent<TextMeshPro>().text);

            var rb2d = character.gameObject.AddComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;
            rb2d.mass = 0.1f;

            character.GetComponent<RandomMovement>().Move();
        }

        if (_characters.Count > 0)
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
        _characters.Insert(_currentCharacterIndex, character);

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
        for (int i = _currentCharacterIndex; i < _characters.Count; i++)
        {
            _characters[i].localPosition = new Vector2(_characters[i].localPosition.x + newCharacterLength, _characters[i].localPosition.y);
        }
    }

    public void AddCharacterInstantly(Transform letterTransform)
    {
        letterTransform.SetParent(transform.parent);    //parent will be player
        Destroy(letterTransform.GetComponent<Rigidbody2D>());
        _characters.Insert(_currentCharacterIndex, letterTransform);

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

        for (int i = _currentCharacterIndex; i < _characters.Count; i++)
        {
            _characters[i].localPosition = new Vector2(_characters[i].localPosition.x + newLetterLength, _characters[i].localPosition.y);
        }
    }

    public void DeleteCharacter()
    {
        if (_currentCharacterIndex > 0)
        {
            var letterWidth = _characters[--_currentCharacterIndex].GetComponent<Character>().CharacterLength + distanceBetweenCharacters;
            _currentXPosition -= letterWidth;

            for (int i = _currentCharacterIndex; i < _characters.Count; i++)
            {
                _characters[i].localPosition = new Vector2(_characters[i].localPosition.x - letterWidth, _characters[i].localPosition.y);
            }

            DestroyCharacter();
            ChangeCursorXPosition();
        }
    }

    private void DestroyCharacter()
    {
        _characters[_currentCharacterIndex].tag = Tags.LOOSE_LETTER;
        Destroy(_characters[_currentCharacterIndex].gameObject);
        _characters.RemoveAt(_currentCharacterIndex);
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
