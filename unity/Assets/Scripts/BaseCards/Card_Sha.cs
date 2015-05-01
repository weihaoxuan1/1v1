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

	public override void Effect(Player user)
	{
        base.Effect(user);
		print ("sha effect");
        user.opposite.CallingShan();
        //user.opposite.DecreaseHp(1);
	}
	
	public void OnClick()
	{
        if (!Player_Man.Instance.isPlayingStage || Player_Man.Instance.isHaveSha) return;
        Player_Man.Instance.PlaySha(this);
		Debug.Log ("played a sha");
        
	}
}