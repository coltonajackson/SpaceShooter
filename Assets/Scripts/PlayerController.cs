using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float tilt;
    public float timer;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float nextFire;
    private float fireRate;

    private Controller controller;
    private Vector3 offset;

    public GameObject leapMotion;
    private int countah;
    private float moveLeftAndRight;

    void Start()
    {
        moveLeftAndRight = 0;
        controller = new Controller();
    }

    void FixedUpdate()
    {
        // no longer needing these, we are moving on!!
        //float moveLeftAndRight = Input.GetAxis("Horizontal");
        //float moveUpAndDown = Input.GetAxis("Vertical");
        DirectShooter();
        Shoot();
    }
    
    void DirectShooter()
    {
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;
        float handPalmPitch = 0;
        float handPalmRoll = 0;
        float handPalmYaw = 0;
        float handWristRot = 0;
        if (frame.Hands.Count > 0)
        {
            Hand firstHand = hands[0];
            handPalmPitch = hands[0].PalmNormal.Pitch;
            handPalmRoll = hands[0].PalmNormal.Roll;
            handPalmYaw = hands[0].PalmNormal.Yaw;
            handWristRot = hands[0].WristPosition.Pitch;
            if (countah >= timer)
            {
                if (SceneManager.GetActiveScene().name != "MainMenu")
                {
                    leapMotion.SetActive(false);
                }
            }
            countah++;
        }
        else
        {
            leapMotion.SetActive(true);
            countah = 0;
        }

        // To move the object left and right
        if (moveLeftAndRight >= -0.5 && moveLeftAndRight <= 0.5)
        {
            if (handPalmRoll <= -0.25 && handPalmRoll >= -1.5)
            {
                moveLeftAndRight += 0.01f;
            }
            else if (handPalmRoll >= 0.25 && handPalmRoll <= 1.5)
            {
                moveLeftAndRight -= 0.01f;
            }
            else if ((handPalmRoll < 0.5 && handPalmRoll > -0.5))
            {
                if (moveLeftAndRight > 0.01)
                {
                    moveLeftAndRight -= 0.01f;
                }
                else if (moveLeftAndRight < -0.01)
                {
                    moveLeftAndRight += 0.01f;
                }
                else 
                {
                    moveLeftAndRight = 0f;
                }
            }
        }
        else
        {
            if (moveLeftAndRight > 0.5)
            {
                moveLeftAndRight -= 0.01f;
            }
            else if (moveLeftAndRight < -0.5)
            {
                moveLeftAndRight += 0.01f;
            }
        }

        //Debug.Log("MoveLeftAndRight: " + moveLeftAndRight);
        //Debug.Log("VelocityX: " + GetComponent<Rigidbody>().velocity);
        //Debug.Log("Pitch: " + handPalmPitch);
        //Debug.Log("Roll: " + handPalmRoll);
        //Debug.Log("MoveLeftAndRight: " + moveLeftAndRight);
        //Debug.Log("Yaw: " + handPalmYaw);
        //Debug.Log("Rot: " + handWristRot);

        Vector3 movement = new Vector3(moveLeftAndRight, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            0.0f
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

    }

    void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && countah % 5 == 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
    
}
