using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            gameController.AddScore();
        }
    }
}