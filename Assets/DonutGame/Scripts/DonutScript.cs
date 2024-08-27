using UnityEngine;

public class CheckYPosition : MonoBehaviour
{
    void Update()
    {
        // オブジェクトのy座標が0を下回ったときにtrueを返す
        if (transform.position.y < -2)
        {
            Destroy(this.gameObject);

            Debug.Log("GameOver!!!!!");
        }
    }
}
