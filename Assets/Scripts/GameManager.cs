using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


}