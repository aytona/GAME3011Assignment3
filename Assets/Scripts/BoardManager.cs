using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {

    public GameObject[] m_board;
    public Text m_playerTurn;
    private GameManager m_manager;

    public GameObject boardCanvas;
    public Text GameOver;

    void Awake() {
        m_manager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if (m_manager.playerTurn) {
            m_playerTurn.text = "Player's turn";
        } else if (!m_manager.playerTurn) {
            m_playerTurn.text = "AI's turn";
        }

        for (int i = 0; i < 9; i++) {
            if (m_manager.gameBoard[i] == -1) {
                m_board[i].GetComponentInChildren<Text>().text = "X";
            } else if (m_manager.gameBoard[i] == 1) {
                m_board[i].GetComponentInChildren<Text>().text = "O";
            } else {
                m_board[i].GetComponentInChildren<Text>().text = "";
            }
        }

        if (m_manager.winnerNum == 1) {
            boardCanvas.SetActive(false);
            GameOver.gameObject.SetActive(true);
            GameOver.text = "You Lose!";
        } else if (m_manager.winnerNum == 2) {
            boardCanvas.SetActive(false);
            GameOver.gameObject.SetActive(true);
            GameOver.text = "You Win!";
        } else if (m_manager.winnerNum == 3) {
            boardCanvas.SetActive(false);
            GameOver.gameObject.SetActive(true);
            GameOver.text = "It's a Draw!";
        }
    }

    public void PlayerTurn(int index) {
        m_manager.PlayerMove(index);
    }
}
