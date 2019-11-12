using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

	public List<MonsterCard> deckMonsters = new List<MonsterCard>() ;

	public int idMonster;
	public int deckMonstersSize;

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
        
    }
}
