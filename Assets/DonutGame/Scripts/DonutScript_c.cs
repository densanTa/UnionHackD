using UnityEngine;

public class CheckYPosition_c : MonoBehaviour
{
    GameController_c gameController_c;
    

    void Start()
    {
        gameController_c = GameObject.Find("GameController_c").GetComponent<GameController_c>();
    }


    void Update()
    {
        
        if (transform.position.y < -2)
        {
            
            Destroy(this.gameObject);
            gameController_c.SubScore_c();
            Debug.Log("point lost!");
                
            
        }
    }
}
