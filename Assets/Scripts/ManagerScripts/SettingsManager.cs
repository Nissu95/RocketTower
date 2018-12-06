using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class SettingsManager : MonoBehaviour {

    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Button applyButton;
    [SerializeField] private GameObject panel;

    public GameSettings gameSettings;
    [SerializeField] private Resolution[] resolutions;

    void OnEnable()
    {
        gameSettings = new GameSettings();
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        resolutions = Screen.resolutions;
        applyButton.onClick.AddListener(delegate { OnApply(); });

        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        if (File.Exists(Application.persistentDataPath + "/gamesettings.json"))
        {
           LoadSettings();
        }

    }

    public void OnFullScreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width,
            resolutions[resolutionDropdown.value].height,
            Screen.fullScreen);
    }

    public void OnApply()
    {
        SaveSettings();
        panel.SetActive(false);
    }

    public void SaveSettings()
    {
        string jSonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jSonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        resolutionDropdown.value = gameSettings.resolution;
        fullscreenToggle.isOn = gameSettings.fullscreen;
    }

}
