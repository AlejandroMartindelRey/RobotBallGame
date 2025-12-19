using UnityEngine;

public class BatteryMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 0.01f;
    private float amplitude = 0.01f;
    [SerializeField] private AudioClip coinSound;
    private Vector3 basePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basePosition = transform.localPosition;
    }

    void Update()
    {
        transform.eulerAngles+=new Vector3(0,1,0);
        float y = Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = basePosition + new Vector3(0, y, 0);
    }
}
