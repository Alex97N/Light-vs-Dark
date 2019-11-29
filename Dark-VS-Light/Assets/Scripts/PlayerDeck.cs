using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

	public List<MonsterCard> deckMonsters = new List<MonsterCard>() ;

	public int idMonster;
	public int deckMonstersSize;

	public GameObject TopBack;

    // Start is called before the first frame update
    void Start()
    {
        deckMonstersSize = 10;

		for(int i =0;i<deckMonstersSize;i++){
		
			idMonster = Random.Range(0,5);

			deckMonsters[i] = MonsterCardDataBase.monsterCardList[idMonster];

		}

    }

    // Update is called once per frame
    void Update()
    {

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


	

}
