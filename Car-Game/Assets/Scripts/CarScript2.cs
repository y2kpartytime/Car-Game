using UnityEngine;
using UnityEngine.Animations;

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




        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));


        transform.position = carRB.transform.position;
    }


    private void FixedUpdate()
    {
        if (Mathf.Abs(speedInput) > 0)
        {
            carRB.AddForce(transform.forward * speedInput);
        }

    }



}
