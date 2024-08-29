using UnityEngine;

public class CheckYPosition : MonoBehaviour
{
    GameController gameController;
    

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    void Update()
    {
        
        if (transform.position.y < -2)
        {
            
            Destroy(this.gameObject);
            gameController.SubScore();
            Debug.Log("point lost!");
                
            
        }
    }
}
