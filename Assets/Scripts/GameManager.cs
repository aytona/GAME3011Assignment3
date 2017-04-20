using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameDifficulty {
    Easy,
    Medium,
    Hard,
    Impossible
}

public class GameManager : SingletonClass<GameManager> {

    private GameDifficulty m_CurrentDifficulty = GameDifficulty.Easy;   // Default difficulty at the start

    // Difficulty getter and setter
    public GameDifficulty CurrentDifficulty {
        get {
            return m_CurrentDifficulty;
        } set {
            m_CurrentDifficulty = value;
        }
    }

    public bool gameInit = false;
    public bool playerTurn = true;

    public int[] gameBoard;
    private int numTurns;

    public bool StartGame = false;

    public int winnerNum = 0;

    private void InitGameboard() {
        numTurns = 0;
        gameInit = false;
        winnerNum = 0;
        gameBoard = new int[] {
            0, 0, 0,
            0, 0, 0,
            0, 0, 0
        };
    }

    void Update() {
        if (gameInit) {
            InitGameboard();
        }
        if (!playerTurn && numTurns < 9) {
            AIMove();
        }

        if (StartGame) {
            int winner = CheckWin();
            if (winner != 0) {
                switch (winner) {
                    case 1:
                        winnerNum = 1;
                        break;
                    case -1:
                        winnerNum = 2;
                        break;
                }
            } else if (numTurns >= 9) {
                winnerNum = 3;
            }
        }
    }

    public void PlayerMove(int index) {
        if (gameBoard[index] == 0) {
            numTurns++;
            gameBoard[index] = -1;
            playerTurn = false;
        }
    }

    private int CheckWin() {
        if ((gameBoard[0] == 1 && gameBoard[1] == 1 && gameBoard[2] == 1) ||
            (gameBoard[3] == 1 && gameBoard[4] == 1 && gameBoard[5] == 1) ||
            (gameBoard[6] == 1 && gameBoard[7] == 1 && gameBoard[8] == 1) ||
            (gameBoard[0] == 1 && gameBoard[3] == 1 && gameBoard[6] == 1) ||
            (gameBoard[1] == 1 && gameBoard[4] == 1 && gameBoard[7] == 1) ||
            (gameBoard[2] == 1 && gameBoard[5] == 1 && gameBoard[8] == 1) ||
            (gameBoard[0] == 1 && gameBoard[4] == 1 && gameBoard[8] == 1) ||
            (gameBoard[2] == 1 && gameBoard[4] == 1 && gameBoard[6] == 1)) {
            return 1;
        } else if ((gameBoard[0] == -1 && gameBoard[1] == -1 && gameBoard[2] == -1) ||
            (gameBoard[3] == -1 && gameBoard[4] == -1 && gameBoard[5] == -1) ||
            (gameBoard[6] == -1 && gameBoard[7] == -1 && gameBoard[8] == -1) ||
            (gameBoard[0] == -1 && gameBoard[3] == -1 && gameBoard[6] == -1) ||
            (gameBoard[1] == -1 && gameBoard[4] == -1 && gameBoard[7] == -1) ||
            (gameBoard[2] == -1 && gameBoard[5] == -1 && gameBoard[8] == -1) ||
            (gameBoard[0] == -1 && gameBoard[4] == -1 && gameBoard[8] == -1) ||
            (gameBoard[2] == -1 && gameBoard[4] == -1 && gameBoard[6] == -1)) {
            return -1;
        }

        return 0;
    }

    private void AIMove() {
        numTurns++;
        switch (m_CurrentDifficulty) {
            case GameDifficulty.Easy:
                gameBoard[EasyAI()] = 1;
                break;
            case GameDifficulty.Impossible:
                gameBoard[ImpossibleAI()] = 1;
                break;
        }
        playerTurn = true;
    }

    private int EasyAI() {
        int randIndex = Random.Range(0, gameBoard.Length);
        return gameBoard[randIndex] == 0 ? randIndex : EasyAI();
    }

    private int ImpossibleAI() {
        int move = -1;
        int score = -2;
        int i;
        for (i = 0; i < 9; ++i) {
            if (gameBoard[i] == 0) {
                gameBoard[i] = 1;
                int tempScore = -MinMax();
                gameBoard[i] = 0;
                if (tempScore > score) {
                    score = tempScore;
                    move = i;
                }
            }
        }

        return move;
    }

    private int MinMax() {
        int move = -1;
        int score = -2;
        int i;
        for (i = 0; i < 9; ++i) {
            if (gameBoard[i] == 0) {
                gameBoard[i] = -1;
                int thisScore = -MinMax();
                if (thisScore > score) {
                    score = thisScore;
                    move = i;
                }
                gameBoard[i] = 0;
            }
        }
        if (move == -1) {
            return 0;
        }
        return score;
    }
}