using UnityEngine;
using System.Collections;

public class RotationMouseTest : MonoBehaviour
{

    private Camera myCam;
    private Vector3 screenPos;
    public static float angleOffset;
    public static float angle;
    public static float newAngle;
    private bool isTouchingObject = false;
    private bool isRotatingObject = false;

    void Start()
    {
       myCam = Camera.main;       
    }

    void Update()
    {
        //This fires only on the frame the button is clicked
        if (Input.GetMouseButtonDown(0) && isTouchingObject == true && GameObject.FindWithTag("Gear"))
        {
            isRotatingObject = true;
            screenPos = myCam.WorldToScreenPoint(transform.position);
            Vector3 v3 = Input.mousePosition - screenPos;
            angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(v3.y, v3.x)) * Mathf.Rad2Deg;
            //angleOffset = (Mathf.Atan2(transform.eulerAngles.y, transform.eulerAngles.x) - Mathf.Atan2(v3.y, v3.x)) * Mathf.Rad2Deg;
        }

        //This fires while the button is pressed down
        if (Input.GetMouseButton(0) && isTouchingObject == true && GameObject.FindWithTag("Gear"))
        {
            isRotatingObject = true;
            Vector3 v3 = Input.mousePosition - screenPos;
            angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
        }
        
        if(Input.GetMouseButtonUp(0) && GameObject.FindWithTag("Gear"))
        {
            isRotatingObject = false;
        }

        newAngle = angle + angleOffset;
        //Debug.Log("Is touching Object" + isTouchingObject);
        Debug.Log("rotate is"+ isRotatingObject);
    }

    void OnMouseEnter()
    {
        isTouchingObject = true;
        print(gameObject.name);
    }

    private void OnMouseDrag()
    {
        isTouchingObject = true;
    }

    private void OnMouseExit()
    {
        isTouchingObject = false;
    }

    private void OnMouseUp()
    {
        isTouchingObject = false;       
    }

    
}