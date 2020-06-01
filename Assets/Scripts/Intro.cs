using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    private VideoPlayer _intro;
    void Awake()
    {
        Cursor.visible = false;
        _intro = Camera.main.GetComponent<VideoPlayer>();
        _intro.loopPointReached += EndReached;
        _intro.Prepare();
    }

    private void Start()
    {
        _intro.Play();
    }
    private void EndReached(VideoPlayer vp)
    {
        _intro.Stop();
        SceneManager.LoadScene(Scenes.GAME);
    }
}
