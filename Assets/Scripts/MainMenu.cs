using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Button actionen
    public void OnPlayButton() {
        SceneManager.LoadScene(SceneNames.Level1);
        Stats.Instance.Reset();
    }

    public void OnOptionButton() {
        SceneManager.LoadScene(SceneNames.OptionScene);
    }

    public void OnQuitButton() {
        Application.Quit();
        Debug.Log("Quit");
    }

}
