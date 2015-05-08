using UnityEngine;
using System.Collections;

public class Card_Sha : Card{
    public Card_Sha()
    {
        name = "sha";
    }

    void Start()
    {
        //name = "sha";
    }
	void Update()
	{
		base.Update();
	}
	public override void Effect(Player user)
	{
        base.Effect(user);
		if(user.isCallingSha)
		{
			user.isCallingSha = false;
			return;
		}
		print ("sha effect");
        user.opposite.CallingShan();
        //user.opposite.DecreaseHp(1);
	}
	
	public void OnClick()
	{
        /*switch((int)PlayerStatus.Instance.curStatus)
        {
            case 0:
                Player_Man.Instance.PlaySha(this);
                break;
            case 1:
                Player_Enemy.Instance.isCallingSha = true;

        }*/
		if(clickableAllChoose)
		{
			BaseOnClick();
			return;
		}
		if(gameObject.transform.parent.gameObject.name == "EnemyHandCard")return;
        if (Player_Man.Instance.isPlayingStage && !Player_Man.Instance.isHaveSha && transform.parent.gameObject.name == "PlayerHandCard")
		{
        	Player_Man.Instance.PlaySha(this);
		}
		Debug.Log ("played a sha");
        
	}
}