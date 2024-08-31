using UnityEngine;
using UnityEngine.UI;

public class Ranking3 : MonoBehaviour {

    [SerializeField,Header("数値")]
    

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    private int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    public Text firsttext;
    public Text secondtext;
    public Text thirdtext;
    public Text forthtext;
    public Text fifthtext;
    
    // Use this for initialization
    void Start ()
    {
        GetRanking();

        SetRanking(Timecounter_d.score_4);

        
            firsttext.text = "1st : " + rankingValue[0].ToString();
            secondtext.text = "2nd : " + rankingValue[1].ToString();
            thirdtext.text = "3rd : " + rankingValue[2].ToString();
            forthtext.text = "4th : " + rankingValue[3].ToString();
            fifthtext.text = "5th : " + rankingValue[4].ToString();
        
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i],rankingValue[i]);
        }
    }
}