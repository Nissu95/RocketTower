using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {
    
    public List<InputListener> ContainedPlayersInput;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        RespawnPointManager.AddSpawnPoint(this);
    }
    public void Add(GameObject playerObject)
    {
        anim.SetBool("Empty", false);
        InputListener input = playerObject.GetComponent<InputListener>();
        if (input != null)
        {
            ContainedPlayersInput.Add(input);
        }
        else
        {
            Debug.LogError("Trying to respawn something with no input?");
        }
        playerObject.SetActive(false);
    }
    public void Release(int index)
    {
        ContainedPlayersInput[index].gameObject.transform.position = transform.position;
        ContainedPlayersInput[index].gameObject.SetActive(true);
        ContainedPlayersInput.RemoveAt(index);
        if (ContainedPlayersInput.Count < 1)
        {
            anim.SetBool("Empty", true);
        }
    }
    public void ReleaseAll()
    {
        while (ContainedPlayersInput.Count > 0)
        {
            Release(0);
        }
    }
    private void FixedUpdate()
    {
        for(int i = 0; i < ContainedPlayersInput.Count; i++)
        {
            if (ContainedPlayersInput[i].JumpButtonPress())
            {
                Release(i);
            }
        }
    }
}
