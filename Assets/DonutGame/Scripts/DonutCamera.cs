using UnityEngine;
using System.Collections;

public class DonutCamera : MonoBehaviour
{
    private Rigidbody rb;
    private bool isInsideTrigger = false;
    public float velocityThreshold = 0.01f; // 速度のしきい値
    public string triggerTag = "Sensor"; // トリガー領域のタグ
    GameObject pivot;
    private bool canExecute = true; // 実行可能フラグ

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbodyが見つかりません。このスクリプトを使用するにはRigidbodyが必要です。");
        }
        pivot = GameObject.Find("CenterPivot");
    }

    private void Update()
    {
        if (IsInsideAndStationary() && canExecute)
        {
            ExecuteAction();
            StartCoroutine(CooldownCoroutine());
        }
    }

    private void ExecuteAction()
    {
        Debug.Log("オブジェクトが指定領域内にあり、静止しています！");
        Debug.Log("もともとの高さ：" + pivot.transform.position);
        pivot.transform.position = new Vector3(pivot.transform.position.x, pivot.transform.position.y + 0.2f, pivot.transform.position.z);
        Debug.Log("Lifted Up!!!");
    }

    private IEnumerator CooldownCoroutine()
    {
        canExecute = false;
        yield return new WaitForSeconds(1f);
        canExecute = true;
    }

    private bool IsInsideAndStationary()
    {
        return isInsideTrigger && rb != null && rb.velocity.magnitude <= velocityThreshold;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            isInsideTrigger = false;
        }
    }
}