using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] ParticleSystem crashEffect;
  [SerializeField] AudioClip crashSFX;
  bool hasCrashed = false;



  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Ground" && !hasCrashed)
    {
      // StartCoroutine(ReloadScene());
      FindObjectOfType<GameSession>().ProcessPlayerDeath();
      hasCrashed = true;
      Debug.Log("Ouch!! it hurts!");
      crashEffect.Play();
      FindObjectOfType<PlayerController>().DisableControls(false);
      GetComponent<AudioSource>().PlayOneShot(crashSFX);
    }
  }

  IEnumerator ReloadScene()
  {
    yield return new WaitForSecondsRealtime(3);
    SceneManager.LoadScene(0);
  }
}
