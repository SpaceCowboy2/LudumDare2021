using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private Rigidbody _rb = null;
    private PlayerController _playerController = null;

    [Header("Push Parameters")]
    [SerializeField] private float _pushForce = 0f;
    [SerializeField] private Vector3 _pushBoxDimension = Vector3.zero;
    [SerializeField] private float _cooldown = 2f;
    private float _timer = 0f;

    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && _timer <= 0f)
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
            PlayerController hittedMvtController = pushedObject.GetComponent<PlayerController>();
            if (hittedMvtController != null && hittedMvtController.name != _playerController.name)
            {
                pushedObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * _pushForce, ForceMode.Impulse);
                _rb.AddForce(Vector3.back * (_pushForce / 2f), ForceMode.Impulse);
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