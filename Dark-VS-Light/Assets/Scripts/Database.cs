using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
   public static List<MonsterCard> monsterCardList = new List<MonsterCard> ();
   public static List<AugmentCard> augmentCardList = new List<AugmentCard> ();
   public static List<Lord> lordList = new List<Lord> ();
   
   	void Awake(){
   	
   		monsterCardList.Add ( new MonsterCard("m1","Demon1", "Army of hell", 6,100,150, 0, Resources.Load <Sprite>("m1"), Resources.Load <Sprite>("frameDark")) );	
   		monsterCardList.Add ( new MonsterCard("m2","Demon2", "Army of hell", 5,80,100, 1,  Resources.Load <Sprite>("m1"), Resources.Load <Sprite>("frameLight")) );	
   		monsterCardList.Add ( new MonsterCard("m3","Demon3", "Army of hell", 7,120,180, 0, Resources.Load <Sprite>("m1"), Resources.Load <Sprite>("frameDark")) );	
   		monsterCardList.Add ( new MonsterCard("m4","Demon4", "Army of hell", 8,150,230, 1, Resources.Load <Sprite>("m1"), Resources.Load <Sprite>("frameLight")) );	
   		monsterCardList.Add ( new MonsterCard("m5","Demon5", "Army of hell", 9,200,300, 1, Resources.Load <Sprite>("m1"), Resources.Load <Sprite>("frameLight")) );

        augmentCardList.Add(new AugmentCard("a1","Augment1",Resources.Load <Sprite>("a2"),0, new AugmentEffect("ananana")));
        augmentCardList.Add(new AugmentCard("a2","Augment2",Resources.Load <Sprite>("a1"),1, new AugmentEffect("ananana")));
        augmentCardList.Add(new AugmentCard("a3","Augment3",Resources.Load <Sprite>("a1"),2, new AugmentEffect("ananana")));
        augmentCardList.Add(new AugmentCard("a4","Augment4",Resources.Load <Sprite>("a2"),0, new AugmentEffect("ananana")));
        augmentCardList.Add(new AugmentCard("a5","Augment5",Resources.Load <Sprite>("a1"),2, new AugmentEffect("ananana")));

        lordList.Add( new Lord("l1","Yin","Lord1",0,25000,Resources.Load <Sprite>("l1"), Resources.Load <Sprite>("frameDark") ) );
        lordList.Add( new Lord("l2","Yan","Lord2",1,25000,Resources.Load <Sprite>("l2"), Resources.Load <Sprite>("frameLight") ) );

    }
   	
}
