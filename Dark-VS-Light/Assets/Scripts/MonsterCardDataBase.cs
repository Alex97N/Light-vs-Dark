using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterCardDataBase : MonoBehaviour {
    
	public static List<MonsterCard> monsterCardList = new List<MonsterCard> ();

	void Awake(){
	
		monsterCardList.Add ( new MonsterCard("m1","Demon1",6,100,150,"Army of hell") );	
		monsterCardList.Add ( new MonsterCard("m2","Demon2",5,80,100,"Army of hell") );	
		monsterCardList.Add ( new MonsterCard("m3","Demon3",7,120,180,"Army of hell") );	
		monsterCardList.Add ( new MonsterCard("m4","Demon4",8,150,230,"Army of hell") );	
		monsterCardList.Add ( new MonsterCard("m5","Demon5",9,200,300,"Army of hell") );	
		
	}

}
