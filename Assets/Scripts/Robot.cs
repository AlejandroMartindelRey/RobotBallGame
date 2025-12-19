using UnityEngine;

public class Robot : RobotFreeAnim
{
    
    [SerializeField] private int movementForce = 4;
    [SerializeField] private int rollingForce = 12;

    private CapsuleCollider capsule;
    private SphereCollider sphere;
    private bool startUp = true;
    private float time;
    private Rigidbody  rb;
    bool rolling = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.Space) &&  walking != true)
            {
                capsule.enabled = !capsule.enabled;
                sphere.enabled = !sphere.enabled;
                rolling = !rolling;
                time = 0;
            } 
        }
    }

    void StartUpTimer()
    {
        time += Time.deltaTime;
        if (time >= 3.5)
        {
            time = 0;
            startUp = false;
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
            }
            
            if (rolling)
            {
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
