using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; //stores offset value 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Late Update is called once per frame vut after all of the other updates
    void LateUpdate()
    {
        //added late so camera position won't be set untill the player has moved for that frame
        transform.position = player.transform.position + offset;
    }
}
