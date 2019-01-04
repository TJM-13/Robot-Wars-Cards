using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject opponent;

	public GameObject[] cards;
	public List<GameObject> playerDeck;
	public List<GameObject> opponentDeck;
	private GameObject tempGO;
	
	// Use this for initialization
	void Start () {

		Shuffle();

		//Deal 15 each
		DealCards();

	}

	public void Shuffle()
	{
		for(int i = 0; i< cards.Length; i++)
		{
			int rnd = Random.Range(0, cards.Length);
			tempGO = cards[rnd];
			cards[rnd] = cards[i];
			cards[i] = tempGO;
		}
	}

	public void DealCards()
	{
		for(int i = 0; i< cards.Length; i++)
		{
			if(i%2 == 0)
			{
				playerDeck.Add(cards[i]);
			}
			else
			{
				opponentDeck.Add(cards[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		




	}
}
