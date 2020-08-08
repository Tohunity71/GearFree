using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMouseV1 : MonoBehaviour
{
    private Vector3 screenPos;
    private float angleOffset;

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;


    private void Update()
    {

        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Quaternion rotation = Quaternion.Euler(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            //Vector3 mousePos;
            //screenPos = Camera.main.ScreenToWorldPoint(transform.position);
            //mousePos = Input.mousePosition - screenPos;
            //angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(mousePos.y, mousePos.x)) * Mathf.Rad2Deg;
            //Quaternion rotation = Quaternion.Euler(mousePos.x - startPosX, mousePos.y - startPosY, 0);         
            //this.gameObject.transform.rotation = rotation;


        }

        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition - transform.position);

        //    difference.Normalize();

        //    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //    transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        //}

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;

        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false; 
    }
}
