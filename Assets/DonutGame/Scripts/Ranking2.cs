using UnityEngine;
using UnityEngine.UI;

public class Ranking2 : MonoBehaviour {

    [SerializeField,Header("数値")]
    

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    private int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    public Text firsttext2;
    public Text secondtext2;
    public Text thirdtext2;
    public Text forthtext2;
    public Text fifthtext2;

    public int tokuten2 = 0;
    
    // Use this for initialization
    void Start ()
    {
        tokuten2 = Timecounter_b.score_2;

        GetRanking();

        SetRanking(tokuten2);

        
            firsttext2.text = "1st : " + rankingValue[0].ToString();
            secondtext2.text = "2nd : " + rankingValue[1].ToString();
            thirdtext2.text = "3rd : " + rankingValue[2].ToString();
            forthtext2.text = "4th : " + rankingValue[3].ToString();
            fifthtext2.text = "5th : " + rankingValue[4].ToString();
        
        tokuten2 = 0;
        
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