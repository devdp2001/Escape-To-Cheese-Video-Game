using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created By: Sophia Wu
// Date:       12/03/2023
//             Used to trigger stealth skill tutorial popups after
//             player has completed first minigame.

public class SkillTutorialTrigger : MonoBehaviour
{
    public GameObject text_1;
    public GameObject text_2;
    public GameObject text_3;

    bool skillUsed;
    float skillStartTime = -1;

    // Start is called before the first frame update
    void Start()
    {
        skillUsed = false;
        startSkillTutorial();
    }

    void startSkillTutorial() {
        skillStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // this tutorial can only be shown once - first time when player presses [1]
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            skillUsed = true;
        }
        //Debug.Log(skillStartTime+" "+Time.time);
        if (skillStartTime >= 0 && Time.time >= skillStartTime && skillUsed == true)
        {
            // after pressing 1, show text_2
            // after 5 seconds, show text_3
            if (Time.time - skillStartTime > 7.5)
            {
                text_2.SetActive(false);
                text_3.SetActive(true);
                skillUsed = false;
            }
            else if (Time.time - skillStartTime > 0)
            {
                text_1.SetActive(false);
                text_2.SetActive(true);
            }
        }


    }
}
