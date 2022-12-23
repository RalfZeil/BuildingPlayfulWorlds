using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : View
{
    [SerializeField]
    private Slider healthSlider;

    public override void Initialize()
    {
        EventManager<float>.AddListener(EventType.ON_TAKE_DAMAGE, UpdateHealth);
        EventManager<float>.AddListener(EventType.ON_HEALTH_GAIN, UpdateHealth);
    }

    private void OnDestroy()
    {
        EventManager<float>.RemoveListener(EventType.ON_TAKE_DAMAGE, UpdateHealth);
        EventManager<float>.RemoveListener(EventType.ON_HEALTH_GAIN, UpdateHealth);
    }

    private void UpdateHealth(float health)
    {
        healthSlider.value = health;
    }
}
