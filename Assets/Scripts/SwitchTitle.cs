using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SwitchTitle : MonoBehaviour
{
    public VideoPlayer intro;
    public GameObject TitleScreen;
    public GameObject VideoPlayerObj;
    // Start is called before the first frame update
    void Start()
    {
        intro.loopPointReached += CheckOver;
    }

void CheckOver(UnityEngine.Video.VideoPlayer vp){
    TitleScreen.SetActive(true);
    VideoPlayerObj.SetActive(false);
}
}
