using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 玩家基类
/// </summary>
public class Player : MonoBehaviour {

    //public static Player Instance;

    public  int maxHealth;
    public  int curHealth;

    public GameObject self;
    public GameObject handCard;

    //public static Card[] judgementCards;
    //public static Card[] holdCards;
    public List<Card> judgementCards;
    public List<Card> holdCards;
    public  int pHoldCards;
    public  int holdCardsNumber;
    public  bool isPlayingStage = false;//是否出牌阶段
    public  bool isDrawingStage = false;//是否摸牌阶段
    public  bool isDiscardingStage = false;//是否弃牌阶段
    public bool isCallingShan = false;//是否被要求出闪
    public bool isCallingTao = false;//是否求桃
    public bool isCallingWuXie = false;//是否求无懈
    public bool isCallingHoldChoose = false;
    public bool isCallingAllChoose = false;
    public bool isHaveSha = false;//是否已杀过
    public Player opposite;//指对方,方便使用卡牌效果

    public UILabel Health;
    public UILabel holdCardsLabel;

    //public bool isMyTurn = true;
    public void Reset()
    {
        curHealth = 4;
        holdCards.Clear();
        pHoldCards = -1;
        holdCardsNumber = 0;
        isPlayingStage = false;
        isDrawingStage = false;
        isDiscardingStage = false;
        isCallingShan = false;
        isCallingTao = false;
        isHaveSha = false;
        if (Health) Health.text = "4/4";
        if (holdCardsLabel) holdCardsLabel.text = "";
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
        pHoldCards = -1;
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
            foreach (Card c in holdCards)
            {

                if (c.name.Equals("tao"))
                {
                    c.Effect(this);
                    Debug.Log("self played tao");
                    pHoldCards--;
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
        for (int i = 0; i < num;i++ )
        {
            //holdCards.Add(Deck.Instance.DrawCard());
            pHoldCards++;
            handCard.GetComponent<HandCard>().AddCard(Deck.Instance.DrawCard());
        }
        holdCardsNumber += num;
        //holdCards[1] = Deck.Instance.DrawCard();
        //Debug.Log("handcard = "+pHoldCards.ToString() + holdCards[1].name);
        //holdCards[++pHoldCards] = Deck.Instance.DrawCard();

        Debug.Log("handcardNO = " + holdCardsNumber);
        //if (holdCards[1] == null)
        //    Debug.Log(" is verynull");
        /*for (int i = 0; i < holdCardsNumber; i++)
        {
			//holdCards[i] = new Card();
            if (holdCards[i] == null)
                Debug.Log(i.ToString() + " is verynull");
            //Debug.Log("checkholdcards" + i);
            else
                holdCardsLabel.text = holdCards[i].name + " ";
        }*/
        CheckHoldCards();
        //pHoldCards = holdCardsNumber;
    }

    

    public int IncreaseHp(int point)
    {
        curHealth += point;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (Health) Health.text = curHealth.ToString() + "/4";
        return curHealth;
    }

    public int DecreaseHp(int point)
    {
        curHealth -= point;
        if(Health)Health.text = curHealth.ToString() + "/4";
        CheckDead();
        return curHealth;
    }

    public Card LostCard(int i)
    {
        Card temp = holdCards[i];
        Debug.Log("Lost " + temp.name);
        holdCards.RemoveAt(i);
        CheckHoldCards();
        return temp;
    }

    public List<Card> SetJudgementCard(Card c)
    {
        judgementCards.Add(c);
        return judgementCards;
    }

    public virtual void CallingShan()
    {
    }

    public virtual void CallingWuXie()
    {
    }

    public virtual void CallingTao()
    {
    }

    public void CheckHoldCards()
    {
        /*for (int i = 0; i < holdCardsNumber; i++)
        {
            if (holdCards[i] == null)
                Debug.Log(i.ToString() + " is null");
            //Debug.Log("checkholdcards" + i);
            else
            holdCardsLabel.text = holdCards[i].name + " ";
        }*/
        //holdCardsLabel.text = "";
        foreach (Card a in holdCards)
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