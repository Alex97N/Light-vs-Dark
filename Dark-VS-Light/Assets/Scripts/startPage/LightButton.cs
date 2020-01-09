using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightButton : MonoBehaviour
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
        
        TurnSystem.darkOrLight = false;
        
        yield return new WaitForSeconds(5);
        
        SceneManager.LoadScene("BattleScene");
        
    }
    
    public void startGameLight(){
        StartCoroutine(startDelay());
    }  
}
