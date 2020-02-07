using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CursorPositioning : MonoBehaviour
{
    public float distanceBetweenCharacters = 0;
    public AudioClip[] cursorSounds;
    //private float _currentXPosition = 0f;
    private int _currentCharacterIndex = 0;
    public static List<Transform> Characters = new List<Transform>();
    private AudioSource audioSource;
    private float _wordLength = 0;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public bool MoveForward()
    {
        if (_currentCharacterIndex < Characters.Count)
        {
            ChangeCursorPosition(Characters[_currentCharacterIndex++].GetComponent<Character>().CharacterLength + distanceBetweenCharacters);
            return true;
        }
        return false;
    }

    public bool MoveBackward()
    {
        if (_currentCharacterIndex > 0)
        {
            ChangeCursorPosition(-Characters[--_currentCharacterIndex].GetComponent<Character>().CharacterLength - distanceBetweenCharacters);
            return true;
        }
        return false;
    }

    private void ResetCursor()
    {
        var firstCharacter = Characters[0];
        firstCharacter.tag = Tags.STRAINED_LETTER;

        var length = firstCharacter.GetComponent<Character>().CharacterLength;
        _wordLength = length + distanceBetweenCharacters;

        ResetCursorPosition(_wordLength); //appears after first character
        InvokePositioning(transform.parent, -_wordLength / 2);

        _currentCharacterIndex = 1;
        Characters.Clear();
        Characters.Add(firstCharacter);
    }

    public string LooseCharacters()
    {
        string targetWord = "";
        if(Characters.Count > 0)
        {
            targetWord = Characters[0].GetComponent<TextMeshPro>().text;
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
            ResetCursor();
        }

        return targetWord;
    }

    public void AddCharacter(char character, Transform charTransform)
    {
        charTransform.tag = Tags.STRAINED_LETTER;
        charTransform.SetParent(transform.parent);    //parent will be characters holder
        Destroy(charTransform.GetComponent<Rigidbody2D>());
        Characters.Insert(_currentCharacterIndex++, charTransform);

        var charLength = charTransform.GetComponent<Character>().CharacterLength + distanceBetweenCharacters;
        _wordLength += charLength;

        InvokePositioning(charTransform, transform.localPosition.x + charLength / 2);   // takes cursor local pos x

        ChangeCursorPosition(charLength);
        InvokePositioning(transform.parent, -_wordLength / 2); // character holder

        //update all subsequent characters
        for (int i = _currentCharacterIndex; i < Characters.Count; i++)
        {
            Characters[i].localPosition += new Vector3(charLength, 0, 0);
        }
    }

    public void AddCharacterInstantly(Transform charTransform)
    {
        charTransform.SetParent(transform.parent);    //parent will be character holder
        Destroy(charTransform.GetComponent<Rigidbody2D>());
        Characters.Insert(_currentCharacterIndex++, charTransform);

        var charLength = charTransform.GetComponent<Character>().CharacterLength + distanceBetweenCharacters;
        _wordLength += charLength;

        charTransform.localPosition = new Vector2(transform.localPosition.x + charLength / 2, 0); // takes cursor local pos x

        ChangeCursorPosition(charLength);
        InvokePositioning(transform.parent, -_wordLength / 2); // character holder

        //update all subsequent characters
        for (int i = _currentCharacterIndex; i < Characters.Count; i++)
        {
            Characters[i].localPosition += new Vector3(charLength, 0, 0);
        }
    }

    public void DeleteCharacter()
    {
        if (_currentCharacterIndex > 0)
        {
            var charLength = Characters[--_currentCharacterIndex].GetComponent<Character>().CharacterLength + distanceBetweenCharacters;
            _wordLength -= charLength;

            ChangeCursorPosition(-charLength);
            InvokePositioning(transform.parent, -_wordLength / 2);  // character holder

            //update all subsequent characters
            for (int i = _currentCharacterIndex; i < Characters.Count; i++)
            {
                Characters[i].localPosition -= new Vector3(charLength, 0, 0);
            }

            DestroyCharacter();
        }
    }

    //todo: make it loose only in play mode
    private void DestroyCharacter()
    {
        Characters[_currentCharacterIndex].tag = Tags.LOOSE_LETTER;
        Destroy(Characters[_currentCharacterIndex].gameObject);
        Characters.RemoveAt(_currentCharacterIndex);
    }

    private void InvokePositioning(Transform transform, float xAxisPosition)
    {
        var script = transform.GetComponent<MovementTransition>();
        script.ToPosition = new Vector2(xAxisPosition, 0);
        script.enabled = true;
    }
    private void ChangeCursorPosition(float x = 0, float y = 0, float z = 0)
    {
        transform.localPosition += new Vector3(x, y, z);
        PlaySound();
    }

    private void ResetCursorPosition(float x = 0, float y = 0, float z = 0)
    {
        transform.localPosition = new Vector3(x, y, z);
        PlaySound();
    }

    private void PlaySound()
    {
        audioSource.clip = cursorSounds[UnityEngine.Random.Range(0, cursorSounds.Length)];
        audioSource.Play();
    }
}
