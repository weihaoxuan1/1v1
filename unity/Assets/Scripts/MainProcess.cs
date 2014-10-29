using UnityEngine;
using System.Collections;

public class MainProcess : MonoSingleton<MainProcess> {


	public enum Stage{
        begin = 0,
		beginStart = 1,
		begining = 2,
		beginOver = 3,
		judgeStart = 4,
		judgeing = 5,
		judgeOver = 6,
		drawStart = 7,
		drawing = 8,
		drawOver = 9,
		playStart = 10,
		playing = 11,
		playOver = 12,
		discardStart = 13,
		discarding = 14,
		discardOver = 15,
		endStart = 16,
		ending = 17,
		endOver = 18
	};

    public struct StageEvent
    {
        public int turn;
        public float time;
        public Stage curStage;
        //public Player opposite;
        //public Player self;
    };

    public delegate void OnStageDelegate(StageEvent stageEvent);
    private OnStageDelegate onStageDels;

    public void RegOnStageDelegate(OnStageDelegate onStageDel)
    {
        onStageDels += onStageDel;
    }

    public void UnregOnStageDelegate(OnStageDelegate onStageDel)
    {
        if (onStageDels != null)
            onStageDels -= onStageDel;
    }

	int turn;
	float time;
	Stage curStage;
	public Player opposite;
    public Player self;
    StageEvent stageEvent;
    public UILabel info;


	// Use this for initialization
	void Start () {
        stageEvent = new StageEvent();
        curStage = (Stage)0;
        turn = 1;
        time = 0;
        opposite = Player.Instance;// _Enemy.Instance;
        self = Player.Instance;
        Debug.Log("Started the game");
        //NextStage();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

	public void NextStage()
	{
        if (curStage >= (Stage)19)
        {
            curStage = (Stage)0;
            turn++;
            Debug.Log("next turn "+turn);
        }
        curStage++;
        info.text = "curStage is " + curStage;
        Debug.Log("curStage is " + curStage +" "+(int)curStage);
		
        
        if (onStageDels != null)
            onStageDels(GetStageEvent());
        if (curStage != (Stage)8 && curStage != (Stage)14 && curStage != (Stage)11)
        {
            //Debug.Log("xuan");
            Invoke("NextStage",1);
        }
        
	}

    public void GameOver()
    {
        Application.Quit();
    }

    StageEvent GetStageEvent()
    {
        stageEvent.curStage = curStage;
        stageEvent.turn = turn;
        stageEvent.time = time;
        //stageEvent.self = self;
        //stageEvent.opposite = opposite;
        return stageEvent;
    }
}
