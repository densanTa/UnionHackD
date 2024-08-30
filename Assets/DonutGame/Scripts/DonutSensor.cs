using UnityEngine;

public class DonutSensor : MonoBehaviour
{
    private bool isInside = false;

    private void OnTriggerStay(Collider other)
    {
        // タグやレイヤーなどで特定の物体のみを検出したい場合は、
        // ここで条件を追加してください
        isInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }

    private void Update()
    {

    }
}