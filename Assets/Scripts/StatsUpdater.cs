using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class StatsUpdater : MonoBehaviour {

    public TextMeshProUGUI SauerstoffText;
    public TextMeshProUGUI LebenText;
    public TextMeshProUGUI JumpText;

    [UsedImplicitly]
    private void LateUpdate() {
        LebenText.text = $"Leben: {Stats.Instance.Leben}";
        SauerstoffText.text = $"Sauerstoff: {Stats.Instance.Sauerstoff}";
        JumpText.text = $"Jumps: {Stats.Instance.Jumps}";
    }
}
