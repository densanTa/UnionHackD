using UnityEngine;
using UnityEngine.UI;

public class Ranking4 : MonoBehaviour {

    [SerializeField,Header("数値")]
    

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    private int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    public Text firsttext4;
    public Text secondtext4;
    public Text thirdtext4;
    public Text forthtext4;
    public Text fifthtext4;

    public int tokuten4 = 0;
    
    // Use this for initialization
    void Start ()
    {
        tokuten4 = Timecounter_d.score_4;

        GetRanking();

        SetRanking(tokuten4);

        
            firsttext4.text = "1st : " + rankingValue[0].ToString();
            secondtext4.text = "2nd : " + rankingValue[1].ToString();
            thirdtext4.text = "3rd : " + rankingValue[2].ToString();
            forthtext4.text = "4th : " + rankingValue[3].ToString();
            fifthtext4.text = "5th : " + rankingValue[4].ToString();
        
        tokuten4 = 0;
        
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    private void GetRanking()
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
    private void SetRanking(int _value)
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