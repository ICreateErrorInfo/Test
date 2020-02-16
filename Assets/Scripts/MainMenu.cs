using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton() {
        SceneManager.LoadScene(SceneNames.Level1); 

    }

    public void OnOptionButton() {
        SceneManager.LoadScene(SceneNames.OptionScene);
    }

    public void OnQuitButton() {
        Application.Quit();
        Debug.Log("Quit");
    }

}
