using UnityEngine;

public class Robot : MonoBehaviour
{
    
    [SerializeField] private int movementForce = 4;
    private Rigidbody  rb;
    private bool _ballmode = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _ballmode = !_ballmode;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * movementForce , ForceMode.Impulse);
        }
           

    }
    
}
