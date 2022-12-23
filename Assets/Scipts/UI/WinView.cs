using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinView : View
{
    [SerializeField] 
    private Button returnToMenuButton;
    [SerializeField] 
    private Button quitButton;

    public override void Initialize()
    {
        returnToMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        quitButton.onClick.AddListener(() => Application.Quit());
    }
}
