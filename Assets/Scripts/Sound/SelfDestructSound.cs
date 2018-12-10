using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructSound : MonoBehaviour
{
    public AudioClip c;
	// Use this for initialization
	void Start ()
    {        
        Play(c, transform.position);
    }

	public void Play(AudioClip c, Vector3 pos)
    {
        this.c = c;        
        transform.position = pos;
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        AudioSource s = GetComponent<AudioSource>();
        s.clip = c;
        s.Play();
        yield return new WaitForSeconds(c.length);
        GameObject.Destroy(gameObject);
    }
}
