using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField] Text fText;
    [SerializeField] Text qText;
    [SerializeField] Text aText;
    [SerializeField] Text correctCountText;

    // 難易度ごとの問題リスト
    private string[][] furiganaLists;
    private string[][] questionLists;
    private string[][] answerLists;

    private string[] _furigana;
    private string[] _question;
    private string[] _answer;

    private string _fString;
    private string _qString;
    private string _aString;

    private int _qNum;
    private int _aNum;

    // 正解数を保持する変数
    public int CorrectCount { get; set; }

    public bool isPlaying = true;

    // 難易度の変数
    public enum Difficulty { Easy, Medium, Hard, Expert }
    public Difficulty currentDifficulty;

    private AudioSource audiosource;
    public AudioClip typingSE;
    public AudioClip correctSE;

    void Start()
{
    // 難易度ごとに問題リストを初期化
    InitializeQuestions();

    // GameSettings から現在の難易度を取得
    currentDifficulty = GameSettings.selectedDifficulty;

    // 現在の難易度に応じた問題リストを選択
    SetQuestionsForDifficulty(currentDifficulty);

    OutPut();
    CorrectCount = 0;  // 正解数を初期化
    audiosource = GetComponent<AudioSource>();
    UpdateCorrectCount();
}


    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(_aString[_aNum].ToString().ToLower()) ||
                Input.GetKeyDown(_aString[_aNum].ToString().ToUpper()))
            {
                Correct();
                if (_aNum >= _aString.Length)
                {
                    OutPut();
                }
            }
        }
    }

    void InitializeQuestions()
    {
        // Easy, Medium, Hard, Expertの順に問題を設定
        furiganaLists = new string[][]
        {
            new string[] {"いぬ","ねこ"}, // Easy
            new string[] {"もんだい","うし"}, // Medium
            new string[] {"うなぎ","さけ"}, // Hard
            new string[] {"ぶた","とり"}  // Expert
        };

        questionLists = new string[][]
        {
            new string[] {"犬","猫"}, // Easy
            new string[] {"問題","牛"}, // Medium
            new string[] {"鰻","鮭"}, // Hard
            new string[] {"豚","鳥"}  // Expert
        };

        answerLists = new string[][]
        {
            new string[] {"inu","neko"}, // Easy
            new string[] {"mondai","usi"}, // Medium
            new string[] {"unagi","sake"}, // Hard
            new string[] {"buta","tori"}  // Expert
        };
    }

    void SetQuestionsForDifficulty(Difficulty difficulty)
    {
        int index = (int)difficulty;
        _furigana = furiganaLists[index];
        _question = questionLists[index];
        _answer = answerLists[index];
    }

    void OutPut()
    {
        _aNum = 0;
        _qNum = Random.Range(0, _question.Length);

        _fString = _furigana[_qNum];
        _qString = _question[_qNum];
        _aString = _answer[_qNum];

        fText.text = _fString;
        qText.text = _qString;
        aText.text = _aString;
    }

    void Correct()
    {
        _aNum++;
        aText.text = "<color=#6A6A6A>" + _aString.Substring(0, _aNum) + "</color>" + _aString.Substring(_aNum);
        audiosource.PlayOneShot(typingSE);

        // 正解数を増やす
        if (_aNum >= _aString.Length)
        {
            CorrectCount++;
            audiosource.PlayOneShot(correctSE);
            UpdateCorrectCount();
        }
    }

    public void UpdateCorrectCount()
    {
        if (correctCountText != null)
        {
            correctCountText.text = "" + CorrectCount;
        }
    }
}
