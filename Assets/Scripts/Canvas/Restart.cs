using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //todo: attach to parent
    public void RestartGame()
    {
        Params.IsPlayIntro = false;
        SceneManager.LoadScene(Scenes.GAME);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
