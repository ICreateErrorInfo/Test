using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Pannel;

    public void Death() {

        Pannel.SetActive(true);
        Time.timeScale = 0;

    }   

    public void OnRestart() {
        Stats.Instance.Reset();
        Time.timeScale = 1;
        Pannel.SetActive(false);
    }

    public void OnMainMenu() {
        SceneManager.LoadScene(SceneNames.MainMenu);
        Time.timeScale = 1;
    }
  }
