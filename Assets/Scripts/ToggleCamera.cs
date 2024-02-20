using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCamera : MonoBehaviour
{
    public bool arrowEnabled; 
    public Button button;
    public NewInputManager inputManager; 
    public Sprite check; 
    public Sprite uncheck;
    // Start is called before the first frame update
    void Start()
    {
       arrowEnabled = PlayerPrefs.GetInt("ArrowE") == 1;
       if (!arrowEnabled){
           button.image.sprite = uncheck; 
       }
       else{
           button.image.sprite = check; 
       }  
    }
    public void ToggleButton()
    {
        arrowEnabled = !arrowEnabled;
        PlayerPrefs.SetInt("ArrowE",arrowEnabled ? 1 : 0);
        inputManager.toggleButton(arrowEnabled); 

        if (!arrowEnabled){
            button.image.sprite = uncheck; 
        }
        else{
            button.image.sprite = check; 
        }
    }
}
