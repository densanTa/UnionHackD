using UnityEngine;
using UnityEngine.UI;

public class Ranking1 : MonoBehaviour {

    [SerializeField,Header("数値")]
    

    string[] rankinga = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    public int[] rankingValuea = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    public Text firsttext1;
    public Text secondtext1;
    public Text thirdtext1;
    public Text forthtext1;
    public Text fifthtext1;

    
    
    // Use this for initialization
    void Start ()
    {
                
        GetRanking();
        if(selecter.sel == 1){
        SetRanking(GameController.score);
        Debug.Log("set1");
        }
        
            firsttext1.text = "1st : " + rankingValuea[0].ToString();
            secondtext1.text = "2nd : " + rankingValuea[1].ToString();
            thirdtext1.text = "3rd : " + rankingValuea[2].ToString();
            forthtext1.text = "4th : " + rankingValuea[3].ToString();
            fifthtext1.text = "5th : " + rankingValuea[4].ToString();

        

    }

        
        
    

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    private void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < rankinga.Length; i++)
        {
            rankingValuea[i]=PlayerPrefs.GetInt(rankinga[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    private void SetRanking(int _valuea)
    {
        //書き込み用
        for (int i = 0; i < rankinga.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_valuea>rankingValuea[i])
                {
                    var changea = rankingValuea[i];
                    rankingValuea[i] = _valuea;
                    _valuea = changea;
                }
        }

        //入れ替えた値を保存
        for (int i = 0; i < rankinga.Length; i++)
        {
            PlayerPrefs.SetInt(rankinga[i],rankingValuea[i]);
        }
    }
}