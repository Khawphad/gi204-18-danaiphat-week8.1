using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<gravity> gravityObjectList;
    [SerializeField] bool planets = false;
    [SerializeField] int orbetSpeed = 500;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if(gravityObjectList == null)
        {
            gravityObjectList = new List<gravity>();
        }
        gravityObjectList.Add(this);
        if (!planets);
        {
            rb.AddForce(Vector3.left * orbetSpeed);
        }
    }
    private void FixedUpdate()
    {
        foreach (var obj in gravityObjectList)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }
    void Attract(gravity other) 
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance,2));
        Vector3 finalForce = forceMagnitude * direction.normalized;
        otherRb.AddForce(finalForce);
    }
}
