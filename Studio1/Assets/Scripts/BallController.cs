using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool isInContact = false;
    public float ballSpeed = 2f;
    public Rigidbody sphereRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        isInContact = true;
    }
    void OnCollisionStay(Collision collision){
        isInContact = true;
    }
    void OnCollisionExit(Collision collision){
        isInContact = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector3 = Vector3.zero;
        Vector2 inputVector = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        if(Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }

        if(Input.GetKey(KeyCode.Space)&&(isInContact))
        {
            inputVector3 += new Vector3(0, 0, 5);
        }

        Vector3 inputXZPlane = new Vector3(inputVector.x, inputVector3.z, inputVector.y);
        sphereRigidbody.AddForce(inputXZPlane);

    
        Debug.Log("Resultant Vector: " + inputVector*ballSpeed);

    }
}
