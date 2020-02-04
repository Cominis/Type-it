using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject right;
    public GameObject wrong;
    public string word;
    private GameObject[] collectedWord;

    private bool _restart = false;

    private void Update()
    {
        if (_restart)
        {
            SceneManager.LoadScene("Game");
        }
    }
    public void EndGame()
    {
        StartCoroutine(Ending());
    }
    IEnumerator Ending()
    {
        foreach (GameObject looseLetter in GameObject.FindGameObjectsWithTag("FreeLetter"))
            Destroy(looseLetter);

        GameObject.FindGameObjectWithTag("Cursor").SetActive(false);
        var player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Rigidbody2D>().isKinematic = true;

        collectedWord = GameObject.FindGameObjectsWithTag("LockedLetter");

        for (int i = 0; i < collectedWord.Length; i++)
        {
            var collectedLetter = collectedWord[i];
            if (i < word.Length && word[i] == collectedLetter.GetComponent<TextMeshPro>().text[0])
            {
                Instantiate(right, collectedLetter.transform.position + new Vector3(0, -3, 0), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Instantiate(wrong, collectedLetter.transform.position + new Vector3(0, -3, 0), new Quaternion(0, 0, 0, 0));
            }
            yield return new WaitForSeconds(0.5f);
        }

        _restart = true;
        /*GameObject let = Instantiate(letter);
        let.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        let.transform.localPosition = new Vector3(0, -10, 0);
        let.GetComponent<TextMeshPro>().text = "Missing letters: " + Mathf.Clamp(word.Length - collectedWord.Length, 0, 100);
        Destroy(Instantiate(right));*/
    }
}
