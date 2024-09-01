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
            new string[] {"かばん","いえ","やね","すまほ","ぱそこん","まいく","いやほん","いす","むし","おせろ","はいしん","おんがく","びんご","のり","でんち","えんぴつ","べると","はんがー","ぼうし","げーむ","まんが","めがね","こんびに","どうが","こらぼ","ぱり","ろんどん","おおさか","こうべ","おかやま","とうきょう","せんだい","ばいと","かわ","さいん","おにぎり","ぱん","らーめん","うどん","かがわ","きょうと","うし","うま","しか","うさぎ","いぬ","ねこ","ぶた","とかげ","くも","とんぼ","ばった","たけ", "こめ", "はり", "うみ", "あぶら", "やま", "ゆき", "はた", "すな", "はち", "いと", "いずみ", "そら", "ほし", "なみ"}, // Easy
            new string[] {"いべんと","さーくる","えいりあん","たいふう","こすぷれ","めんてなんす","ろさんぜるす","にゅーよーく","すいーつ","たっちぺん","ぬいぐるみ","あいますく","たぺすとりー","ふぁっしょん","こんせぷと","せいふく","きーぼーど","へっどほん","いやりんぐ","めんちかつ","かれーぱん","ふらいどちきん","ふらんくふると","えくれあ","しゅーくりーむ","どらやき","わっふる","ふぃなんしぇ","わらびもち","あいすくりーむ","よーぐると","かふぇらて","こーひー","れもねーど","かーどげーむ","かれんだー","きーほるだー","さんこうしょ","とーとばっぐ","ほーむらん","せんぷうき","じゅうでんき","けいこうとう","あかうんと","らんどせる","ふくぶくろ","うわのそら","げんそきごう","しあいしゅうりょう","なまやけにく","じんろうげーむ","たんこうぼん","おにぎり", "はんばーぐ", "そふとくりーむ", "ぱんけーき", "おせち", "だんご", "おむらいす", "きんぴら", "さらだ", "みたらし", "しゃぶしゃぶ", "ぐらたん"}, // Medium
            new string[] {"こんぴゅーた","えれくとろにくす","いんたーねっと","そふとうぇあ","でじたるかめら","てれびじょん","ぷろぐらむ","もばいるでばいす","しみゅれーしょん","ばーちゃるりありてぃ","どきゅめんたりー","えねるぎー","しすてむえんじにあ","てくのろじー","ぐろーばる","すーぱーまーけっと","りーだーしっぷ","いんすぴれーしょん","いのべーしょん","りさいくる","あにめーしょん","おーでぃおびじゅある","こみゅにけーしょん","あぷりけーしょん","ふぁしりてーしょん","おーとめーしょん","こんふぃぎゅれーしょん","まねーじめんと","えくすぺりえんす","ぱふぉーまんす","いんふらすとらくちゃー","でざいん","ぷれぜんてーしょん","みにまりずむ","とらんすふぉーめーしょん","ぷろとこる","まにふぇすと","ばりでーしょん","りふぁれんす","とらんじしょん","おぺれーしょん","こんせぷと","しみゅれーた","でぃれくたー","ぷろふぇっしょなる","あどみっしょん","まねじめんと","あくせぷたんす","あかでみっく","こんぽーねんと","ぱられるわーるど","おーがにっく","こんぷれっくす","あなろぐでーた","ふぃーどばっく","もちべーしょん","はーどうぇあ","えきすぱーと"}, // Hard
            new string[] {"かばん","いえ","やね","すまほ","ぱそこん","まいく","いやほん","いす","むし","おせろ","はいしん","おんがく","びんご","のり","でんち","えんぴつ","べると","はんがー","ぼうし","げーむ","まんが","めがね","こんびに","どうが","こらぼ","ぱり","ろんどん","おおさか","こうべ","おかやま","とうきょう","せんだい","ばいと","かわ","さいん","おにぎり","ぱん","らーめん","うどん","かがわ","きょうと","うし","うま","しか","うさぎ","いぬ","ねこ","ぶた","とかげ","くも","とんぼ","ばった","いべんと","さーくる","えいりあん","たいふう","こすぷれ","めんてなんす","ろさんぜるす","にゅーよーく","すいーつ","たっちぺん","ぬいぐるみ","あいますく","たぺすとりー","ふぁっしょん","こんせぷと","せいふく","きーぼーど","へっどほん","いやりんぐ","めんちかつ","かれーぱん","ふらいどちきん","ふらんくふると","えくれあ","しゅーくりーむ","どらやき","わっふる","ふぃなんしぇ","わらびもち","あいすくりーむ","よーぐると","かふぇらて","こーひー","れもねーど","かーどげーむ","かれんだー","きーほるだー","さんこうしょ","とーとばっぐ","ほーむらん","せんぷうき","じゅうでんき","けいこうとう","あかうんと","らんどせる","ふくぶくろ","うわのそら","げんそきごう","しあいしゅうりょう","なまやけにく","じんろうげーむ","たんこうぼん","こんぴゅーた","えれくとろにくす","いんたーねっと","そふとうぇあ","でじたるかめら","てれびじょん","ぷろぐらむ","もばいるでばいす","しみゅれーしょん","ばーちゃるりありてぃ","どきゅめんたりー","えねるぎー","しすてむえんじにあ","てくのろじー","ぐろーばる","すーぱーまーけっと","りーだーしっぷ","いんすぴれーしょん","いのべーしょん","りさいくる","あにめーしょん","おーでぃおびじゅある","こみゅにけーしょん","あぷりけーしょん","ふぁしりてーしょん","おーとめーしょん","こんふぃぎゅれーしょん","まねーじめんと","えくすぺりえんす","ぱふぉーまんす","いんふらすとらくちゃー","でざいん","ぷれぜんてーしょん","みにまりずむ","とらんすふぉーめーしょん","ぷろとこる","まにふぇすと","ばりでーしょん","りふぁれんす","とらんじしょん","おぺれーしょん","こんせぷと","しみゅれーた","ぷろふぇっしょなる","おにぎり", "はんばーぐ", "そふとくりーむ", "ぱんけーき", "おせち", "だんご", "おむらいす", "きんぴら", "さらだ", "みたらし", "しゃぶしゃぶ", "ぐらたん","たけ", "こめ", "はり", "うみ", "あぶら", "やま", "ゆき", "はた", "すな", "はち", "いと", "いずみ", "そら", "ほし", "なみ","あどみっしょん","まねじめんと","あくせぷたんす","あかでみっく","こんぽーねんと","ぱられるわーるど","おーがにっく","こんぷれっくす","あなろぐでーた","ふぃーどばっく","もちべーしょん","はーどうぇあ","えきすぱーと"}  // Expert
        };

        questionLists = new string[][]
        {

            new string[] {"鞄","家","屋根","スマホ","パソコン","マイク","イヤホン","椅子","虫","オセロ","配信","音楽","ビンゴ","糊","電池","鉛筆","ベルト","ハンガー","帽子","ゲーム","漫画","眼鏡","コンビニ","動画","コラボ","パリ","ロンドン","大阪","神戸","岡山","東京","仙台","バイト","川","サイン","おにぎり","パン","ラーメン","うどん","香川","京都","牛","馬","鹿","兎","犬","猫","豚","トカゲ","雲","トンボ","バッタ","竹", "米", "針", "海", "油", "山", "雪", "旗", "砂", "蜂", "糸", "泉", "空", "星", "波"}, // Easy
            new string[] {"イベント", "サークル", "エイリアン","台風", "コスプレ", "メンテナンス", "ロサンゼルス", "ニューヨーク", "スイーツ", "タッチペン", "ぬいぐるみ", "アイマスク", "タペストリー", "ファッション", "コンセプト", "制服", "キーボード", "ヘッドホン", "イヤリング", "メンチカツ", "カレーパン", "フライドチキン", "フランクフルト", "エクレア", "シュークリーム", "どら焼き", "ワッフル", "フィナンシェ", "わらび餅", "アイスクリーム", "ヨーグルト", "カフェラテ", "コーヒー", "レモネード", "カードゲーム", "カレンダー","キーホルダー","参考書","トートバッグ","ホームラン","扇風機","充電器","蛍光灯","アカウント","ランドセル","福袋","上の空","元素記号","試合終了","生焼け肉","人狼ゲーム","単行本","おにぎり", "ハンバーグ","ソフトクリーム", "パンケーキ", "おせち", "だんご", "オムライス", "きんぴら", "サラダ", "みたらし", "しゃぶしゃぶ", "グラタン"}, // Medium
            new string[] {"コンピュータ","エレクトロニクス","インターネット","ソフトウェア","デジタルカメラ","テレビジョン","プログラム","モバイルデバイス","シミュレーション","バーチャルリアリティ","ドキュメンタリー","エネルギー","システムエンジニア","テクノロジー","グローバル","スーパーマーケット","リーダーシップ","インスピレーション","イノベーション","リサイクル","アニメーション","オーディオビジュアル","コミュニケーション","アプリケーション","ファシリテーション","オートメーション","コンフィギュレーション","マネージメント","エクスペリエンス","パフォーマンス","インフラストラクチャー","デザイン","プレゼンテーション","ミニマリズム","トランスフォーメーション","プロトコル","マニフェスト","バリデーション","リファレンス","トランジション","オペレーション","コンセプト","シミュレーター","ディレクター","プロフェッショナル","アドミッション", "マネジメント", "アクセプタンス", "アカデミック", "コンポーネント", "パラレルワールド", "オーガニック", "コンプレックス", "アナログデータ", "フィードバック", "モチベーション", "ハードウェア",  "エキスパート"}, // Hard
            new string[] {"鞄","家","屋根","スマホ","パソコン","マイク","イヤホン","椅子","虫","オセロ","配信","音楽","ビンゴ","糊","電池","鉛筆","ベルト","ハンガー","帽子","ゲーム","漫画","眼鏡","コンビニ","動画","コラボ","パリ","ロンドン","大阪","神戸","岡山","東京","仙台","バイト","川","サイン","おにぎり","パン","ラーメン","うどん","香川","京都","牛","馬","鹿","兎","犬","猫","豚","トカゲ","雲","トンボ","バッタ","イベント", "サークル", "エイリアン","台風", "コスプレ", "メンテナンス", "ロサンゼルス", "ニューヨーク", "スイーツ", "タッチペン", "ぬいぐるみ", "アイマスク", "タペストリー", "ファッション", "コンセプト", "制服", "キーボード", "ヘッドホン", "イヤリング", "メンチカツ", "カレーパン", "フライドチキン", "フランクフルト", "エクレア", "シュークリーム", "どら焼き", "ワッフル", "フィナンシェ", "わらび餅", "アイスクリーム", "ヨーグルト", "カフェラテ", "コーヒー", "レモネード", "カードゲーム", "カレンダー","キーホルダー","参考書","トートバッグ","ホームラン","扇風機","充電器","蛍光灯","アカウント","ランドセル","福袋","上の空","元素記号","試合終了","生焼け肉","人狼ゲーム","単行本","コンピュータ","エレクトロニクス","インターネット","ソフトウェア","デジタルカメラ","テレビジョン","プログラム","モバイルデバイス","シミュレーション","バーチャルリアリティ","ドキュメンタリー","エネルギー","システムエンジニア","テクノロジー","グローバル","スーパーマーケット","リーダーシップ","インスピレーション","イノベーション","リサイクル","アニメーション","オーディオビジュアル","コミュニケーション","アプリケーション","ファシリテーション","オートメーション","コンフィギュレーション","マネージメント","エクスペリエンス","パフォーマンス","インフラストラクチャー","デザイン","プレゼンテーション","ミニマリズム","トランスフォーメーション","プロトコル","マニフェスト","バリデーション","リファレンス","トランジション","オペレーション","コンセプト","シミュレーター","プロフェッショナル","おにぎり", "ハンバーグ","ソフトクリーム", "パンケーキ", "おせち", "だんご", "オムライス", "きんぴら", "サラダ", "みたらし", "しゃぶしゃぶ", "グラタン","竹", "米", "針", "海", "油", "山", "雪", "旗", "砂", "蜂", "糸", "泉", "空", "星", "波","アドミッション", "マネジメント", "アクセプタンス", "アカデミック", "コンポーネント", "パラレルワールド", "オーガニック", "コンプレックス", "アナログデータ", "フィードバック", "モチベーション", "ハードウェア",  "エキスパート"}  // Expert
        };

        answerLists = new string[][]
        {

            new string[] {"kabann","ie","yane","sumaho","pasokonn","maiku","iyahonn","isu","musi","osero","haisinn","ongaku","bingo","nori","denti","enpitu","beruto","hanga-","bousi","ge-mu","manga","megane","konbini","douga","korabo","pari","rondonn","oosaka","koube","okayama","toukyou","sendai","baito","kawa","sainn","onigiri","pann","ra-menn","udonn","kagawa","kyouto","usi","uma","sika","usagi","inu","neko","buta","tokage","kumo","tonbo","batta","take","kome","hari","umi","abura","yama","yuki","hata","suna","hati","ito","izumi","sora","hosi","nami"}, // Easy
            new string[] {"ibento","sa-kuru","eiriann","taihuu","kosupure","mentenansu","rosanzerusu","nyu-yo-ku","sui-tu","tattipenn","nuigurumi","aimasuku","tapesutori-","fassyonn","konseputo","seihuku","ki-bo-do","heddohonn","iyaringu","mentikatu","kare-pann","huraidotikinn","hurankuhuruto","ekurea","syu-kuri-mu","dorayaki","wahhuru","finansye","warabimoti","aisukuri-mu","yo-guruto","kaferate","ko-hi-","remone-do","ka-doge-mu","karenda-","ki-horuda-","sankousyo","to-tobaggu","ho-murann","senpuuki","zyuudenki","keikoutou","akaunto","randoseru","hukubukuro","uwanosora","gensokigou","siaisyuuryou","namayakeniku","zinrouge-mu","tankoubon","onigiri","hanba-gu","sohutokuri-mu","panke-ki","oseti","dango","omuraisu","kinpira","sarada","mitarasi","syabusyabu","guratann"}, // Medium
            new string[] {"konpyu-ta","erekutoronikusu","inta-netto","sohutouea","dezitarukamera","terebizyon","puroguramu","mobairudebaisu","simyure-syon","ba-tyaruriariti","dokyumentari-","enerugi-","sisutemuenzinia","tekunorozi-","guro-baru","su-pa-ma-ketto","ri-da-sippu","insupire-syon","inobe-syon","risaikuru","anime-syon","o-diobizyuaru","komyunike-syon","apurike-syon","fasirite-syon","o-tome-syon","konfigyure-syon","mane-zimento","ekusuperiensu","pafo-mansu","inhurasutorakutya-","dezain","purezente-syon","minimarizumu","toransufo-me-syon","purotokoru","manifesuto","baride-syon","rifarensu","toranzisyon","opere-syon","konseputo","simyure-ta-","direkuta-","purofessyonaru","adomissyonn","manezimento","akuseputansu","akademikku","konpo-nento","parareruwa-rudo","o-ganikku","konpurekkusu","anarogude-ta","fi-dobakku","motibe-syonn","ha-dowea","ekisupa-to"}, // Hard
            new string[] {"kabann","ie","yane","sumaho","pasokonn","maiku","iyahonn","isu","musi","osero","haisinn","ongaku","bingo","nori","denti","enpitu","beruto","hanga-","bousi","ge-mu","manga","megane","konbini","douga","korabo","pari","rondonn","oosaka","koube","okayama","toukyou","sendai","baito","kawa","sainn","onigiri","pann","ra-menn","udonn","kagawa","kyouto","usi","uma","sika","usagi","inu","neko","buta","tokage","kumo","tonbo","batta","ibento","sa-kuru","eiriann","taihuu","kosupure","mentenansu","rosanzerusu","nyu-yo-ku","sui-tu","tattipenn","nuigurumi","aimasuku","tapesutori-","fassyonn","konseputo","seihuku","ki-bo-do","heddohonn","iyaringu","mentikatu","kare-pann","huraidotikinn","hurankuhuruto","ekurea","syu-kuri-mu","dorayaki","wahhuru","finansye","warabimoti","aisukuri-mu","yo-guruto","kaferate","ko-hi-","remone-do","ka-doge-mu","karenda-","ki-horuda-","sankousyo","to-tobaggu","ho-murann","senpuuki","zyuudenki","keikoutou","akaunto","randoseru","hukubukuro","uwanosora","gensokigou","siaisyuuryou","namayakeniku","zinrouge-mu","tankoubon","konpyu-ta","erekutoronikusu","inta-netto","sohutouea","dezitarukamera","terebizyon","puroguramu","mobairudebaisu","simyure-syon","ba-tyaruriariti","dokyumentari-","enerugi-","sisutemuenzinia","tekunorozi-","guro-baru","su-pa-ma-ketto","ri-da-sippu","insupire-syon","inobe-syon","risaikuru","anime-syon","o-diobizyuaru","komyunike-syon","apurike-syon","fasirite-syon","o-tome-syon","konfigyure-syon","mane-zimento","ekusuperiensu","pafo-mansu","inhurasutorakutya-","dezain","purezente-syon","minimarizumu","toransufo-me-syon","purotokoru","manifesuto","baride-syon","rifarensu","toranzisyon","opere-syon","konseputo","simyure-ta-","purofessyonaru","onigiri","hanba-gu","sohutokuri-mu","panke-ki","oseti","dango","omuraisu","kinpira","sarada","mitarasi","syabusyabu","guratann","take","kome","hari","umi","abura","yama","yuki","hata","suna","hati","ito","izumi","sora","hosi","nami","adomissyonn","manezimento","akuseputansu","akademikku","konpo-nento","parareruwa-rudo","o-ganikku","konpurekkusu","anarogude-ta","fi-dobakku","motibe-syonn","ha-dowea","ekisupa-to"}  // Expert
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
