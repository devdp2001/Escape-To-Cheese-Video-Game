using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Created By: Sophia Wu
/// Date:       10/30/2023
///     Implementation of toggling of visual UI element when skills are used,
///     indicating if the ability is on or off cooldown.
///     TODO: Implement cooldown when skill is used.

public class SkillUI : MonoBehaviour
{
    public Renderer playerCapsule;

    private GameObject skillOffCD;
    private GameObject skillOnCD;

    // Start is called before the first frame update
    void Start()
    {
        skillOffCD = GameObject.Find("Invisibility: Usable");
        skillOnCD = GameObject.Find("Invisibility: Cooldown");

        print(playerCapsule.material.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCapsule.material.name == "TransparentRed (Instance)")
        {
            skillOffCD.SetActive(false);
            skillOnCD.SetActive(true);
        }
        else if (playerCapsule.material.name == "Red (Instance)")
        {
            skillOffCD.SetActive(true);
            skillOnCD.SetActive(false);
        }
    }
}
