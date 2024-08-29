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

    private string[] _furigana = {"いぬ","もんだい","ねこ","うなぎ","さけ","ぶた","とり","うし"};
    private string[] _question = {"犬","問題","猫","鰻","鮭","豚","鳥","牛"};
    private string[] _answer = {"inu","mondai","neko","unagi","sake","buta","tori","usi"};

    private string _fString;
    private string _qString;
    private string _aString;

    private int _qNum;
    private int _aNum;

    // 正解数を保持する変数
    public int CorrectCount {get; set;}

    public bool isPlaying = false;

    private AudioSource audiosource;
    public AudioClip typingSE;
    public AudioClip CorrectSE;
    void Start()
    {
        OutPut();
        CorrectCount = 0;  // 正解数を初期化
        UpdateCorrectCount();

        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isPlaying){
        if (Input.GetKeyDown(_aString[_aNum].ToString()))
        {
            audiosource.PlayOneShot(typingSE);
            Correct();
            if (_aNum >= _aString.Length)
            {
                OutPut();
            }
        }

        }

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

        // 正解数を増やす
        if (_aNum >= _aString.Length)
        {
            CorrectCount++;
            UpdateCorrectCount();
            audiosource.PlayOneShot(CorrectSE);
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