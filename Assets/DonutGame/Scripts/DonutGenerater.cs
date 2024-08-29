
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float speed = 1f;
    public GameObject Pivot;
    public GameObject Generator;
    public TypingManager typingManager;
    GameController gameController;
    public bool isPlaying = false;

    private AudioSource audiosource;
    public AudioClip dropSE;
    public AudioClip dropmissSE;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        if (typingManager == null)
        {
            typingManager = FindObjectOfType<TypingManager>();
        }

        audiosource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(Pivot.transform.position, Generator.transform.position);

        if (isPlaying)
        {
            if (typingManager.CorrectCount > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation);

                gameController.AddScore();
                audiosource.PlayOneShot(dropSE);


                SpawnPrefab spawnedScript = spawnedObject.GetComponent<SpawnPrefab>();
                if (spawnedScript != null)
                {
                    Destroy(spawnedScript);
                }

                Debug.Log(typingManager.CorrectCount);

                typingManager.CorrectCount--;
                typingManager.UpdateCorrectCount();
            }

            if (typingManager.CorrectCount == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                audiosource.PlayOneShot(dropmissSE);
            }

            if (distance > 0.05)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
            }

            if (distance < 0.41)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(0, 0, -speed * Time.deltaTime);
                }
            }
        }
    }
}