using UnityEngine;
using UnityEngine.UI;

public class Ranking2 : MonoBehaviour {

    [SerializeField,Header("数値")]
    

    string[] rankingb = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    public int[] rankingValueb= new int[5];

    [SerializeField, Header("表示させるテキスト")]
    public Text firsttext2;
    public Text secondtext2;
    public Text thirdtext2;
    public Text forthtext2;
    public Text fifthtext2;

    
    
    // Use this for initialization
    void Start ()
    {
        

        GetRanking();
        if(selecter.sel == 2){
        SetRanking(GameController.score);
        Debug.Log("set2");
        }

        
            firsttext2.text = "1st : " + rankingValueb[0].ToString();
            secondtext2.text = "2nd : " + rankingValueb[1].ToString();
            thirdtext2.text = "3rd : " + rankingValueb[2].ToString();
            forthtext2.text = "4th : " + rankingValueb[3].ToString();
            fifthtext2.text = "5th : " + rankingValueb[4].ToString();
        
        
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    private void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < rankingb.Length; i++)
        {
            rankingValueb[i]=PlayerPrefs.GetInt(rankingb[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    private void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < rankingb.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValueb[i])
                {
                    var change = rankingValueb[i];
                    rankingValueb[i] = _value;
                    _value = change;
                }
        }

        //入れ替えた値を保存
        for (int i = 0; i < rankingb.Length; i++)
        {
            PlayerPrefs.SetInt(rankingb[i],rankingValueb[i]);
        }
    }
}