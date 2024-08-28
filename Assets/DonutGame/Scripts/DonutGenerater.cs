<<<<<<< HEAD
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;  // oŒ»‚³‚¹‚éƒvƒŒƒnƒu‚ğw’è‚·‚é•Ï”
    public float speed = 1f;  // ƒIƒuƒWƒFƒNƒg‚ÌˆÚ“®‘¬“x‚ğİ’è
    public GameObject Pivot;
    public GameObject Generator;


    void Start()
    {

    }

    private void Update()
    {
        float distance = Vector3.Distance(Pivot.transform.position, Generator.transform.position);

        Debug.Log("Distance between objects: " + distance);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ƒIƒuƒWƒFƒNƒg‚ÌˆÊ’u‚ÉƒvƒŒƒnƒu‚ğoŒ»‚³‚¹‚é
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
        }

        if (distance > 0.05)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // ƒIƒuƒWƒFƒNƒg‚ğZ²•ûŒü‚Éˆê’è‘¬“x‚ÅˆÚ“®‚³‚¹‚é
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            // ƒIƒuƒWƒFƒNƒg‚ğZ²•ûŒü‚Éˆê’è‘¬“x‚ÅˆÚ“®‚³‚¹‚é
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

    }
=======
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;  // ï¿½oï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½vï¿½ï¿½ï¿½nï¿½uï¿½ï¿½ï¿½wï¿½è‚·ï¿½ï¿½Ïï¿½
    GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ï¿½Iï¿½uï¿½Wï¿½Fï¿½Nï¿½gï¿½ÌˆÊ’uï¿½Éƒvï¿½ï¿½ï¿½nï¿½uï¿½ï¿½ï¿½oï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            gameController.AddScore();
        }
    }
>>>>>>> kouta_donut_ignoretest
}