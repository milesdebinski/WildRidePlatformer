using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  [SerializeField] float loadDelay = 1f;
  [SerializeField] ParticleSystem finishEffect;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      StartCoroutine(LoadNextLevel());
      GetComponent<AudioSource>().Play();
      finishEffect.Play();
    }
  }

  IEnumerator LoadNextLevel()
  {
    yield return new WaitForSecondsRealtime(loadDelay);

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;
    // Set to the first level if there is no more levels
    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
      nextSceneIndex = 0;
    }

    SceneManager.LoadSceneAsync(nextSceneIndex);
  }
}
