using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float speed = 20;
    GroundDetector_Raycast ground;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<GroundDetector_Raycast>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * Time.deltaTime * speed, 0);
        anim.SetBool("grounded", ground.grounded);
        anim.SetBool("moving", horizontal != 0);
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
