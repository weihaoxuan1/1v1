using UnityEngine;
using System.Collections;

public class Card_HanBing : Card_Equipment {

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
		AllEventDelegate.Instance.RegOnAlmostDamageDelegate(EquipmentEffect);
	}

	protected override void OnUnequiped (Player user)
	{
		base.OnUnequiped (user);
		AllEventDelegate.Instance.UnregOnAlmostDamageDelegate(EquipmentEffect);
	}

	void OnClick()
	{
		if(clickable)
		{
			OnEquiped(Player_Man.Instance);
		}
	}

	bool EquipmentEffect(Player user, GameObject card)
	{
		if(card.name == "sha")
		{
			return false;
		}
		else return true;
	}
}
