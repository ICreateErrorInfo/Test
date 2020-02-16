using JetBrains.Annotations;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool       GameIsPaused;
    public        GameObject PauseMenuUI;
    public TextMeshProUGUI EText;

    [UsedImplicitly]
    void Update()
    {
        if (Input.GetButtonDown(Steuerung.Cancel)) {

            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private bool _reshowEtext;

    void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused   = true;

        _reshowEtext = EText.gameObject.activeInHierarchy;
        EText.gameObject.SetActive(false);
    }

    void Resume() { 

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused   = false;

        if (_reshowEtext) {
            EText.gameObject.SetActive(true);
        }

    }

    public void OnResumeButton() {
        Resume();
    }

    public void OnOptionButton() {
        SceneManager.LoadScene(SceneNames.OptionScene);
    }

    public void OnMainMenuButton() {
        SceneManager.LoadScene(SceneNames.MainMenu);
        Resume();
    }
}
