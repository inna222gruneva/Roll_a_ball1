using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   //removed start

    // Update is called once per frame
    void Update()
    {
        //for the cube to spin rotation values should be rotating
        //at every frame
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
        //this action needs to be smooth and frame rate independent 
        //deltaTime ensures actions happen smoothly 
        //it dinmically changes its value depending on the
        //legth of the frame

    }
}
