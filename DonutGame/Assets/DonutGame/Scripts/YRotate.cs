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
        // y²‚ğ’†S‚É•¨—‰‰Z‚ğg‚Á‚Ä‰ñ“]‚³‚¹‚é
        rb.angularVelocity = new Vector3(0, rotationSpeed * Mathf.Deg2Rad, 0);
    }
}

