using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObjectTurning : MonoBehaviour
{
    public GameObject OtherGear;

    // Update is called once per frame
    void Update()
    {
        OtherGear.transform.position = new Vector3(OtherGear.transform.position.x, OtherGear.transform.position.y + (RotationMouse.currentRotation * 0.05f), 0);
        //OtherGear.transform.position = new Vector3(0, RotationMouseTest.angle * 0.05f, 0);
        //OtherGear.transform.eulerAngles = new Vector3(0, 0, Test2RotationMouse.currentRotation * 0.5f);
    }


}
