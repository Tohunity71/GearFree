using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public Transform FirePoint;
    private GameObject BulletPrefab;
    public Transform Player; 
    GameObject prefab;
    Rigidbody2D BulletRB;

    // Update is called once per frame
    void Start()
    {
      prefab = Resources.Load("Bullet") as GameObject;
        //BulletRB = GetComponent<Rigidbody2D>;  
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            BulletPrefab = Instantiate(prefab) as GameObject;
            BulletPrefab.transform.position = new Vector3(transform.position.x + .4f, transform.position.y, -1);
            Rigidbody2D BulletShoot = BulletPrefab.GetComponent<Rigidbody2D>();
            BulletShoot.velocity = new Vector2(30, 0);
           
        }
    }

        void shoot() {
        
    
    }

}
