using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkButton : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator startDelay(){
        
        TurnSystem.darkOrLight = true;
        
        yield return new WaitForSeconds(5);
        
        SceneManager.LoadScene("BattleScene");
        
    }
    
    public void startGameDark(){
        StartCoroutine(startDelay());
    }
}
