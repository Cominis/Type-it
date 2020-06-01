using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //todo: attach to parent
    public void RestartGame()
    {
        CursorPositioning.Characters.Clear();
        SceneManager.LoadScene(Scenes.GAME);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
