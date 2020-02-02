using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;

    public bool isCountingDown;

    public float startingTime;

    public GameObject letter;

    private TextMeshPro text;

    public GameObject right;
    public GameObject wrong;
    public string word;
    private GameObject[] collectedWord;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        currentTime = startingTime;
    }

    public void Stop()
    {
        isCountingDown = false;
    }

    public void ResetClock()
    {
        Stop();
        currentTime = startingTime;
    }

    public void StartClock()
    {
        isCountingDown = true;
    }

    void Update()
    {
        currentTime = Mathf.Clamp(currentTime, 0, startingTime);
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;
            text.text = Mathf.Round(currentTime).ToString();
            if (currentTime <= 0f)
            {
                collectedWord = GameObject.FindGameObjectsWithTag("LockedLetter");
                StartCoroutine(EndGame());
                isCountingDown = false;
            }
        }
    }

    IEnumerator EndGame()
    {

        foreach(GameObject looseLetter in GameObject.FindGameObjectsWithTag("FreeLetter"))
        {
            Debug.Log("Free letter: " + looseLetter.GetComponent<TextMeshPro>().text);
            looseLetter.GetComponent<Rigidbody>().velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - looseLetter.transform.position)* -500;
        }

        Destroy(GameObject.FindGameObjectWithTag("Cursor"));
        //Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>());
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
        //Time.timeScale = 0;
        int index = 0;
        Debug.Log("collected word: " + collectedWord[0] + collectedWord[1]);
        foreach(GameObject collectedLetter in collectedWord)
        {
            Debug.Log("Checking letter: " + collectedLetter.GetComponent<TextMeshPro>().text[0]);
            if (collectedLetter.GetComponent<TextMeshPro>().text[0] == word[index])
            {
                Instantiate(right, collectedLetter.transform.position + new Vector3(0, -3, 0), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Instantiate(wrong, collectedLetter.transform.position + new Vector3(0, -3, 0), new Quaternion(0, 0, 0, 0));
            }
            index++;
            yield return new WaitForSeconds(0.5f);
        }

        /*GameObject let = Instantiate(letter);
        let.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        let.transform.localPosition = new Vector3(0, -10, 0);
        let.GetComponent<TextMeshPro>().text = "Missing letters: " + Mathf.Clamp(word.Length - collectedWord.Length, 0, 100);
        Destroy(Instantiate(right));*/
    }
}
