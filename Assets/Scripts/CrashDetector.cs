using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float reloadDelay = 1f;
  [SerializeField] ParticleSystem crashEffect;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Ground")
    {
      crashEffect.Play();
      Debug.Log("OUCH!");
      Invoke("ReloadScene", reloadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
