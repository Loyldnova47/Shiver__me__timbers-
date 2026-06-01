using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMMenuController : MonoBehaviour
{
    public GameObject StartMenuPanel;
    public GameObject MainMenuHolder;
    public GameObject PlayMenuHolder;
    public GameObject SettingsHolder;
    public GameObject ControlsHolder;

    public void Awake()
    {
        SetState(MenuState.Start);
    }

    public void SetState(MenuState state)
    {
        StartMenuPanel.SetActive(state == MenuState.Start);
        MainMenuHolder.SetActive(state == MenuState.Main);
        PlayMenuHolder.SetActive(state == MenuState.Play);
        SettingsHolder.SetActive(state == MenuState.Settings);
        ControlsHolder.SetActive(state == MenuState.Controls);

    }

    public void OpenStart() => SetState(MenuState.Start);
    public void OpenMain() => SetState(MenuState.Main);
    public void OpenPlay() => SetState(MenuState.Play);
    public void OpenSettings() => SetState(MenuState.Settings);
    public void OpenControls() => SetState(MenuState.Controls);

    public void NewGame()
    {
        SaveManager.DeleteSave(); // optional reset
        SceneManager.LoadScene("Prologue");
    }
    
}


public enum MenuState
{
    Start,
    Main,
    Play,
    Settings,
    Controls,
    Prologue
}
