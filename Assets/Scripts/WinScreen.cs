using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public void OnNextLevelButton() {
        Time.timeScale = 1;
        Stats.Instance.Level += 1;
    }

    public void OnMainMenu() {
        SceneManager.LoadScene(SceneNames.MainMenu);
        Time.timeScale = 1;
        Stats.Instance.Save();
    }
}
