using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Interact : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Animator text;

    [SerializeField] private GameObject cam_1;
    [SerializeField] private GameObject cam_2;

    private CinemachineVirtualCamera vcam_1;
    private CinemachineVirtualCamera vcam_2;

    private bool _playerEnter;
    //private bool buttonPressed = false;

    private void Start()
    {
        vcam_1 = cam_1.GetComponent<CinemachineVirtualCamera>();
        vcam_2 = cam_2.GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerPrefs.GetInt("final") == 0)
        {
            _playerEnter = true;

            text.SetBool("PlayerEnter", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && PlayerPrefs.GetInt("final") == 0)
        {
            _playerEnter = false;

            text.SetBool("PlayerEnter", false);
        }
    }

    private void Update()
    {
        if (_playerEnter && PlayerPrefs.GetInt("final") == 0)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                canvas.gameObject.SetActive(true);

                text.SetBool("PlayerEnter", false);

                PlayerPrefs.SetInt("final", 1);
            }
        }

        if (_playerEnter && PlayerPrefs.GetInt("final") == 1)
        {
            if (Input.anyKey)
            {
                canvas.gameObject.SetActive(false);

                StartCoroutine(SwitchCamera());

                PlayerPrefs.SetInt("final", 2);
            }
        }
    }

    private IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(.5f);

        cam_2.transform.localPosition = cam_1.transform.localPosition;

        vcam_2.Priority = 11;

        yield return new WaitForSeconds(3f);

        vcam_2.Priority = 9;
    }
}
