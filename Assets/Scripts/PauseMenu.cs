using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private string mainMenu;
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] GameObject resumeButton;
    private bool isPaused = false;
    public InputListener[] AllInputs;
    [SerializeField] VibrateJoystick vibrateJoystickOne;
    [SerializeField] VibrateJoystick vibrateJoystickTwo;
    [SerializeField] VibrateJoystick vibrateJoystickThree;
    [SerializeField] VibrateJoystick vibrateJoystickFour;

    public void Start()
    {
        Time.timeScale = 1.0f;
        AllInputs = InputManager.Singleton.AllInputs;
    }

    public void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }

    /*private void Update()
    {
        if (Time.timeScale == 0)
		{
			for (int i = 0; i < AllInputs.Length; i++)
			{           
				AllInputs[i].Listen();

				if (AllInputs[i] != null && AllInputs[i].StartButtonPress())
				{
					//Debug.Log("Hi!" + AllInputs[i].GetType());
					TogglePause();
					break;
				}
			}
        }
    }*/

    void FixedUpdate()
    {
        for (int i = 0; i < AllInputs.Length; i++)
        {            
            if (AllInputs[i] != null && AllInputs[i].StartButtonPress())
            {
                //Debug.Log("Hi!" + AllInputs[i].GetType());
                //TogglePause();
                Pause();
                break;
            }
        }
    }
    
    public void Pause()
    {
        isPaused = true;
        pauseMenuCanvas.SetActive(true);
        if (vibrateJoystickOne.gameObject.activeInHierarchy)
            vibrateJoystickOne.SetVibrating(0f, 0f, false);

        if (vibrateJoystickTwo.gameObject.activeInHierarchy)
            vibrateJoystickTwo.SetVibrating(0f, 0f, false);

        if (vibrateJoystickThree.gameObject.activeInHierarchy)
            vibrateJoystickThree.SetVibrating(0f, 0f, false);

        if (vibrateJoystickFour.gameObject.activeInHierarchy)
            vibrateJoystickFour.SetVibrating(0f, 0f, false);

        Time.timeScale = 0.0f;
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }
    public void Resume1()
    {
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void TogglePause()
    {
        //Debug.Log("TogglePause");
        if (isPaused)
            Resume1();
        else
            Pause();
    }

    public void QuitToMainMenu()
    {
		GameManager.SetActive (false);
        SceneManager.LoadScene(mainMenu);
    }

}
