using UnityEngine;
using System.Collections;
/// <summary>
/// 敌人类
/// </summary>
public class Player_Enemy : Player
{
    public static Player_Enemy Instance;
    public int pAI = 0;
    public float AItime = 1;
    float timeDelay = 0;

    public delegate void OnChooseCardDelegate(GameObject card);
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
                Draw(2);
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
		print ("opposite calling shan");
        isCallingShan = true;
        int count = 0;
        foreach (GameObject c in holdCards)
        {
            if (c.name.Equals("shan") && isCallingShan)
            {
                c.GetComponent<Card_Shan>().Effect(this);
                break;
            }
            count++;
        }
        if (!isCallingShan)
        {
            //holdCards.RemoveAt(count);
            Debug.Log("opposite played shan");
            CheckHoldCards();
        }
        else
        {
            isCallingShan = false;
            DecreaseHp(1);

        }
    }

    public void OnChoose(GameObject card)
    {
        onChooseCardDels(card);
		print ("guangbo");
    }

    void AI()
    {
        if (isPlayingStage && !opposite.isCallingShan)
        {
            //Debug.Log("1");
            timeDelay += Time.deltaTime;
            if (timeDelay >= AItime )
            {
                Debug.Log("2");
                if (pAI < holdCards.Count)
                {
                    Debug.Log("3");
                    timeDelay = 0;
                    if (holdCards[pAI].name.Equals("tao") && curHealth < maxHealth)//有桃吃桃
                    {
                        Debug.Log("4");
                        holdCards[pAI].GetComponent<Card_Tao>().Effect(this);
                        //holdCards.RemoveAt(pAI);
                        CheckHoldCards();
                        Debug.Log("enemy use a tao");
						return;
                    }
                    else if (holdCards[pAI].name.Equals("sha") && !isHaveSha)//有杀杀,没杀过
                    {
                        Debug.Log("5");
						holdCards[pAI].GetComponent<Card_Sha>().Effect(this);
                        //holdCards.RemoveAt(pAI);
                        CheckHoldCards();
                        isHaveSha = true;
                        if (MainProcess.Instance.info) MainProcess.Instance.info.text = "enemy use a sha";
                        Debug.Log("enemy use a sha");
						return;
                    }
                    else
                    {
                        Debug.Log("6");
                        pAI++;
                    }
                }
                else
                {
                    Debug.Log("7");
                    timeDelay = 0;
                    isPlayingStage = false;
                    isHaveSha = false;
                    pAI = 0;
                    MainProcess.Instance.NextStage();
                }
            }
        }
    }
}