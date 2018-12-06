using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] private string winScene;
    [SerializeField] private int cantPlayers;
    public static GameManager Singleton;
    public bool Activated = true;
    void Awake()
    {
        Singleton = this;
        cantPlayers -= 1;
    }
    public void Win()
    {
        if(Activated)
            SceneManager.LoadScene(winScene);
    }
	public static void SetActive(bool state){
		if (Singleton != null) {
			Singleton.Activated = state;
		}
	}
    private void OnApplicationQuit()
    {
        Activated = false;
    }
}
