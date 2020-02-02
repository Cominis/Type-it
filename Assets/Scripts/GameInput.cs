using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private static Dictionary<char, List<GameObject>> items;
    private bool isUpperCase;
    public KeyCode[] ascceptableLetters;
    private LetterPositioning LetterPositioning { get; set; }
    private void Start()
    {
        items = new Dictionary<char, List<GameObject>>();
        LetterPositioning = GameObject.FindGameObjectWithTag("Player").GetComponent<LetterPositioning>();
    }

    public static void AddItem(char key, GameObject letter)
    {
        List<GameObject> list;
        Debug.Log("raktas: " + key);
        if (items.ContainsKey(key))
        {
            list = items[key];
            Debug.Log("");
            if (list != null)
            {
                list.Add(letter);
            }
            else
            {
                list = new List<GameObject>();
                list.Add(letter);
                items[key] = list;
            }
        }
        else
        {
            list = new List<GameObject>();
            list.Add(letter);
            items.Add(key, list);
        }
    }

    public static void RemoveItem(char key, GameObject letter)
    {
        if (items.ContainsKey(key))
        {
            items[key].Clear();

        }
    }

    void Update()
    {
        isUpperCase = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        foreach (KeyCode vKey in ascceptableLetters)
        {
            if (Input.GetKeyDown(vKey))
            {
                if (!isUpperCase)
                {
                    string keyString = vKey.ToString().ToLower();
                    char letterKey = keyString[0];

                    if (items.ContainsKey(letterKey))
                        foreach (var gameObject in items[letterKey])
                        {
                            LetterPositioning.SetLetterPosition(letterKey, gameObject);
                        }
                }
                else
                {
                    string keyString = vKey.ToString();
                    char letterKey = keyString[0];

                    if (items.ContainsKey(letterKey))
                        foreach (var gameObject in items[letterKey])
                        {
                            LetterPositioning.SetLetterPosition(letterKey, gameObject);
                        }
                }
            }
        }
    }
}
