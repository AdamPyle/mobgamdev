using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDoubleTap : MonoBehaviour
{

float tapTimer = 0f;
public float doubleTapInterval = 0.2f;
bool tapped = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if tapped is true, start timer.
        if(tapped) {
            tapTimer += Time.deltaTime;
            // if it has been more than 0.2 seconds...
            if(tapTimer > doubleTapInterval) {
                SingleTap();
                tapped = false;
            }
        }
        if(Input.anyKeyDown) {
            // if tapped within 0.2 seconds, call doubletap
            if(tapped) {
                DoubleTap();
                tapped = false;
            } else {
                tapped = true;
            }
            
        }
         
}

void SingleTap() {
    Debug.Log("<color=red>Single Tap!</color>");
    Debug.Log("Timer = " + tapTimer);
    tapTimer = 0;

    // change the color to a random color
    this.GetComponent<Renderer>().material.color = Random.ColorHSV();
}

void DoubleTap () {
    Debug.Log("<color=blue>Double Tap!</color>");
    Debug.Log("Timer = " + tapTimer);
    tapTimer = 0;

    // increase the size by 20%

    this.transform.localScale += Vector3.one * 0.2f;
    // if scale is greater than 5, reset to 1.
    if(this.transform.localScale.x > 5) {
        this.transform.localScale = Vector3.one;
    }
}
}