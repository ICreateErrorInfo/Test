using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Button actionen
    public void OnLoadGameButton() {
        SceneManager.LoadScene(SceneNames.Level1);
        Time.timeScale = 1;
        Stats.Instance.Load();
    }

    public void OnNewGameButton() {
        SceneManager.LoadScene(Stats.Instance.Level);
        Time.timeScale = 1;
        Stats.Instance.Reset();
    }

    public void OnOptionButton() {
        SceneManager.LoadScene(SceneNames.OptionScene);
    }

    public void OnQuitButton() {
        Application.Quit();
        Debug.Log("Quit");
        Stats.Instance.Save();
    }

}
