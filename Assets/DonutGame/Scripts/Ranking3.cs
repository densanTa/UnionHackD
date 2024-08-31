using UnityEngine;
using UnityEngine.UI;

public class Ranking3 : MonoBehaviour {

    [SerializeField,Header("数値")]
    

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    private int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    public Text firsttext3;
    public Text secondtext3;
    public Text thirdtext3;
    public Text forthtext3;
    public Text fifthtext3;

    public int tokuten3 = 0;
    
    // Use this for initialization
    void Start ()
    {
        tokuten3 = Timecounter_c.score_3;

        GetRanking();

        SetRanking(tokuten3);

        
            firsttext3.text = "1st : " + rankingValue[0].ToString();
            secondtext3.text = "2nd : " + rankingValue[1].ToString();
            thirdtext3.text = "3rd : " + rankingValue[2].ToString();
            forthtext3.text = "4th : " + rankingValue[3].ToString();
            fifthtext3.text = "5th : " + rankingValue[4].ToString();
        
        tokuten3 = 0;
        
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