using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPush : MonoBehaviour
{
    private Rigidbody _rb = null;

    [Header("Push Parameters")]
    [SerializeField] private float _pushXForce = 0f;
    [SerializeField] private float _pushYForce = 0f;
    [SerializeField] private Vector3 _pushBoxDimension = Vector3.zero;
    [SerializeField] private float _cooldown = 2f;
    private float _timer = 0f;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && _timer <= 0f)
        {
            PushSkill();
            _timer = _cooldown;
        }
    }

    public void PushSkill()
    {
        Vector3 center = transform.forward * (_pushBoxDimension.x / 2f) + transform.position;
        Collider[] colliders = Physics.OverlapBox(center, _pushBoxDimension / 2f);

        foreach (Collider pushedObject in colliders)
        {
            Rigidbody hittedMvtController = pushedObject.GetComponent<Rigidbody>();
            if (hittedMvtController != null && hittedMvtController.name != _rb.name)
            {
                pushedObject.GetComponent<Rigidbody>().AddForce(transform.forward * _pushXForce + transform.up * _pushYForce, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Color color = Color.blue;
        color.a = 0.2f;
        Gizmos.color = color;
        Gizmos.DrawCube(transform.forward * (_pushBoxDimension.x / 2f) + transform.position, _pushBoxDimension);
    }
}
