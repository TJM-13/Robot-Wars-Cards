using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

	public string cardName;
	public Sprite artwork;
	public int speed;
	public int agility;
	public int experience;
	public int defence;
	public int attack;


}
