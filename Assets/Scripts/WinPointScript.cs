using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WinPointScript : MonoBehaviour
{
    //public UnityEvent OnPlayerEnter;
    [SerializeField] private string collisionTag = "Player";
    [SerializeField] int scoreAdd = 5;

     /*void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.tag == collisionTag)
         {
            PlayerManager.PlayerFinish(other.GetComponent<IamPlayer>(), scoreAdd);
            //OnPlayerEnter.Invoke();
         }
     }*/

}
