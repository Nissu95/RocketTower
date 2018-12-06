using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour {
    int currentvideo;
    VideoPlayer videoplayer;
    [SerializeField] private VideoClip[] stages;

    void Awake(){
        videoplayer = GetComponent<VideoPlayer>();
        videoplayer.enabled = false;
    }

    void Play(){
        currentvideo = 0;
        videoplayer.enabled = true;
        videoplayer.clip = stages[currentvideo];
        videoplayer.Play();
    }
    void Stop(){
        videoplayer.Stop();
        videoplayer.enabled = false;
    }
    void Next(){
        currentvideo++;
        if (currentvideo > stages.Length - 1){
            currentvideo = 0;
        }
        videoplayer.clip = stages[currentvideo];
        videoplayer.Play();
    }
    void Previous(){
        currentvideo--;
        if (currentvideo < 0){
            currentvideo = stages.Length - 1;
        }
        videoplayer.clip = stages[currentvideo];
        videoplayer.Play();
    }
}
