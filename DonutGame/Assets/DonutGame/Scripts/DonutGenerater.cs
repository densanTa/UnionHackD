using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;  // 出現させるプレハブを指定する変数
    public float speed = 1f;  // オブジェクトの移動速度を設定
    public GameObject Pivot;
    public GameObject Generator;
    public TypingManager typingManager;

    void Start()
    {
        if (typingManager == null)
        {
            typingManager = FindObjectOfType<TypingManager>();
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(Pivot.transform.position, Generator.transform.position);

        Debug.Log("Distance between objects: " + distance);

        if (typingManager.CorrectCount > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            // オブジェクトの位置にプレハブを出現させる
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation);

            // 新しく生成されたオブジェクトから SpawnPrefab スクリプトを削除する
            SpawnPrefab spawnedScript = spawnedObject.GetComponent<SpawnPrefab>();
            if (spawnedScript != null)
            {
                Destroy(spawnedScript);  // スクリプトを削除
            }

            // 正解数を1つ減らし、表示を更新
            typingManager.CorrectCount--;
            typingManager.UpdateCorrectCount();
        }

        if (distance > 0.05)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // オブジェクトをZ軸方向に一定速度で移動させる
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            // オブジェクトをZ軸方向に一定速度で移動させる
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

    }
}