using UnityEngine;
using UnityEngine.UI;

public class Ranking3 : MonoBehaviour {

    [SerializeField,Header("数値")]
    

    string[] rankingc = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    public int[] rankingValuec = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    public Text firsttext3;
    public Text secondtext3;
    public Text thirdtext3;
    public Text forthtext3;
    public Text fifthtext3;

    
    // Use this for initialization
    void Start ()
    {
        

        GetRanking();
        if(selecter.sel == 3) {
        SetRanking(GameController.score);
        Debug.Log("set3");
        }

        
            firsttext3.text = "1st : " + rankingValuec[0].ToString();
            secondtext3.text = "2nd : " + rankingValuec[1].ToString();
            thirdtext3.text = "3rd : " + rankingValuec[2].ToString();
            forthtext3.text = "4th : " + rankingValuec[3].ToString();
            fifthtext3.text = "5th : " + rankingValuec[4].ToString();
        
    

        
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    private void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < rankingc.Length; i++)
        {
            rankingValuec[i]=PlayerPrefs.GetInt(rankingc[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    private void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < rankingc.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValuec[i])
                {
                    var change = rankingValuec[i];
                    rankingValuec[i] = _value;
                    _value = change;
                }
        }

        //入れ替えた値を保存
        for (int i = 0; i < rankingc.Length; i++)
        {
            PlayerPrefs.SetInt(rankingc[i],rankingValuec[i]);
        }
    }
}