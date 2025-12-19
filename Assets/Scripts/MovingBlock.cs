using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float changeDirectionTime;
    private float timer;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
        rb.linearVelocity = movementDirection * movementSpeed;
    }

    private void ChangeDirection()
    {
        timer += Time.deltaTime;
        if (changeDirectionTime <= timer)
        {
            movementDirection = -movementDirection;
            timer = 0;
        }
    }
}
