using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AddPlayers : MonoBehaviour {

    [SerializeField] GameObject selectLvlCanvas;
    [SerializeField] GameObject selectLevel;
    [SerializeField] float timer = 5;
    [SerializeField] GameObject[] playerImages;

    InputListener[] allInputs;
    InputListener input;
    bool[] inputsPressed;
    float countdown;

    private void OnEnable()
    {
        allInputs = InputManager.Singleton.AllInputs;
        countdown = timer;
        inputsPressed = new bool[playerImages.Length];

        GameManager.Singleton.SetCantPlayers(0);

        for (int i = 0; i < inputsPressed.Length; i++)
        {
            inputsPressed[i] = false;
            playerImages[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
        else
        {
            selectLvlCanvas.SetActive(true);
            EventSystem.current.SetSelectedGameObject(selectLevel);
            gameObject.SetActive(false);
        }

        for (int i = 0; i < allInputs.Length; i++)
        {
            input = allInputs[i];
            if (input.StartButtonPress() && !inputsPressed[i])
            {
                inputsPressed[i] = true;
                playerImages[i].SetActive(true);
                GameManager.Singleton.AddCantPlayers(1);
            }
        }
    }

}
