using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;

    [SerializeField]
    private float _speed = 19f;
    [SerializeField]
    private float _jumpSpeed = 2f;
    [SerializeField]
    private float _gravity = 1f;
    [SerializeField]
    private float _jumpHeight = 19f;
    private float _yLastValue;
    private bool _doubleJumpAvailable = false;
    [SerializeField]
    private int _coins = 0;
    [SerializeField]
    private int _lives = 3;
    private UIManager _uiManager;
    private Vector3 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.UpdateLivesText(_lives);
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -7)
        {
            _uiManager.UpdateLivesText(--_lives);
            if (_lives == 0)
            {
                Destroy(this);
            }
            transform.SetPositionAndRotation(_initialPosition, new Quaternion());
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0) * _speed;

        if (_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _yLastValue = _jumpHeight;
            _doubleJumpAvailable = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _doubleJumpAvailable)
        {
            _yLastValue = _jumpHeight;
            _doubleJumpAvailable = false;
        } else 
        {
            _yLastValue -= _gravity;
        }

        direction.y = _yLastValue;
        _controller.Move(direction * Time.deltaTime);
    }

    public void AddCoins()
    {
        _uiManager.UpdateCoinText(++_coins);
    }
}
