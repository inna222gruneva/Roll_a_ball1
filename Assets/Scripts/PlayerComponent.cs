 using UnityEngine;
using UnityEngine.InputSystem; //added this to aces unity unput system
using TMPro; //aded this to use canvas



public class PlayerComponent : MonoBehaviour
{
    public float speed = 0; //since it's public can see in inspectors

    public TextMeshProUGUI countText; //refference to UO text component
    public GameObject winTextObject;
    private bool isGround;
    
    private bool d_jump;
    private int jump;
    
    private Rigidbody rb; //hols refference to rigidbody we need to acess
    private int count;
    private float movementX;
    private float movementY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //called on the first frame
        count = 0;
        rb = GetComponent<Rigidbody>(); 
        isGround = true;
        jump = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }
    
    void OnMove(InputValue movementValue) //adding user input as its parameters
    //InputValue is a type of value
    {
        //Function body
        //gets vector2 values from the player input 
        Vector2 movementVector = movementValue.Get<Vector2>();  
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 11)
        {
            winTextObject.SetActive(true);

        }

    }

    void FixedUpdate() //called when rb is used?
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //f is for the float
        rb.AddForce(movement * speed); //force we apply on the object * speed
        //ball is going to move along x and z 
        
        
    }
    void Update()
    {
        if(isGround == true && !Input.GetKeyDown(KeyCode.Space))
        {
            d_jump = false;

        }
        //not sure if that one here or in void update
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGround == true || d_jump == true)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5, rb.linearVelocity.z);
                //jump = jump + 1;
                isGround = false;
                d_jump = !d_jump;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            /*if (jump == 1){
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5, rb.linearVelocity.z);
            }*/
            jump = 0;
            //trying to make it jump again(double jump)
            //rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
           

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            //disable game object on collission
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }



    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
