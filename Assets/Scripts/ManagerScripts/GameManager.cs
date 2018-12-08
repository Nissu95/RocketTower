using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string winScene;

    public static GameManager Singleton;
    public bool Activated = true;

    int cantPlayers = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Singleton != null)
            Destroy(gameObject);
        else
            Singleton = this;
    }
    public void Win()
    {
        if (Activated)
        {
            SceneManager.LoadScene(winScene);
            Debug.Log("Win");
        }
    }
    public static void SetActive(bool state)
    {
        if (Singleton != null)
        {
            Singleton.Activated = state;
        }
    }
    private void OnApplicationQuit()
    {
        Activated = false;
    }

    public int GetCantPlayers()
    {
        return cantPlayers;
    }

    public void SetCantPlayers(int _cantPlayers)
    {
        cantPlayers = _cantPlayers;
    }

    public void AddCantPlayers(int _cantPlayers)
    {
        cantPlayers += _cantPlayers;
    }

}
