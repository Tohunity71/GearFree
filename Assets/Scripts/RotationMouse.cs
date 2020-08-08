using UnityEngine;
using System.Collections;

public class RotationMouse : MonoBehaviour
{
    public static float deltaRotation;
    public float deltaLimit;
    public float deltaReduce;
    float previousRotation;
    public static float currentRotation;

    public bool isTouchingObject = false;
    private bool isRotatingObject = false;

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && isTouchingObject == true && this.gameObject.tag == "Gear")
        {
            isRotatingObject = true;
            deltaRotation = 0f;
            previousRotation = angleBetweenPoints(this.gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)); //vorige rotatie is de graden dat ie nu is. 
        }
        else if (Input.GetMouseButton(0) && isTouchingObject == true && this.gameObject.tag == "Gear")
        {
            isRotatingObject = true;
            currentRotation = angleBetweenPoints(this.gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)); // De graden waar hij naartoe gaat nadat je hebt gesleept
            deltaRotation = Mathf.DeltaAngle(currentRotation, previousRotation); // hij berekent de kleinste angle
            if (Mathf.Abs(deltaRotation) > deltaLimit) // hier check je of je deltarotatie je limit overschfijt (kan ik doen in inspector) 
            {
                deltaRotation = deltaLimit * Mathf.Sign(deltaRotation); // sign checked of het positive of negatief is (1 en -1) dan weet ie welke kant je op moet draaien
            }
            previousRotation = currentRotation; // zet vorige roatie waarde naar de nieuwe rotatie waarde
            this.gameObject.transform.Rotate(Vector3.back * Time.deltaTime, deltaRotation); // Transformeerd de rotatie van eht object naar de delta rotatie (Die hij al heeft berekent) 
        }
        else
        {
            isRotatingObject = false; 
            this.gameObject.transform.Rotate(Vector3.back * Time.deltaTime, deltaRotation); // Als ik de knop niet druk dan Misshcien niet snapped?! 
            deltaRotation = Mathf.Lerp(deltaRotation, 0, deltaReduce * Time.deltaTime); // het object draait langzaam door als ik niet meer de muisknop heb ingedrukt 
        }

        if (Input.GetMouseButtonUp(0) && this.gameObject.tag == "Gear")
        {
            isRotatingObject = false;
        }

        //Deze had ik zelf toegevoegd om te kijken wat het deed
        Debug.Log("dgrees" + Mathf.DeltaAngle(1000, 90));
        Debug.Log("abs " + Mathf.Abs(10));
        Debug.Log("sign" + Mathf.Sign(-20));
        Debug.Log("sign" + Mathf.Sign(33));
        Debug.Log("rotate is" + isRotatingObject + gameObject.name);

    }

    float angleBetweenPoints(Vector2 Object_position, Vector2 Mouse_position)
    {
        Vector2 fromLine = Mouse_position - Object_position; // berekent de de afstand tussen positie van objec en muis positie
        Vector2 toLine = new Vector2(1, 0); // maakt hij een kleine lijn om de oek te berekenen

        float angle = Vector2.Angle(fromLine, toLine); //berekent de graden van de hoek tussen fromlin en toline.

        Vector3 cross = Vector3.Cross(fromLine, toLine); // Checked hij of je een rondje hebt gemaakt of niet. 

        // did we wrap around? maakt hij een circle. 
        if (cross.z > 0)
        {
            angle = 360f - angle;
        }

        return angle; //stuurt angle waarde terug naar functie. 
    }

    // Makes it so you  have to touch the object first to use the code. 
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