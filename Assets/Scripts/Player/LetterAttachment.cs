using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAttachment : MonoBehaviour
{
    private KeyCode[] _acceptableKeys = new KeyCode[]
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
    };

    private static Dictionary<char, List<Transform>> _lettersInZone;
    private bool _isUpperCase = false;
    private LetterPositioning LetterPositioning { get; set; }
    private void Start()
    {
        _lettersInZone = new Dictionary<char, List<Transform>>();
        LetterPositioning = GetComponent<LetterPositioning>();
    }

    public static void AddItem(char letter, Transform letterTransform)
    {
        List<Transform> list;
        if(_lettersInZone.TryGetValue(letter, out list))
        {
            if (list == null)
            {
                list = new List<Transform>();
                list.Add(letterTransform);
                _lettersInZone[letter] = list;
            }  
            else
                list.Add(letterTransform);
        }
        else
        {
            list = new List<Transform>();
            list.Add(letterTransform);
            _lettersInZone.Add(letter, list);
        }
    }

    public static void RemoveItem(char letter, Transform letterTransform)
    {
        List<Transform> list;
        if (_lettersInZone.TryGetValue(letter, out list))
        {
            list.RemoveAt(0);
        }
    }

    void Update()
    {
        _isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        foreach (KeyCode vKey in _acceptableKeys)
        {
            if (Input.GetKeyDown(vKey))
            {
                char letter = _isUpperCase ? vKey.ToString()[0] : vKey.ToString().ToLower()[0];

                List<Transform> list;
                if (_lettersInZone.TryGetValue(letter, out list) && list.Count > 0)
                {
                    var letterTransform = _lettersInZone[letter][0];
                    LetterPositioning.AddLetter(letter, letterTransform);
                    RemoveItem(letter, letterTransform);
                }
            }
        }
    }
}
