using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPlayer : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera cam;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        StartCoroutine(LookForPlayer());
    }

    private IEnumerator LookForPlayer()
    {
        yield return new WaitForSeconds(.1f);

        player = GameObject.FindWithTag("PlayerSprite");
        cam.Follow = player.transform;
    }
}
