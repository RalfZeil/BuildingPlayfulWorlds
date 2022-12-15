using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityGainView : View
{
    [SerializeField]
    private TextMeshProUGUI titleText1;
    [SerializeField]
    private TextMeshProUGUI descText1;
    [SerializeField]
    private Button button1;

    [SerializeField]
    private TextMeshProUGUI titleText2;
    [SerializeField]
    private TextMeshProUGUI descText2;
    [SerializeField]
    private Button button2;

    [SerializeField]
    private TextMeshProUGUI titleText3;
    [SerializeField]
    private TextMeshProUGUI descText3;
    [SerializeField]
    private Button button3;

    public override void Initialize()
    {
        EventManager.AddListener(EventType.ON_ABILITY_GAIN, ShowAvaliableAbilities);
    }

    private void ShowAvaliableAbilities()
    {

    }
}
