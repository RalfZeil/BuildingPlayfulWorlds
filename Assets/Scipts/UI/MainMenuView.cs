using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView : View
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    public override void Initialize()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        settingsButton.onClick.AddListener(() => ViewManager.Show<SettingsMenuView>());
        quitButton.onClick.AddListener(() => Application.Quit());
    }
}
