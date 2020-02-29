using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsUpdater: MonoBehaviour {

    public TextMeshProUGUI SauerstoffText;
    public TextMeshProUGUI JumpText;
    public Slider Slider;
    public GameObject GameOverScript;

    [UsedImplicitly]
    private void Update()
    {
        SetHealth(Stats.Instance.Health);
    }

    [UsedImplicitly]
    private void LateUpdate() {

        //Timer
        Stats.Instance.GameTime += Time.deltaTime;
        Stats.Instance.Sauerstoff = (int) Math.Floor(Stats.Instance.MaxSauerstoff * (1 - Stats.Instance.PercentageTimeUsed));

        //setst den Text
        SauerstoffText.text = $"Sauerstoff: {Stats.Instance.Sauerstoff}";
        JumpText.text       = $"Jumps: {Stats.Instance.Jumps}";

        

        if (Stats.Instance.GameTime >= Stats.Instance.MaxGameTime) {
            GameOverScript.GetComponent<GameOver>().Death();
        }

    }

    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }

    public void SetHealth(int health)
    {
        Slider.value = health;
    }

}