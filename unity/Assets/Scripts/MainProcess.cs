using UnityEngine;
using System.Collections;

public class MainProcess : MonoBehaviour {

    public static MainProcess Instance;

	public enum Stage{
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

	int turn;
	float time;
	Stage curStage;
	public Player opposite;
    public Player self;


	// Use this for initialization
	void Start () {
        Instance = this;
        curStage = (Stage)1;
        turn = 1;
        time = 0;
        opposite = Player_Enemy.Instance;
        self = Player_Man.Instance;
        Debug.Log("Started the game");
        NextStage();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	public void NextStage()
	{
        curStage++;
        Debug.Log("curStage is " + curStage);
		
        if (curStage == (Stage)8)
		{
			Deck.Instance.DrawCard();
		}
        if (curStage == (Stage)11)
		{
            self.EnterPlayingStage();
		}
        if (curStage == (Stage)14)
		{
            self.EnterDiscardingStage();
		}
        if (curStage >= (Stage)19)
		{
            curStage = (Stage)1;
			turn++;
		}
        NextStage();
	}

}
