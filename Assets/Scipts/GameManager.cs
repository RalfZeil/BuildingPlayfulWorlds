using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener(EventType.ON_WIN, ChangeSceneToWin);
        EventManager.AddListener(EventType.ON_PLAYER_DEATH, ChangeSceneToDeath);
    }

    private void ChangeSceneToWin()
    {
        SceneManager.LoadScene("WinScene");
    }

    private void ChangeSceneToDeath()
    {
        StartCoroutine(WaitForSecondsDeath(1f));
    }

    IEnumerator WaitForSecondsDeath(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("DeathScene");
    }
}
