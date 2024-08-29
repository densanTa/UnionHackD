
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    public float speed = 1f;  
    public GameObject Pivot;
    public GameObject Generator;
    public TypingManager typingManager;
    GameController gameController;
    public bool isPlaying = true;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        
        if (typingManager == null)
        {
            typingManager = FindObjectOfType<TypingManager>();
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(Pivot.transform.position, Generator.transform.position);

        if (isPlaying){
            if (typingManager.CorrectCount > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation);

                gameController.AddScore();

                SpawnPrefab spawnedScript = spawnedObject.GetComponent<SpawnPrefab>();
                if (spawnedScript != null)
                {
                    Destroy(spawnedScript);  
                }

                Debug.Log(typingManager.CorrectCount);

                typingManager.CorrectCount--;
                typingManager.UpdateCorrectCount();
            }

            if (distance > 0.05)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
   
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
            }


            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, 0, -speed * Time.deltaTime);
            }
        }
    }
}