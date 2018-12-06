using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaReporter : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IGameAreaObserver[] observers = collision.GetComponents<IGameAreaObserver>();
        for (int i = 0; i < observers.Length; i++)
            observers[i].OnEnterGameArea();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IGameAreaObserver[] observers = collision.GetComponents<IGameAreaObserver>();
        for(int i = 0; i < observers.Length; i++)
            observers[i].OnExitGameArea();
    }
}
public interface IGameAreaObserver
{
    void OnEnterGameArea();
    void OnExitGameArea();
}
