using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityGainView : View
{
    [SerializeField]
    private TextMeshProUGUI[] titles;
    [SerializeField]
    private TextMeshProUGUI[] descs;
    [SerializeField]
    private Button button1;
    [SerializeField]
    private Button button2;
    [SerializeField]
    private Button button3;

    private List<Ability> shownAbilities;

    public override void Initialize()
    {
        EventManager<Ability[]>.AddListener(EventType.ON_ABILITY_GAIN, ShowAvaliableAbilities);

        button1.onClick.AddListener(() => GiveAbility(0));
        button2.onClick.AddListener(() => GiveAbility(1));
        button3.onClick.AddListener(() => GiveAbility(2));
    }

    private void ShowAvaliableAbilities(Ability[] abilities)
    {
        ViewManager.Show(this);

        shownAbilities = new List<Ability>();

        for(int i = 0; i < titles.Length; i++)
        {
            Ability ability = abilities[Random.Range(0, abilities.Length)];
            
            shownAbilities.Add(ability);
            titles[i].text = ability.title;
            descs[i].text = ability.desc;
        }
    }

    private void GiveAbility(int index)
    {
        EventManager<Ability>.RaiseEvent(EventType.ON_GIVE_ABILITY, shownAbilities[index]);

        ViewManager.ShowLast();
    }
}
