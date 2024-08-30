using UnityEngine;

public class CheckYPosition_b : MonoBehaviour
{
    GameController_b gameController_b;
    

    void Start()
    {
        gameController_b = GameObject.Find("GameController_b").GetComponent<GameController_b>();
    }


    void Update()
    {
        
        if (transform.position.y < -2)
        {
            
            Destroy(this.gameObject);
            gameController_b.SubScore_b();
            Debug.Log("point lost!");
                
            
        }
    }
}
