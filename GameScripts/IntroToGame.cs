using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroToGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        // Subscribe to the video player's completion event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer player)
    {
        // Load the next scene
        SceneManager.LoadScene("Normandy");
    }
}
