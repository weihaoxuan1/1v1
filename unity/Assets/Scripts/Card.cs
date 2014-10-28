using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour{

	public int color;
	public int number;
	public bool clickable;
	public string name;

	public virtual void Effect(){}

}