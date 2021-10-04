using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerController : MonoBehaviour
{
    private Rigidbody _rb = null;
    [SerializeField] private Transform target = null;
    [SerializeField] private Animator playerAnimator = null;

    public float speed = 10f;
    public float jumpForce = 4f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal2");
        float z = -Input.GetAxis("Vertical2");

        Vector3 move = Vector3.forward * z + Vector3.right * x;

        _rb.AddForce(move * speed, ForceMode.Force);
        transform.LookAt(target);

        if (x != 0f || z != 0f)
            playerAnimator.SetBool("Run", true);
        else
            playerAnimator.SetBool("Run", false);
    }
}
