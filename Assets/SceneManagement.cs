using UnityEngine;

public class SceneManagement : MonoBehaviour {

    public static SceneManagement instance;

    public string[] levels;
    public int currentLvl = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("SceneManagement duplicado", gameObject);
    }

    void Reset()
    {
        currentLvl = 0;
    }

    void OnNext()
    {
        if (currentLvl != 2)
            currentLvl ++;
        else
            currentLvl = 0;
    }

    void OnPrevious()
    {
        if (currentLvl >= 1)
            currentLvl --;
        else
            currentLvl = 2;
    }

}
