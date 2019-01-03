using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;

	public Text nameText;
	public Text speed;
	public Text defence;
	public Text agility;
	public Text attack;
	public Text experience;

	public Image artwork;
	
	// Use this for initialization
	void Start () {
		

		nameText.text = card.cardName;
		speed.text = card.speed.ToString();
		defence.text = card.defence.ToString();
		agility.text = card.agility.ToString();
		attack.text = card.attack.ToString();
		experience.text = card.experience.ToString();
		artwork.sprite = card.artwork;
	}
	
	
}
