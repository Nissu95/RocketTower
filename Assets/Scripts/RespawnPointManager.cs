using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LevelType { Vertical, Horizontal }
public class RespawnPointManager : MonoBehaviour {
    protected static RespawnPointManager Singleton;
    public bool levelTypeHorizontal = false;
    protected List<RespawnPoint> points = new List<RespawnPoint>();
    // Use this for initialization
    void Awake () {
        Singleton = this;
    }
    private void FixedUpdate()
    {
        if (points.Count > 1)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                if (!Singleton.levelTypeHorizontal)
                {
                    if (Camera.main.transform.position.y > points[i].transform.position.y)
                    {
                        points[i].ReleaseAll();
                        points.RemoveAt(i);
                    }
                }
                else
                {
                    if (Camera.main.transform.position.x > points[i].transform.position.x)
                    {
                        points[i].ReleaseAll();
                        points.RemoveAt(i);
                    }
                }
            }
        }
    }
    static public void AddSpawnPoint(RespawnPoint point)
    {
        if (Singleton == null) Debug.LogError("No respawn point manager on scene!");
        int i = 0;
        if(!Singleton.levelTypeHorizontal)
        {
            while (i < Singleton.points.Count)
            {
                if (Singleton.points[i].transform.position.y < point.transform.position.y)
                    break;
                else i++;
            }
            Singleton.points.Insert(i, point);
        }
        else
        {
            while (i < Singleton.points.Count)
            {
                if (Singleton.points[i].transform.position.x < point.transform.position.x)
                    break;
                else i++;
            }
            Singleton.points.Insert(i, point);
        }
       
    }
    static public void RequestRespawn(GameObject player)
    {
        Singleton.points[Singleton.points.Count-1].Add(player);
    }
}
