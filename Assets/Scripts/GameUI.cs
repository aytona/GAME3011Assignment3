using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    private GameManager m_manager;

    void Awake() {
        m_manager = FindObjectOfType<GameManager>();
    }

    public void Menu() {
        m_manager.gameInit = true;
        m_manager.StartGame = false;
        SceneManager.LoadScene(0);
    }
}
