using TMPro;
using UnityEngine;

public class GameView : View
{
    [SerializeField] private TextMeshProUGUI healthText;

    public override void Initialize()
    {
        EventManager<float>.AddListener(EventType.ON_TAKE_DAMAGE, UpdateHealth);
    }

    private void UpdateHealth(float health)
    {
        healthText.text = health.ToString();
    }
}
