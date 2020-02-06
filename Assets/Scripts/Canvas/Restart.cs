using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        Params.IsPlayIntro = false;
        SceneManager.LoadScene(Scenes.GAME);
    }
}
