using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Pannel;
    GameObject Barikade;
    GameObject ItemEntferner;
    GameObject JumpItem;

    private void Awake()
    {
        Barikade = GameObject.FindGameObjectWithTag(TagNames.Barikade);
        ItemEntferner = GameObject.FindGameObjectWithTag(TagNames.ItemEnt);
        JumpItem = GameObject.FindGameObjectWithTag(TagNames.ItemJump);
    }

    public void Death() {

        Pannel.SetActive(true);
        Time.timeScale = 0;

    }   

    public void OnRestart() {
        Stats.Instance.Reset();
        Barikade.SetActive(Stats.DefaultBarikadeIsShown);
        ItemEntferner.SetActive(Stats.DefaultEntfernerItemIsShown);
        JumpItem.SetActive(Stats.DefaultJumpItemIsShown);

        Time.timeScale = 1;
        Pannel.SetActive(false);
    }

    public void OnMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNames.MainMenu);
    }
  }
