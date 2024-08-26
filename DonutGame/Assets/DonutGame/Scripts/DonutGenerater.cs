using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;  // 出現させるプレハブを指定する変数

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // オブジェクトの位置にプレハブを出現させる
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
        }
    }
}