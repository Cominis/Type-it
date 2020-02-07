using System.Collections;
using TMPro;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public GameObject right;
    public GameObject wrong;
    public string word;
    private ThemesManager _themesManager;

    private void Start()
    {
        _themesManager = GetComponent<ThemesManager>();
    }
    public void EndGame()
    {
        StartCoroutine(Ending());
    }

    IEnumerator Ending()
    {
        foreach (GameObject looseLetter in GameObject.FindGameObjectsWithTag(Tags.LOOSE_LETTER))
            Destroy(looseLetter);

        GameObject.FindGameObjectWithTag(Tags.CURSOR).SetActive(false);
        var player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        player.transform.position = Vector3.zero;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        var collectedWord = CursorPositioning.Characters;
        var textColor = Utils.Themes[_themesManager.CurrentThemeIndex].TextColor;
        for (int i = 0; i < collectedWord.Count; i++)
        {
            var collectedLetter = collectedWord[i];
            GameObject obj;
            if (i < word.Length && word[i] == collectedLetter.GetComponent<TextMeshPro>().text[0])
            {
                obj = Instantiate(right, collectedLetter.transform.position + new Vector3(0, -3, 0), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                obj = Instantiate(wrong, collectedLetter.transform.position + new Vector3(0, -3, 0), new Quaternion(0, 0, 0, 0));
            }

            obj.GetComponent<SpriteRenderer>().color = textColor;
            yield return new WaitForSeconds(0.5f);
        }

        /*GameObject let = Instantiate(letter);
        let.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        let.transform.localPosition = new Vector3(0, -10, 0);
        let.GetComponent<TextMeshPro>().text = "Missing _characters: " + Mathf.Clamp(word.Length - collectedWord.Length, 0, 100);
        Destroy(Instantiate(right));*/
    }
}
