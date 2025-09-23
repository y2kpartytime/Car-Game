using Unity.VisualScripting;
using UnityEngine;

public class CarScript2 : MonoBehaviour
{

    public Rigidbody carRB;
    public float forwardAccel = 10f, reverseAccel = 7f, maxSpeed = 50f, turnStrength = 180f;

    private float speedInput, turnInput;

    void Start()
    {
        
    }

    void Update()
    {
        speedInput = 0;

        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000;
        }


        turnInput = Input.GetAxis("Horizontal");

        


       //old code
       //transform.position = carRB.transform.position;

    }


    private void FixedUpdate()
    {
        if (Mathf.Abs(speedInput) > 0)
        {
            carRB.AddForce(transform.forward * speedInput);
        }


        // rotates car rigidbody using quaternion
        if (Mathf.Abs(turnInput) > 0)
        {
            carRB.MoveRotation(carRB.rotation * Quaternion.Euler(0f, turnInput * turnStrength * Time.fixedDeltaTime, 0f));
        }

    }

}
