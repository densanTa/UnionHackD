using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;  // �o��������v���n�u���w�肷��ϐ�
    GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �I�u�W�F�N�g�̈ʒu�Ƀv���n�u���o��������
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            gameController.AddScore();
        }
    }
}