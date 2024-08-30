using UnityEngine;

public class CheckYPosition_a : MonoBehaviour
{
    GameController_a gameController_a;
    

    void Start()
    {
        gameController_a = GameObject.Find("GameController_a").GetComponent<GameController_a>();
    }


    void Update()
    {
        
        if (transform.position.y < -2)
        {
            
            Destroy(this.gameObject);
            gameController_a.SubScore_a();
            Debug.Log("point lost!");
                
            
        }
    }
}
