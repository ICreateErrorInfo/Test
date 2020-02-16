using JetBrains.Annotations;

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool       GameIsPaused;
    public        GameObject PauseMenuUI;

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
    void Resume() { 

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused   = false;

    }

    void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused   = true;
    }
}
