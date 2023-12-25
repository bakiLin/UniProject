using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseDoor : MonoBehaviour
{
    private Animator _anim;
    private bool _playerEnter;

    public Animator text;
    public bool isFading = false;
    public int sceneID = 1;

    private void Start()
    {
        if (isFading)
        {
            GameObject door = transform.parent.gameObject;
            _anim = door.GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerEnter = true;

            if (isFading) _anim.SetBool("playerEnter", true);

            text.SetBool("PlayerEnter", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerEnter = false;

            if (isFading)  _anim.SetBool("playerEnter", false);
            text.SetBool("PlayerEnter", false);
        }
    }

    private void Update()
    {
        if (_playerEnter)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                PlayerPrefs.SetInt("firstSpawn", 1);

                if (SceneManager.GetActiveScene().buildIndex == 2)
                    PlayerPrefs.SetString("HallDoor", transform.parent.name);

                if (PlayerPrefs.GetInt("final") == 2)
                {
                    SceneManager.LoadScene(4);
                    return;
                }

                SceneManager.LoadScene(sceneID);
            }
        }
    }
}
