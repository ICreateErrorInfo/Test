using System;

using JetBrains.Annotations;

using UnityEngine;

using TMPro;

public class StatsUpdater: MonoBehaviour {

    public TextMeshProUGUI SauerstoffText;
    public TextMeshProUGUI LebenText;
    public TextMeshProUGUI JumpText;

    [UsedImplicitly]
    private void LateUpdate() {

        Stats.Instance.GameTime += Time.deltaTime;
        Stats.Instance.Sauerstoff = (int) Math.Floor(Stats.Instance.MaxSauerstoff * (1 - Stats.Instance.PercentageTimeUsed));

        LebenText.text      = $"Leben: {Stats.Instance.Leben}";
        SauerstoffText.text = $"Sauerstoff: {Stats.Instance.Sauerstoff}";
        JumpText.text       = $"Jumps: {Stats.Instance.Jumps}";

        

        if (Stats.Instance.GameTime >= Stats.Instance.MaxGameTime) {
            // Game Over!!
        }

    }

}