using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]  Color32 hasPackageColor = new Color32(1,1,1,255);
    [SerializeField]  Color32 noPackageColor = new Color32(1, 1, 1, 255);
    [SerializeField]  float destroyDelay = 0.5f;

    bool hasPackage = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("player hit game object");
    }

     void OnTriggerEnter2D(Collider2D other)
     {
         if (other.tag=="Package" && !hasPackage)
         {
             hasPackage = true;
             Debug.Log("package picked up ");
             Destroy(other.gameObject, destroyDelay);
             spriteRenderer.color = hasPackageColor;
         }

         if (other.tag == "Customer" && hasPackage)
         {
             hasPackage = false;
             Debug.Log("package delivered");
             spriteRenderer.color = noPackageColor;
        }

     }
}
