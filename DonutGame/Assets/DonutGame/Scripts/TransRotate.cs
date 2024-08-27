using UnityEngine;

public class TransRotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度を指定（度/秒）

    void Update()
    {
        // y軸を中心に回転させる
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}