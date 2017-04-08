using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Changes the background/skybox and rotates it
public class BGTransition : MonoBehaviour {

    public float m_RotSpeed;

    private void Update() {
        RotateBG();
    }

    // Sets the rotation float of the skybox with time and rotation speed
    private void RotateBG() {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * m_RotSpeed);
    }

}
