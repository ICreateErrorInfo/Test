using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsUpdater: MonoBehaviour {

    public TextMeshProUGUI SauerstoffText;
    public TextMeshProUGUI JumpText;
    public Slider slider;

    private void Update()
    {
        SetHealth(Stats.Instance.Health);
    }

    [UsedImplicitly]
    private void LateUpdate() {

        Stats.Instance.GameTime += Time.deltaTime;
        Stats.Instance.Sauerstoff = (int) Math.Floor(Stats.Instance.MaxSauerstoff * (1 - Stats.Instance.PercentageTimeUsed));

        SauerstoffText.text = $"Sauerstoff: {Stats.Instance.Sauerstoff}";
        JumpText.text       = $"Jumps: {Stats.Instance.Jumps}";

        

        if (Stats.Instance.GameTime >= Stats.Instance.MaxGameTime) {
            // Game Over!!
        }

    }

    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}