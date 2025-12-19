using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject door;

    public void OpenDoor()
    {
        Destroy(door);
    }
}
