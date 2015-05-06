using UnityEngine;
using System.Collections;

public class Card_ZhangBa : Card_Equipment {

	// Use this for initialization
	void Start () {
		equipmentType = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(MainProcess.Instance.isMyTurn && MainProcess.Instance.GetCurstage() == MainProcess.Stage.playing && gameObject.transform.parent.gameObject.name == "PlayerHandCard")
		{
			clickable = true;
		}
		else 
		{
			clickable = false;
		}
	}

	protected override void OnEquiped (Player user)
	{
		base.OnEquiped (user);
		//moving add a script to make weapon clickable and able to use it's effect
	}

	protected override void OnUnequiped (Player user)
	{
		base.OnUnequiped (user);
		//moving delete the script
	}

	void OnClick()
	{
		if(clickable)
		{
			OnEquiped(Player_Man.Instance);
		}
	}
}
