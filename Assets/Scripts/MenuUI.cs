using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Canvas transitions for the Menu scene
public class MenuUI : MonoBehaviour {

    public GameObject[] m_Canvases;

    // Loads the next scene in the build
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Turns off the current canvas and turns on the target canvas
    public void TransitionCanvas(GameObject target) {
        for (int index = 0; index < m_Canvases.Length; index++) {
            if (m_Canvases[index].activeInHierarchy) {
                m_Canvases[index].SetActive(false);
            }
            if (m_Canvases[index] == target) {
                m_Canvases[index].SetActive(true);
            }
        }
    }

    // Closes the application
    public void QuitGame() {
        Application.Quit();
    }
}
