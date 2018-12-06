using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WinPointScript : MonoBehaviour {
    public UnityEvent OnPlayerEnter;
    [SerializeField] private string collisionTag;

     void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.tag == collisionTag)
         {
            PlayerManager.SetWinner(other.gameObject.name);
            OnPlayerEnter.Invoke();
         }
     }

}
