using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float loadDelay = 1f;
  [SerializeField] ParticleSystem crashEffect;
  [SerializeField] AudioClip crashSFX;
  bool hasCrashed = false;


  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Ground" && !hasCrashed)
    {
      hasCrashed = true;
      Debug.Log("Ouch!! it hurts!");
      crashEffect.Play();
      FindObjectOfType<PlayerController>().DisableControls();
      GetComponent<AudioSource>().PlayOneShot(crashSFX);
      Invoke("ReloadScene", loadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
