using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float speed;
	public float tumble;
	private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -1 * Vector3.forward * speed;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
