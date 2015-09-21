using UnityEngine;
using System.Collections;

/// <summary>
/// 牌堆类
/// </summary>
public class Deck : MonoBehaviour {
    public static Deck Instance;
	Deck()
	{
		Instance = this;
	}
    /// <summary>
    /// 标准牌堆
    /// </summary>
    public GameObject[] standardCardPile;
    /// <summary>
    /// 当前牌堆的list
    /// </summary>
    public BetterList<GameObject> cardPile;
    /// <summary>
    /// 当前牌堆的数组
    /// </summary>
    public GameObject[] arrayCardPile;
    /// <summary>
    /// 弃牌堆的list
    /// </summary>
    public BetterList<GameObject> discardPile;
    /// <summary>
    /// 弃牌堆的数组
    /// </summary>
    public GameObject[] arrayDiscardPile;
    /// <summary>
    /// 剩余牌的张数
    /// </summary>
    int _restCardsNumber;
    public int restCardsNumber
    {
        get { return _restCardsNumber; }
        set
        {
            _restCardsNumber = value;
            if (_restCardsNumber <= 0)
                WashDeck();
        }
    }
    //Card_Sha sha;
    //Card_Shan shan;
    //Card_Tao tao;
	// Use this for initialization
    public void Reset()
    {
        InitDeck();
    }

	void Start () {
        //MainProcess.Instance.RegOnStageDelegate(OnStageDel);
        
        if (Instance == null) Debug.Log("Deck is null");
        else Debug.Log("Deck is not null");
	    cardPile = new BetterList<GameObject>();
        discardPile = new BetterList<GameObject>();
        //sha = new Card_Sha();
        //shan = new Card_Shan();
        //tao = new Card_Tao();
        standardCardPile = new GameObject[52];
        //读取Resources文件夹下的所有卡牌预制
        standardCardPile = Resources.LoadAll<GameObject>("AllCards");
        InitDeck();
        //for (int i = 0; i < 50; i++)
        //{
        //    Debug.Log(arrayCardPile[i].name);
        //}
        InvokeRepeating("SetArrayCardPile", 1f, 1f);
	}
    /*
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "mopai"))
        {
            DrawCard();
        }
        if (GUI.Button(new Rect(100, 0, 100, 100), "panding"))
        {
            Judge();
        }
        if (GUI.Button(new Rect(200, 0, 100, 100), "mopai2"))
        {
            DrawCard(2);
        }
        if (GUI.Button(new Rect(300, 0, 100, 100), "qipai3"))
        {
            DiscardFormDeckTop(3);
        }
        if (GUI.Button(new Rect(400, 0, 100, 100), "qipai"))
        {
            DiscardFormDeckTop();
        }
        if (GUI.Button(new Rect(500, 0, 100, 100), "zhanshi"))
        {
            print(ShowCardFromDeckTop().name);
        }
        if (GUI.Button(new Rect(600, 0, 100, 100), "zhanshi3"))
        {
            GameObject[] t= ShowCardFromDeckTop(3);
            for(int i=0;i<t.Length;i++)
                print(t[i].name);
        }
    }
    */
    /// <summary>
    /// 初始化牌堆，洗牌,一局游戏结束后再调用
    /// </summary>
    void InitDeck()
    {
        //int totalCardNum = gameObject.transform.childCount;
        ////获取deck对象下的全部卡牌并存入cardpile
        //for(int i = 0;i<totalCardNum;i++)
        //{
        //    GameObject temp = gameObject.transform.GetChild(i).gameObject;
        //    cardPile.Add(temp);
        //}
        for (int i = 0; i < standardCardPile.Length; i++)
        {
            cardPile.Add(standardCardPile[i]);
        }
        BetterList<GameObject> tempList = new BetterList<GameObject>();
        //第一次洗牌
        for (int i = 0; i < standardCardPile.Length; i++)
        {
            int index = Random.Range(0,cardPile.size);
            tempList.Add(cardPile[index]);
            cardPile.RemoveAt(index);
        }
        restCardsNumber = tempList.size;
        cardPile = tempList;
        //arrayCardPile = cardPile.ToArray();
        print("finish init Deck");
    }
	// Update is called once per frame
	void Update () {
	    
	}

