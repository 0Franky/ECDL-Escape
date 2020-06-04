using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUtils : MonoBehaviour {

    Slider slider;
    public CombatManager manager;
    public bool isTimeActive = false;
    // Start is called before the first frame update
    void Start() {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update() {
        if (isTimeActive) {
            slider.value -= Time.deltaTime;
            if(slider.value == 0) {
                isTimeActive = false;
                manager.TimeExpired();
            }
        }
    }
}
