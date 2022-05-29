using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{ 
    float rotY;

    public Sprite Icon;
    public string Name;
    void FixedUpdate()
    {
        rotY -= .75f;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            //other.gameObject.GetComponentInChildren<Inventory>.inventory.
        }
    }
}
