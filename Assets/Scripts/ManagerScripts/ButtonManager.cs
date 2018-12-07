using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour {

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject quitCanvas;
    [SerializeField] private GameObject selectLvlCanvas;
    [SerializeField] private GameObject principalMenuCanvas;
    [SerializeField] GameObject joinPlayers;
    public GameObject[] buttons;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }

    public void PressPlayButton(string level)
    {
        joinPlayers.SetActive(true);
        selectLvlCanvas.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(buttons[3]);
        principalMenuCanvas.SetActive(false);
    }

    public void PressSelectLevel()
    {
        if (GameManager.Singleton.GetCantPlayers() > 0)
            SceneManager.LoadScene(SceneManagement.instance.levels[SceneManagement.instance.currentLvl]);
    }

    public void PressExit()
    {
        quitCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[2]);
        principalMenuCanvas.SetActive(false);
    }

    public void PressSettings()
    {
        panel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[1]);
    }

    public void PressYes()
    {
        Application.Quit();
    }

    public void PressNo()
    {
        quitCanvas.SetActive(false);
        principalMenuCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }

    public void PressReturn()
    {
        selectLvlCanvas.SetActive(false);
        principalMenuCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }

    public void PressApply()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }
}
