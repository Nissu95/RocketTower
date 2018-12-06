using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

    [SerializeField] private string mainMenu;

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManagement.instance.levels[SceneManagement.instance.currentLvl]);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
