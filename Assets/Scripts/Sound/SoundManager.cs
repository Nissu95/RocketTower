using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject Prefab;
    public static SoundManager Singleton;
    public List<AudioSource> sources;

	void Awake ()
    {
        Singleton = this;
    }

	public static void PlaySound(GameObject source, AudioClip c)
    {
        GameObject newSound = GameObject.Instantiate<GameObject>(Singleton.Prefab);
        newSound.GetComponent<SelfDestructSound>().Play(c, source.transform.position);
    }

    public void PlaySoundInstance(GameObject source, AudioClip c)
    {
        GameObject newSound = GameObject.Instantiate<GameObject>(Singleton.Prefab);
        newSound.GetComponent<SelfDestructSound>().Play(c, source.transform.position);
    }

    public void PlaySoundInstance(AudioClip c)
    {
        GameObject newSound = GameObject.Instantiate<GameObject>(Singleton.Prefab);
        newSound.GetComponent<SelfDestructSound>().Play(c, transform.position);
    }

    public void PlaySoundForever(AudioClip c)
    {        
        for(int i = 0; i < sources.Count; i++)
        {
            if(sources[i].clip == c)
            {
                if(!sources[i].isPlaying)
                    sources[i].Play();
                return;
            }
        }

        AudioSource s = gameObject.AddComponent<AudioSource>();
        sources.Add(s);
        s.clip = c;
        s.loop = true;
        s.Play();
    }

    public void StopSound(AudioClip c)
    {
        for (int i = 0; i < sources.Count; i++)
        {
            if (sources[i].clip == c)
            {
                if (sources[i].isPlaying)
                    sources[i].Stop();
                return;
            }
        }
    }
}
