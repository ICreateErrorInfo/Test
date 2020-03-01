using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject Barikade;
    GameObject ItemEntferner;
    GameObject JumpItem;

    private void Awake()
    {
        Barikade = GameObject.FindGameObjectWithTag(TagNames.Barikade);
        ItemEntferner = GameObject.FindGameObjectWithTag(TagNames.ItemEnt);
        JumpItem = GameObject.FindGameObjectWithTag(TagNames.ItemJump);
    }

    // Button actionen
    public void OnLoadGameButton() {
        SceneManager.LoadScene(SceneNames.Level1);
        Time.timeScale = 1;

        //Läd das gespeicherte
        Stats.Instance.Load();
        Barikade.SetActive(Stats.Instance.BarikadeIsShown);
        ItemEntferner.SetActive(Stats.Instance.EntfernerItemIsShown);
        JumpItem.SetActive(Stats.Instance.JumpItemIsShown);
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
