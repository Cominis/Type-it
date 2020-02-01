using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private static Dictionary<char, List<GameObject>> items;
    private bool isUpperCase;
    public KeyCode[] ascceptableLetters;
    private void Start()
    {
        items = new Dictionary<char, List<GameObject>>();
    }

    public static void AddItem(char key, GameObject letter)
    {
        List<GameObject> list;
        if (items.ContainsKey(key))
        {
            list = items[key];
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
            items[key].Remove(letter);
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
                    char key = keyString[0];
                    Debug.Log("key: " + key);
                    if (items.ContainsKey(key))
                        foreach (var gameObject in items[key])
                        {
                            gameObject.GetComponent<Trigger>().isTrue = true;
                        }
                }
                else
                {
                    string keyString = vKey.ToString();
                    char key = keyString[0];
                    Debug.Log("key: " + key);
                    if (items.ContainsKey(key))
                        foreach (var gameObject in items[key])
                        {
                            gameObject.GetComponent<Trigger>().isTrue = true;
                        }
                }
            }
        }
    }
}
