using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttachment : MonoBehaviour
{
    //todo: make this script on zone
    private static Dictionary<char, List<Transform>> __charactersInZone;
    private bool _isUpperCase = false;
    private CursorPositioning _cursorPositioning;

    public static void ActivateLetter(char character, Transform characterTransform)
    {
        List<Transform> list;
        if(__charactersInZone.TryGetValue(character, out list))
        {
            list.Add(characterTransform);
        }
    }

    public static void DeactivateLetter(char character, Transform characterTransform)
    {
        List<Transform> list;
        if (__charactersInZone.TryGetValue(character, out list))
        {
            list.Remove(characterTransform);
        }
    }

    //todo: add space and other characters
    private void Awake()
    {
        __charactersInZone = new Dictionary<char, List<Transform>>();
        foreach (var keyCode in Utils.AcceptableKeys)
        {
            __charactersInZone.Add(keyCode.ToString()[0], new List<Transform>());
            __charactersInZone.Add(keyCode.ToString().ToLower()[0], new List<Transform>());
        }
        _cursorPositioning = transform.parent.GetComponent<CursorPositioning>();
    }

    void Update()
    {
        _isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        foreach (KeyCode vKey in Utils.AcceptableKeys)
        {
            if (Input.GetKeyDown(vKey))
            {
                char letter = _isUpperCase ? vKey.ToString()[0] : vKey.ToString().ToLower()[0];

                List<Transform> list;
                if (__charactersInZone.TryGetValue(letter, out list) && list.Count > 0)
                {
                    var letterTransform = list[0];
                    _cursorPositioning.AddCharacter(letter, letterTransform);
                    DeactivateLetter(letter, letterTransform);
                }
            }
        }
    }
}
