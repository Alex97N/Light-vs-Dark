using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{ 

    public List<GameObject> zones = new List<GameObject>();

    public int monsterCardsHand;

	public GameObject MonsterCardObject;

	public GameObject PlayerDeckObject;

	public PlayerDeck playerDeck;
	public ThisMonsterCard thisMonsterCard;
	public MonsterCard monsterCard;

    void Start()
    {
        playerDeck = PlayerDeckObject.GetComponent<PlayerDeck>();
        thisMonsterCard = MonsterCardObject.GetComponent<ThisMonsterCard>();

		StartCoroutine(StartGame());
        monsterCardsHand = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator StartGame(){

		yield return new WaitForSeconds(5);

		for (int i =0;i<=4;i++){

			yield return new WaitForSeconds(1);

            monsterCard = playerDeck.deckMonsters[playerDeck.deckMonstersSize - 1];

            playerDeck.deckMonsters.RemoveAt(playerDeck.deckMonstersSize-1);
			
			playerDeck.deckMonstersSize-=1;
            (MonsterCardObject.GetComponent<ThisMonsterCard>()).setMonster(monsterCard);
            MonsterCardObject.tag = "CardToHand";

            GameObject gameObject = Instantiate(MonsterCardObject, zones[i].transform.position, zones[i].transform.rotation) as GameObject;

            //GameObject gameObjectToInst = new GameObject();
            //gameObjectToInst = MonsterCardObject;
            //Instantiate(MonsterCardObject, zones[monsterCardsHand].transform.position, zones[monsterCardsHand].transform.rotation);
            monsterCardsHand++;


        }

	}

    public GameObject positionForCard()
    {
        if (monsterCardsHand <= 5)
        {
            return zones[monsterCardsHand-1];
        }
        else return null;
    }

}
