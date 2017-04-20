using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Canvas transitions for the Menu scene
public class MenuUI : MonoBehaviour {

    public GameObject[] m_Canvases;

    private GameManager m_manager;

    void Awake() {
        m_manager = FindObjectOfType<GameManager>();
    }

    // Loads the next scene in the build
    public void PlayGame() {
        m_manager.gameInit = true;
        m_manager.StartGame = true;
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

    // Sets the current difficulty of the game when a button is pressed
    // Creates a GameManager incase there isn't one to set the difficulty to
    public void SetDifficulty(string difficulty) {
        if (FindObjectOfType<GameManager>()) {
            GameManager.Instance.CurrentDifficulty = StringToGameDifficulty(difficulty);
        } else {
            GameObject gameManager = new GameObject("GameManager", typeof(GameManager));
            gameManager.GetComponent<GameManager>().CurrentDifficulty = StringToGameDifficulty(difficulty);
        }
    }

    // Converts the incoming string input into a GameDifficulty enum
    private GameDifficulty StringToGameDifficulty(string diff) {
        switch (diff) {
            case "Easy":
                return GameDifficulty.Easy;
            case "Medium":
                return GameDifficulty.Medium;
            case "Hard":
                return GameDifficulty.Hard;
            case "Impossible":
                return GameDifficulty.Impossible;
            default:
                Debug.Log("No match.. \nDefault to easy difficulty");
                return GameDifficulty.Easy;
        }
    }

    // Closes the application
    public void QuitGame() {
        Application.Quit();
    }
}
