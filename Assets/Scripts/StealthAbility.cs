using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealthAbility : MonoBehaviour
{
    public Slider timer;
    public float SliderTime;
    float SliderTimeCounter;
    public bool isStealth;
    public Material[] solidList;
    public Material[] transparentList;

    SkinnedMeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        SliderTimeCounter = SliderTime;
        timer.gameObject.SetActive(true);
        isStealth = false;
        mesh = GetComponent<SkinnedMeshRenderer>();
    }
    
    void Update()
    {
        
        timer.value = SliderTimeCounter/SliderTime;

        if(Input.GetKeyDown(KeyCode.Alpha1) && SliderTimeCounter == SliderTime)
        {
            isStealth = !isStealth;
            Stealth(isStealth);
        }
        
        if(isStealth)
        {
            HandleStealthMath();
        }
        else
        {
            if(SliderTimeCounter < SliderTime)
            {
                SliderTimeCounter += Time.deltaTime;
            }
            else
            {
                if(SliderTimeCounter > SliderTime)
                {
                    SliderTimeCounter = SliderTime;
                }
            }
        }
    }

    private void HandleStealthMath()
    {
        SliderTimeCounter -= Time.deltaTime;
        if(SliderTimeCounter <= 0)
        {
            isStealth = false;
            Stealth(isStealth);
        }
    }


    public void Stealth(bool answer)
    {
        if(answer)
        {
            mesh.materials = transparentList;
        }
        else
        {
            mesh.materials = solidList;
        }
    }
}
