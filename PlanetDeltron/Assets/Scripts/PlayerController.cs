using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text distanceRan;
    Animator playerAnim;
    float distanceUnit;
    private bool turnLeft, turnRight, jump, slide;
    public float speed = 1.0f;
    private CharacterController myCharacterController;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        myCharacterController = GetComponent<CharacterController>();
        InvokeRepeating("distance", 0, 1 / speed);
    }

    // Update is called once per frame
    void Update()
    {
        turnLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        turnRight = Input.GetKeyDown(KeyCode.RightArrow);
        jump = Input.GetKeyDown(KeyCode.UpArrow);
        slide = Input.GetKeyDown(KeyCode.DownArrow);

        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));
        else if (jump)
            playerAnim.SetTrigger("Jump_Trig");
        else if (slide)
            playerAnim.SetTrigger("Slide_Trig");


            myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }

    void distance()
    {
        distanceUnit++;
        distanceRan.SetText("Score: " + distanceUnit.ToString());
    }
}
