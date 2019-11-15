using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

	public List<MonsterCard> deckMonsters = new List<MonsterCard>() ;

	public static List<MonsterCard> staticMonsterDeck = new List<MonsterCard>() ;

	public int idMonster;
	public int deckMonstersSize;

	public GameObject TopBack;

	public GameObject CardToHand;

	public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        deckMonstersSize = 10;

		for(int i =0;i<deckMonstersSize;i++){
		
			idMonster = Random.Range(0,5);

			deckMonsters[i] = MonsterCardDataBase.monsterCardList[idMonster];

		}

		StartCoroutine(StartGame());

    }

    // Update is called once per frame
    void Update()
    {
		staticMonsterDeck = deckMonsters;

        if(deckMonstersSize == 0){
			TopBack.SetActive(false);
		}else if (deckMonstersSize > 0 && !TopBack.activeSelf){
			TopBack.SetActive(true);
		}
    }

	public void Shuffle(){
	
		MonsterCard auxMonster = new MonsterCard();
		
		for(int i=0;i<deckMonstersSize;i++){
		
			auxMonster = deckMonsters[i];
			idMonster = Random.Range(i,deckMonstersSize);
			deckMonsters[i] = deckMonsters[idMonster];
			deckMonsters[idMonster] = auxMonster;

		}
	
	}

	IEnumerator StartGame(){

		for(int i =0;i<=4;i++){
		
			yield return new WaitForSeconds(1);
			Instantiate(CardToHand,transform.position,transform.rotation);
		}

	}

}
