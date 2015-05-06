using UnityEngine;
using System.Collections;

public class Card_LianNu : Card_Equipment {

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
		AllEventDelegate.Instance.RegOnPlayedShaDelegate(EquipmentEffect);
	}

	protected override void OnUnequiped (Player user)
	{
		base.OnUnequiped (user);
		AllEventDelegate.Instance.UnregOnPlayedShaDelegate(EquipmentEffect);
	}

	void OnClick()
	{
		if(clickable)
		{
			OnEquiped(Player_Man.Instance);
		}
	}

	bool EquipmentEffect(Player user,GameObject sha)
	{
		if(user.isHaveSha = true)
		{
			user.isHaveSha = false;
		}
		return true;
	}

}
