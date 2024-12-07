using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Slider slider = gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(changeVolume);
    }


    // Update is called once per frame
    void Update()
    {
        
        

    }
    
    public void changeVolume(float value)
    {
        AudioListener.volume = value;

    }

}
