using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    // Simple script, updates number by one when AddKill function is called.
    public static KillCounter instance;

    [SerializeField] private TextMeshProUGUI counterText;

    private int count = 0;

    void Awake()
    {
        instance = this;
        UpdateText();
    }

    public void AddKill()
    {
        count++;
        UpdateText();
    }

    private void UpdateText()
    {
        counterText.text = count.ToString();
    }
}
