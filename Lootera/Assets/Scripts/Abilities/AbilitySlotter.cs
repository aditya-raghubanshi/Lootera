using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlotter : MonoBehaviour
{
    // Start is called before the first frame update
    AbilitySlots abilities;
    void Start()
    {
        abilities = GetComponent<AbilitySlots>();
        abilities.SetAbility1(38);
        abilities.SetAbility2(39);
        abilities.SetAbility3(40);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
