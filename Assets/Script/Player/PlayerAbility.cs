using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public virtual void Active(AbilitiesCode abilitiesCode)
    {
        Debug.Log("AbilitiesCode: " + abilitiesCode.ToString());
    }
}