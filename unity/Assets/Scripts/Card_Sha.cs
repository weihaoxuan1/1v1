using UnityEngine;
using System.Collections;

public class Card_Sha : Card{

	public override void Effect()
	{
		MainProcess.Instance.opposite.SufferSha();
	}
}