    void SetArrayCardPile()
    {
        print("SetArrayCardPile");
        arrayCardPile = cardPile.ToArray();
    }

    /// <summary>
    /// 从牌堆顶摸牌
    /// </summary>
    /// <returns></returns>
    public GameObject DrawCard()
    {
        //防止还没有pop掉牌堆最后一张牌就洗牌,因此先pop再rest--
        GameObject temp = cardPile.Pop();
        restCardsNumber--;
        Debug.Log("draw a " + temp.name);
        return temp;
        //MainProcess.Instance.NextStage();
    }
    public GameObject[] DrawCard(int num)
    {
        GameObject[] temps = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            //防止还没有pop掉牌堆最后一张牌就洗牌,因此先pop再rest--
            GameObject temp = cardPile.Pop();
            restCardsNumber--;
            Debug.Log("draw a " + temp.name);
            temps[i] = temp;
        }
        return temps;
        //MainProcess.Instance.NextStage();
    }

    /// <summary>
    /// 从牌堆顶判定一张牌
    /// </summary>
    /// <returns></returns>
    public GameObject Judge()
    {
        Debug.Log("judged a " + cardPile[restCardsNumber - 1].name);
        //防止还没有pop掉牌堆最后一张牌就洗牌,因此先pop再rest--
        GameObject temp = cardPile.Pop();
        restCardsNumber--;
        //Warning判定后不一定马上进弃牌堆,以后有相关逻辑时要改
        return DiscardCard(temp);
    }

    /// <summary>
    /// 从牌堆顶弃牌
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public GameObject DiscardFormDeckTop()
    {
        //防止还没有pop掉牌堆最后一张牌就洗牌,因此先pop再rest--
        GameObject temp = cardPile.Pop();
        restCardsNumber--;
        return DiscardCard(temp);
    }
    public GameObject[] DiscardFormDeckTop(int num)
    {
        GameObject[] temps = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            //防止还没有pop掉牌堆最后一张牌就洗牌,因此先pop再rest--
            GameObject temp = cardPile.Pop();
            restCardsNumber--;
            temps[i] = DiscardCard(temp);
        }
        return temps;
    }

    /// <summary>
    /// 从牌堆顶展示一张牌
    /// </summary>
    /// <returns></returns>
    public GameObject ShowCardFromDeckTop()
    {
        return cardPile[cardPile.size - 1];
    }
    public GameObject[] ShowCardFromDeckTop(int num)
    {
        GameObject[] temps = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            temps[i] = cardPile[cardPile.size - 1 - i];
        }
        return temps;
    }

    /// <summary>
    /// 洗牌,把弃牌堆的牌随机放回牌堆,根据规则请在牌堆没牌后才调用
    /// </summary>
    public void WashDeck()
    {
        //Warning现在的洗牌算法中最后一张牌不会洗入新的牌堆,以后看看要不要改
        int rest = discardPile.size;
        for (int i = 0; i < rest; i++)
        {
            int index = Random.Range(0, discardPile.size);
            cardPile.Add(discardPile[index]);
            discardPile.RemoveAt(index);
        }
        restCardsNumber = cardPile.size;
        print("finish wash deck");
    }

    public GameObject DiscardCard(GameObject c)
    {
        discardPile.Add(c);
        arrayDiscardPile = discardPile.ToArray();
        //Player_Man.Instance.CheckHoldCards ();
        //Player_Enemy.Instance.CheckHoldCards ();
        return c;
    }

    /*void OnStageDel(MainProcess.StageEvent stageEvent)
    {
        if (stageEvent.curStage == MainProcess.Stage.drawing)
        {
            DrawCard();
            MainProcess.Instance.NextStage();
        }
        
    }*/
}
