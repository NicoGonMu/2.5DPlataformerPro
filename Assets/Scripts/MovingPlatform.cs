using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 _beginPosition;
    private Vector3 _endPosition = new Vector3(25.83586f, 1.062335f , 0);
    private float _speed = 10f;
    private bool _goToEnd = true;

    // Start is called before the first frame update
    void Start()
    {
        _beginPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_goToEnd) {
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed * Time.deltaTime);
            if (transform.position == _endPosition)
            {
                _goToEnd = false;
            }
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, _beginPosition, _speed * Time.deltaTime);
            if (transform.position == _beginPosition)
            {
                _goToEnd = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("xD");
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
