using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameSettingsクラスはMonoBehaviourを継承しません。
public static class GameSettings
{
    // TypingManager の Difficulty 列挙型を利用する
    public static TypingManager.Difficulty selectedDifficulty = TypingManager.Difficulty.Easy;
}
