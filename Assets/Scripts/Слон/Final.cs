using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Animator textAnim;
    [SerializeField] private GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerMovement.enabled = false;
            playerAnim.SetBool("WalkLeft", false);

            StartCoroutine(TextOn());
        }
    }

    private IEnumerator TextOn()
    {
        yield return new WaitForSeconds(2f);
        textAnim.SetTrigger("enterFinal");
        yield return new WaitForSeconds(3f);
        canvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
