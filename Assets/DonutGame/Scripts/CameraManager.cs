using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 移動させたいベクトルを指定します
    public Vector3 moveDirection = new Vector3(0f, 0.1f, -1f); // 例: z方向に1単位移動
    public float moveDistance = 0.3f; // 移動距離
    public Transform AimDonutpos;

    private void Start()
    {
        if (AimDonutpos == null)
        {
            AimDonutpos = GameObject.Find("AimDonut").transform;
            Debug.Log("Start");
        }
    }

    void Update()
    {

        AimDonutpos.position = new Vector3(AimDonutpos.position.x, transform.position.y * 0.75f, AimDonutpos.position.z);
        // スペースキーが押されたとき
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CameraMove();
            Debug.Log(AimDonutpos.position);
        }

    }

    public void CameraMove()
    {
        // オブジェクトをローカル座標系で移動させます
        transform.Translate(moveDirection.normalized * moveDistance, Space.Self);
        Debug.Log("移動!");
    }
}
