using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
  [SerializeField] int numberOfFlips = 0;
  bool flipDone = false;


  void Start()
  {


  }

  void Update()
  {

    addScore();
    StartCoroutine(resetFlipDone());
  }

  void addScore()
  {
    Debug.Log(transform.rotation.z);
    if (Mathf.Abs(transform.rotation.z) > 0.8f && !flipDone)
    {
      numberOfFlips++;
      flipDone = true;

    }
  }
  IEnumerator resetFlipDone()
  {
    yield return new WaitForSecondsRealtime(0.2f);
    if (Mathf.Abs(transform.rotation.z) < 0.2f)
    {
      flipDone = false;
    }
  }
}
