using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode abilitiesCode;
    public override void Pressed()
    {
        Debug.Log("PressableAbility: " + abilitiesCode.ToString());
        PlayerControler.Instance._playerAbility.Active(abilitiesCode);
    }
}