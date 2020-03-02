using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
//Make an empty GameObject and call it "Door"
//Drag and drop your Door model into Scene and rename it to "Body"
//Move the "Body" Object inside "Door"
//Add a Collider (preferably SphereCollider) to "Door" Object and make it much bigger then the "Body" model, mark it as Trigger
//Assign this script to a "Door" Object (the one with a Trigger Collider)
//Make sure the main Character is tagged "Player"
//Upon walking into trigger area the door should Open automatically

    // Sliding door
    public enum OpenDirection { x, y, z }
    public OpenDirection direction = OpenDirection.y;
    public float openDistance = 3f; //How far should door slide (change direction by entering either a positive or a negative value)
    public float openSpeed = 2.0f; //Increasing this value will make the door open faster
    public Transform doorBody; //Door body Transform
    public GameObject doorLeft;
    public GameObject doorRight;

    bool open = false;

    Vector3 defaultDoorPosition;
    Vector3 defaultLeftPosition;
    Vector3 defaultRightPosition;


    void Start()
    {
        if (doorBody)
        {
            defaultDoorPosition = doorBody.localPosition;
            defaultLeftPosition = doorLeft.transform.position;
            defaultRightPosition = doorRight.transform.position;

        }
    }

    // Main function
    void Update()
    {
        //if (!doorBody)
        //    return;

        //if (direction == OpenDirection.x)
        //{
        //    doorLeft.transform.position = new Vector3(2 + (open ? openDistance : 0) * Time.deltaTime * openSpeed, 0, 0 );
        //    doorRight.transform.position = new Vector3(-2 + (open ? openDistance : 0) * Time.deltaTime * openSpeed, 0, 0);
        //}
        //else if (direction == OpenDirection.y)
        //{
        //    doorBody.localPosition = new Vector3(doorBody.localPosition.x, Mathf.Lerp(doorBody.localPosition.y, defaultDoorPosition.y + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.z);
        //}
        //else if (direction == OpenDirection.z)
        //{
        //    doorBody.localPosition = new Vector3(doorBody.localPosition.x, doorBody.localPosition.y, Mathf.Lerp(doorBody.localPosition.z, defaultDoorPosition.z + (open ? openDistance : 0), Time.deltaTime * openSpeed));
        //}
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLeft.SetActive(false);
            doorBody.gameObject.SetActive(false);
            doorLeft.transform.position = new Vector3(2 + (open ? openDistance : 0) * Time.deltaTime * openSpeed, 0, 0);
            doorRight.transform.position = new Vector3(-2 + (open ? openDistance : 0) * Time.deltaTime * openSpeed, 0, 0);
            open = true;

        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false;
        }
    }
}
