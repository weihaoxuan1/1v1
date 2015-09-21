using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 玩家基类
/// </summary>
public class Player : MonoBehaviour {

    //public static Player Instance;

    public int maxHealth;
    public int curHealth;

    public GameObject self;
    public GameObject handCard;
	public GameObject wuQiArea;
	public GameObject fangJuArea;
	public GameObject wuQi;
	public GameObject fangJu;

    public GameObject[] handCards;

    //public static Card[] judgementCards;
    //public static Card[] holdCards;
    public BetterList<GameObject> judgementCards = new BetterList<GameObject>();
    public BetterList<GameObject> holdCards = new BetterList<GameObject>();
    public int holdCardsNumber;
    public bool isPlayingStage = false;//是否出牌阶段
    public bool isDrawingStage = false;//是否摸牌阶段
    public bool isDiscardingStage = false;//是否弃牌阶段
	public bool isCallingSha = false;
    public bool isCallingShan = false;//是否被要求出闪
    public bool isCallingTao = false;//是否求桃
    public bool isCallingWuXie = false;//是否求无懈
    public bool isCallingHoldChoose = false;
    public bool isCallingAllChoose = false;
    public bool isHaveSha = false;//是否已杀过
    public Player opposite;//指对方,方便使用卡牌效果

    public GameObject healthCard;
    public UILabel holdCardsLabel;

    //public bool isMyTurn = true;
    public void Reset()
    {
        curHealth = 4;
        holdCards.Clear();
        holdCardsNumber = 0;
        isPlayingStage = false;
        isDrawingStage = false;
        isDiscardingStage = false;
        isCallingShan = false;
        isCallingTao = false;
        isHaveSha = false;
        //if (Health) Health.text = "4/4";
        //if (holdCardsLabel) holdCardsLabel.text = "";
        Unreg();
    }

    void Start()
    {
        Debug.Log("Player Start()");
        //MainProcess.Instance.RegOnStageDelegate(OnStageDel);
        //Instance = this;
        
        maxHealth = 4;
        curHealth = 4;
        //judgementCards = new Card[3];
        //holdCards = new Card[20];
        holdCardsNumber = 0;
        //holdCards[1] = new Card_Sha();
    }

    void OnEnable()
    {
        Debug.Log("Player OnEnable()");
    }

    void Update()
    {
        //CheckHoldCards();
    }

    
	/*public void SufferSha()
	{
		curHealth--;
        enemyHealth.text = curHealth.ToString() + "/4"; 
        Debug.Log("being sha , injure 1 point , curHealth = "+curHealth);
        CheckDead();
	}*/

    public void EnterDrawingStage()
    {
        isDrawingStage = true;
        Debug.Log("isDrawingStage " + isDrawingStage);
    }

	public void EnterPlayingStage()
    {
        isPlayingStage = true;
        Debug.Log("EnterPlayingStage " + isPlayingStage);
        //PlaySha();
    }

    public void EnterDiscardingStage()
    {
        Debug.Log("Discarding cards");
        MainProcess.Instance.NextStage();
    }



    void CheckDead()
    {
        if (curHealth <= 0)
        {
            Debug.Log("somebody dead");
            MainProcess.Instance.GameOver();
        }
    }

    public void PlaySha(Card_Sha sha)
    {
        //Debug.Log("isPlayingStage = " + isPlayingStage);
        if (isPlayingStage)
        {
            //Card temp = null;
            //int count = 0;
            sha.Effect(this);
            holdCardsNumber--;
            isHaveSha = true;
            /*foreach (Card c in holdCards)
            {
                
                if (c.name.Equals("sha") && isHaveSha == false)
                {
                    c.Effect(this);
                    //holdCards[pHoldCards].Effect(this);
                    Debug.Log("self played sha");
                    pHoldCards--;
                    holdCardsNumber--;
                    //temp = c;

                    //MainProcess.Instance.NextStage();
                    
                    isHaveSha = true;
                    holdCards.RemoveAt(count);
                    CheckHoldCards();
                    return;
                }
                count++;
            }
            if (isHaveSha == false)
            {
                Debug.Log("there is no sha");
            }
            /*if (temp)
            {
                Debug.Log("self played" + temp.name);
                holdCards.Remove(temp);
            }*/
        }
    }

    public void PlayTao()
    {
        if (isPlayingStage && curHealth<maxHealth)
        {
            //Card temp = null;
            int count = 0;
            foreach (GameObject c in holdCards)
            {

                if (c.name.Equals("tao"))
                {
                    c.gameObject.GetComponent<Card_Tao>().Effect(this);
                    Debug.Log("self played tao");
                    holdCardsNumber--;
                    holdCards.RemoveAt(count);
                    CheckHoldCards();
                    return;
                }
                count++;
            }
        }
    }

    public void Draw(int num)
    {
        GameObject[] temp = Deck.Instance.DrawCard(num);
        for (int i = 0; i < temp.Length; i++)
        {
            //temp[i].transform.parent
            holdCards.Add(temp[i]);
        }
        handCards = holdCards.ToArray();

        
        CheckHoldCards();
    }

    

    public int IncreaseHp(int point)
    {
		for(int i=0;i<point;i++)
		{
			if(curHealth < maxHealth)
			{
				curHealth++;      
				print ("health add 1");
				healthCard.GetComponent<HeroCoverHealth>().IncreaseHealth(maxHealth);
			}
		}
        //if (Health) Health.text = curHealth.ToString() + "/4";
        return curHealth;
    }

    public int DecreaseHp(int point)
    {
        curHealth -= point;
        //if(Health)Health.text = curHealth.ToString() + "/4";
		healthCard.GetComponent<HeroCoverHealth>().DecreaseHealth(maxHealth);
        CheckDead();
        return curHealth;
    }

    public GameObject LostCard(GameObject c)
    {
        //GameObject temp = holdCards[i];
        Debug.Log("Lost " + c.name);
        holdCards.Remove(c);
		handCard.GetComponent<HandCard>().OutCard (c);
		//Destroy (c);
        CheckHoldCards();
        return c;
    }

	public void GetCard(GameObject c)
	{
		holdCards.Add(c);
		handCard.GetComponent<HandCard>().AddCard(c);
		CheckHoldCards ();
	}

    public BetterList<GameObject> SetJudgementCard(GameObject c)
    {
        judgementCards.Add(c);
        return judgementCards;
    }

    public virtual void CallingShan()
    {
    }

    public virtual bool CallingWuXie()
    {
		return false;
    }

    public virtual void CallingTao()
    {
    }

	public virtual void CallingSha()
	{
	}

    public void CheckHoldCards()
    {
		print ("check hold cards");
		holdCardsNumber = holdCards.size;
		handCard.GetComponent<UIGrid>().enabled = true;
        /*for (int i = 0; i < holdCardsNumber; i++)
        {
            if (holdCards[i] == null)
                Debug.Log(i.ToString() + " is null");
            //Debug.Log("checkholdcards" + i);
            else
            holdCardsLabel.text = holdCards[i].name + " ";
        }*/
        //holdCardsLabel.text = "";
        foreach (GameObject a in holdCards)
        {
            //holdCardsLabel.text += a.name + " ";
        }
    }



    public void Reg()
    {
        MainProcess.Instance.RegOnStageDelegate(OnStageDel);
    }
    public void Unreg()
    {
        MainProcess.Instance.UnregOnStageDelegate(OnStageDel);
    }
    public virtual void OnStageDel(MainProcess.StageEvent stageEvent) { }
}