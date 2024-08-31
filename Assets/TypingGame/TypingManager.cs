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

    private string[] _furigana = {"かばん","いえ","やね","すまほ","ぱそこん","まいく","いやほん","いす","むし","おせろ","はいしん","おんがく","びんご","のり","でんち","えんぴつ","べると","はんがー","ぼうし","げーむ","まんが","めがね","こんびに","どうが","こらぼ","ぱり","ろんどん","おおさか","こうべ","おかやま","とうきょう","せんだい","ばいと","かわ","さいん","おにぎり","ぱん","らーめん","うどん","かがわ","きょうと","うし","うま","しか","うさぎ","いぬ","ねこ","ぶた","とかげ","くも","とんぼ","ばった"};
    private string[] _question = {"鞄","家","屋根","スマホ","パソコン","マイク","イヤホン","椅子","虫","オセロ","配信","音楽","ビンゴ","糊","電池","鉛筆","ベルト","ハンガー","帽子","ゲーム","漫画","眼鏡","コンビニ","動画","コラボ","パリ","ロンドン","大阪","神戸","岡山","東京","仙台","バイト","川","サイン","おにぎり","パン","ラーメン","うどん","香川","京都","牛","馬","鹿","兎","犬","猫","豚","トカゲ","雲","トンボ","バッタ"};
    private string[] _answer = {"kabann","ie","yane","sumaho","pasokonn","maiku","iyahonn","isu","musi","osero","haisinn","ongaku","bingo","nori","denti","enpitu","beruto","hanga-","bousi","ge-mu","manga","megane","konbini","douga","korabo","pari","rondonn","oosaka","koube","okayama","toukyou","sendai","baito","kawa","sainn","onigiri","pann","ra-menn","udonn","kagawa","kyouto","usi","uma","sika","usagi","inu","neko","buta","tokage","kumo","tonbo","batta"};

    private string _fString;
    private string _qString;
    private string _aString;

    private int _qNum;
    private int _aNum;

    // 正解数を保持する変数
    public int CorrectCount {get; set;}

    public bool isPlaying = true;

    private AudioSource audiosource;
    public AudioClip typingSE;
    public AudioClip correctSE;
    void Start()
    {
        OutPut();
        CorrectCount = 0;  // 正解数を初期化
        audiosource = GetComponent<AudioSource>();
        UpdateCorrectCount();
    }

    void Update()
    {
      if(isPlaying){
        if (Input.GetKeyDown(_aString[_aNum].ToString()))
        {
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