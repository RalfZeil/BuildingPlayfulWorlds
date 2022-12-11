using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventManager<float>.AddListener(EventType.ON_TAKE_DAMAGE, UpdateHealthUI);
    }

    private void OnDisable()
    {
        EventManager<float>.RemoveListener(EventType.ON_TAKE_DAMAGE, UpdateHealthUI);
    }

    private void UpdateHealthUI(float newHp)
    {
        tmp.text = newHp.ToString();
    }

}
