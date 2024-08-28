
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRotate : MonoBehaviour
{
    public float rotationSpeed = 20f; // ��]���x���w��i�x/�b�j
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

    }
}

