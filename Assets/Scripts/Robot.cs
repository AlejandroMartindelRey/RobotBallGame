using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Robot : RobotFreeAnim
{
    
    [SerializeField] int movementForce = 4;
    [SerializeField] float rollingForce = 12;

    private Light vision;
    public bool ceiling = false;
    private CapsuleCollider capsule;
    private SphereCollider sphere;
  
    private Rigidbody  rb;
    bool rolling = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vision = GetComponent<Light>();
        sphere = GetComponent<SphereCollider>();
        capsule = GetComponent<CapsuleCollider>();
        rb =  GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (startUp)
        {
            StartUpTimer();
        }
        
        if (startUp != true)
        {
            if (Input.GetKeyDown(KeyCode.Space) &&  walking != true && ceiling != true)
            {
                vision.enabled = !vision.enabled;
                capsule.enabled = !capsule.enabled; 
                sphere.enabled = !sphere.enabled;
                rolling = !rolling;
                time = 0;
            } 
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            rolling = false;
            time = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startUp != true)
        {
            if (Input.GetKey(KeyCode.W) && rolling != true)
            {
                rb.AddForce(transform.forward * movementForce , ForceMode.Impulse);
                walking = true;
            }
            else if (walking)
            {
                walking = false;
                ceiling = false;
            }
            
            if (rolling)
            {
                if (Physics.Raycast(transform.position, Vector3.up, transform.localScale.y * 0.5f))
                {
                    ceiling = true;
                }
                else
                {
                    ceiling = false;
                }

                
                if (Input.GetKey(KeyCode.W))
                {
                    walking = true;
                }
                else if (walking)
                {   
                    walking = false;
                }
                
                
                time += Time.deltaTime;
                if (time >= 2)
                {
                    rb.AddForce(transform.forward * rollingForce, ForceMode.Impulse); 
                }
           
            }
            
           
        }
    }
    
}
