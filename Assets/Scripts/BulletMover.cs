using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        transform.Rotate(90, 0, 0);
        rb.velocity = transform.up * speed;
	}
}