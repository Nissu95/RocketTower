using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public bool win;
    public int deaths;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Enemy Manager duplicado", gameObject);
        }

        deaths = 0;
    }
}
