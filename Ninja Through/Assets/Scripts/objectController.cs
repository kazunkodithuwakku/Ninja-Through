using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectController : MonoBehaviour {

    private bool flag = false;    
    private Vector3 endPoint;  
    public float duration = 10.0f;

    private bool isObjectTouch = false;

    void OnMouseDown()
    {
        if (!isObjectTouch)
        {
            isObjectTouch = true;
            gameObject.tag = "selected";
        }
        else
        {
            isObjectTouch = false;
            gameObject.tag = "box";
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        touchOnObject();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "selected")
        {
            Destroy(gameObject);
        }
    }

    void touchOnObject()
    {


        if (isObjectTouch)
        {
            //check if the screen is touched / clicked   
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
            {
                //declare a variable of RaycastHit struct
                RaycastHit hit;
                //Create a Ray on the tapped / clicked position
                Ray ray;
                //for unity editor
                #if UNITY_EDITOR
                                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                //for touch device
                #elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
                                                                               ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                #endif

                //Check if the ray hits any collider
                if (Physics.Raycast(ray, out hit))
                {
                    //set a flag to indicate to move the gameobject
                    flag = true;
                    //save the click / tap position
                    endPoint = hit.point;
                }

            }
            //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
            if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
            { //&& !(V3Equal(transform.position, endPoint))){
                //move the gameobject to the desired position
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance(gameObject.transform.position, endPoint))));
            }
            //set the movement indicator flag to false if the endPoint and current gameobject position are equal
            else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
            {
                flag = false;
            }
        }

    }
}
