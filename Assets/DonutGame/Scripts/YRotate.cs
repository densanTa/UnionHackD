<<<<<<< HEAD
using UnityEngine;

public class Yrotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // ‰ñ“]‘¬“x

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // yŽ²‚ð’†S‚É•¨—‰‰ŽZ‚ðŽg‚Á‚Ä‰ñ“]‚³‚¹‚é
        rb.angularVelocity = new Vector3(0, rotationSpeed * Mathf.Deg2Rad, 0);
    }
}

=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRotate : MonoBehaviour
{
    public float rotationSpeed = 20f; // ‰ñ“]‘¬“x‚ðŽw’èi“x/•bj
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
>>>>>>> kouta_donut_ignoretest
