using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] private string videoUrl = "https://lumacx.github.io/VideoHost/TimeTower_Waterfall.mp4";
    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer)
        {
            videoPlayer.url = videoUrl;
            videoPlayer.playOnAwake = false;
            videoPlayer.Prepare();

            videoPlayer.prepareCompleted += OnVideoPrepared;
        }

    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        videoPlayer.Play();
    }

}
