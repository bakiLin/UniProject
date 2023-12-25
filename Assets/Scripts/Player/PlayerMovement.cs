using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody _rb;
    private float _horSpeed, _vertSpeed;
    private bool _hor = false, _vert = false;
    private Vector3 move;
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        int temp = SceneManager.GetActiveScene().buildIndex;

        if (temp == 1 || temp == 3)
        {
            if (PlayerPrefs.GetInt("firstSpawn") == 1)
                _animator.SetTrigger("RoomEnter");
        }
        else
            _animator.ResetTrigger("RoomEnter");
    }

    private void Update()
    {
        _vertSpeed = Input.GetAxisRaw("Vertical");
        _horSpeed = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(_vertSpeed) == 1 && _horSpeed == 0) _vert = true;
        if (Mathf.Abs(_horSpeed) == 1 && _vertSpeed == 0) _hor = true;

        if (_vert == true && _vertSpeed == 0) _vert = false;
        if (_hor == true && _horSpeed == 0) _hor = false;

        if (_vert) _horSpeed = 0f;
        if (_hor) _vertSpeed = 0f;

        AnimationController();

        move = new Vector3(_vertSpeed, 0f, -_horSpeed);
    }

    private void AnimationController()
    {
        if (_vertSpeed == -1f)
        {
            CleanAnimation();
            _animator.SetBool("WalkForward", true);
        }

        if (_vertSpeed == 1f)
        {
            CleanAnimation();
            _animator.SetBool("WalkBack", true);
        }

        if (_horSpeed == 1f)
        {
            CleanAnimation();
            _animator.SetBool("WalkRight", true);
        }

        if (_horSpeed == -1f)
        {
            CleanAnimation();
            _animator.SetBool("WalkLeft", true);
        }

        if (_vertSpeed == 0 && _horSpeed == 0) CleanAnimation();
    }

    private void CleanAnimation()
    {
        _animator.SetBool("WalkBack", false);
        _animator.SetBool("WalkRight", false);
        _animator.SetBool("WalkLeft", false);
        _animator.SetBool("WalkForward", false);
    }

    private void FixedUpdate()
    {
        _rb.velocity = move * Time.fixedDeltaTime * _moveSpeed;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("level1exit", 0);
    }
}
