using UnityEngine;
using System.Collections;
/// <summary>
/// 敌人类
/// </summary>
public class Player_Enemy : Player
{
    public static Player_Enemy Instance;
    public int i = 0;
    public float AItime = 1;
    float timeDelay = 0;

    public delegate void OnChooseCardDelegate(Card card);
    private OnChooseCardDelegate onChooseCardDels;

    public void RegOnChooseCardDelegate(OnChooseCardDelegate onChooseCardDel)
    {
        onChooseCardDels += onChooseCardDel;
    }
    public void UnregOnChooseCardDelegate(OnChooseCardDelegate onChooseCardDel)
    {
        if(onChooseCardDels != null)
            onChooseCardDels -= onChooseCardDel;
    }

    void Start()
    {
        Instance = this;
        //opposite = Player_Man.Instance;
        //MainProcess.Instance.RegOnStageDelegate(OnStageDel);
        maxHealth = 4;
        curHealth = 4;
        pHoldCards = -1;
        holdCardsNumber = 0;
    }

    void Update()
    {
        AI();
    }

    public override void OnStageDel(MainProcess.StageEvent stageEvent)
    {
        //Debug.Log("this is enemy del");
        if (!MainProcess.Instance.isMyTurn)
        {
            if (stageEvent.curStage == MainProcess.Stage.beginStart)
            {
                Debug.Log(MainProcess.Instance.isMyTurn ? "my turn" : "enemy turn");
                MainProcess.Instance.NextStage();
            }
            else if (stageEvent.curStage == MainProcess.Stage.drawing)
            {
                Draw();
                MainProcess.Instance.NextStage();
            }
            else if (stageEvent.curStage == MainProcess.Stage.playing)
            {
                isPlayingStage = true;
                //MainProcess.Instance.NextStage();
            }
            else if (stageEvent.curStage == MainProcess.Stage.discarding)
            {
                EnterDiscardingStage();
            }
            else if (stageEvent.curStage == MainProcess.Stage.endOver)
            {
                //MainProcess.Instance.isMyTurn = !MainProcess.Instance.isMyTurn;
                this.Unreg();
                opposite.Reg();
                MainProcess.Instance.NextStage();
            }
            else
                MainProcess.Instance.NextStage();
        }
    }
    //被要求出闪
    public override void CallingShan()
    {
        isCallingShan = true;
        int count = 0;
        foreach (Card c in holdCards)
        {
            if (c.name.Equals("shan") && isCallingShan)
            {
                c.Effect(this);
                break;
            }
            count++;
        }
        if (!isCallingShan)
        {
            holdCards.RemoveAt(count);
            Debug.Log("opposite played shan");
            CheckHoldCards();
        }
        else
        {
            isCallingShan = false;
            DecreaseHp(1);
        }
    }

    public void OnChose(Card card)
    {
        onChooseCardDels(card);
    }

    void AI()
    {
        if (isPlayingStage && !opposite.isCallingShan)
        {
            Debug.Log("1");
            timeDelay += Time.deltaTime;
            if (timeDelay >= AItime )
            {
                Debug.Log("2");
                if (i < holdCards.Count)
                {
                    Debug.Log("3");
                    timeDelay = 0;
                    if (holdCards[i].name.Equals("tao") && curHealth < maxHealth)//有桃吃桃
                    {
                        Debug.Log("4");
                        holdCards[i].Effect(this);
                        holdCards.RemoveAt(i);
                        CheckHoldCards();
                        Debug.Log("enemy use a tao");
                    }
                    else if (holdCards[i].name.Equals("sha") && !isHaveSha)//有杀杀,没杀过
                    {
                        Debug.Log("5");
                        holdCards[i].Effect(this);
                        holdCards.RemoveAt(i);
                        CheckHoldCards();
                        isHaveSha = true;
                        if (MainProcess.Instance.info) MainProcess.Instance.info.text = "enemy use a sha";
                        Debug.Log("enemy use a sha");
                    }
                    else
                    {
                        Debug.Log("6");
                        i++;
                    }
                }
                else
                {
                    Debug.Log("7");
                    timeDelay = 0;
                    isPlayingStage = false;
                    isHaveSha = false;
                    i = 0;
                    MainProcess.Instance.NextStage();
                }
            }
        }
    }
}