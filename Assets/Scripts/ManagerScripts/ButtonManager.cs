using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour {

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject quitCanvas;
    [SerializeField] private GameObject selectLvlCanvas;
    [SerializeField] private GameObject principalMenuCanvas;
    public GameObject[] buttons;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }

    public void PressPlayButton(string level)
    {
        EventSystem.current.SetSelectedGameObject(buttons[3]);
        selectLvlCanvas.SetActive(true);
        principalMenuCanvas.SetActive(false);
    }

    public void PressSelectLevel()
    {
        SceneManager.LoadScene(SceneManagement.instance.levels[SceneManagement.instance.currentLvl]);
    }

    public void PressExit()
    {
        EventSystem.current.SetSelectedGameObject(buttons[2]);
        quitCanvas.SetActive(true);
        principalMenuCanvas.SetActive(false);
    }

    public void PressSettings()
    {
        EventSystem.current.SetSelectedGameObject(buttons[1]);
        panel.SetActive(true);
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
        EventSystem.current.SetSelectedGameObject(buttons[0]);
        selectLvlCanvas.SetActive(false);
        principalMenuCanvas.SetActive(true);
    }

    public void PressApply()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }
}
