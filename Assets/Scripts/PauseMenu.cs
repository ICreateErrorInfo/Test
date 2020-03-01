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
        //Wenn der button gedrückt wird das pausemenu aufgerufen 
        // oder das spiel weitergespielt
        if (Input.GetButtonDown(Steuerung.Cancel)) {

            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private bool _reshowEtext;

    //läst das Pausemenu erseinen
    void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused   = true;

        _reshowEtext = EText.gameObject.activeInHierarchy;
        EText.gameObject.SetActive(false);
    }

    //Läst das pausemenu verschwinden
    void Resume() { 

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused   = false;

        if (_reshowEtext) {
            EText.gameObject.SetActive(true);
        }

    }

    //Button actionen
    public void OnResumeButton() {
        Stats.Instance.Save();
        Resume();
    }

    public void OnOptionButton() {
        Stats.Instance.Save();
        SceneManager.LoadScene(SceneNames.OptionScene);
    }

    public void OnMainMenuButton() {
        Stats.Instance.Save();
        SceneManager.LoadScene(SceneNames.MainMenu);
        Resume();
    }
}
