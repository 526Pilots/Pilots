using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover1 : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(0, 0, 30));
        rb.velocity = transform.up * speed;
	}
}
