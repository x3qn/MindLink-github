using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTriggerScript : MonoBehaviour
{
    private bool player1InZone = false;
    private bool player2InZone = false;
    private GameObject number3;
    private GameObject number2;
    private GameObject number1;

    void Awake()
    {
        number3 = transform.Find("3")?.gameObject;
        number2 = transform.Find("2")?.gameObject;
        number1 = transform.Find("1")?.gameObject;

        HideNumbers();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1InZone = true;
        }
        else if (other.CompareTag("Player2"))
        {
            player2InZone = true;
        }

        if (player1InZone && player2InZone)
        {
            StartCoroutine(CountdownAndLoadScene());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1InZone = false;
        }
        else if (other.CompareTag("Player2"))
        {
            player2InZone = false;
        }

        if (!player1InZone || !player2InZone)
        {
            StopAllCoroutines();
            HideNumbers();
        }
    }

    private IEnumerator CountdownAndLoadScene()
    {
        ShowNumber(number3);
        yield return new WaitForSeconds(1f);
        ShowNumber(number2);
        yield return new WaitForSeconds(1f);
        ShowNumber(number1);
        yield return new WaitForSeconds(1f);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Keine weitere Szene verfügbar!");
        }
    }

    private void ShowNumber(GameObject number)
    {
        HideNumbers();
        if (number != null)
        {
            number.SetActive(true);
        }
    }

    private void HideNumbers()
    {
        if (number3 != null) number3.SetActive(false);
        if (number2 != null) number2.SetActive(false);
        if (number1 != null) number1.SetActive(false);
    }
}
