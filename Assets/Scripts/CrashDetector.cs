using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float reloadDelay = 1f;
  [SerializeField] ParticleSystem crashEffect;
  [SerializeField] AudioClip crashSFX;

  bool crashed = false;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Ground" && !crashed)
    {
      crashed = true;
      FindObjectOfType<PlayerController>().DisableControls();
      crashEffect.Play();
      GetComponent<AudioSource>().PlayOneShot(crashSFX);
      FindObjectOfType<DustTrail>().DisableTrail();
      Debug.Log("OUCH!");
      Invoke("ReloadScene", reloadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
