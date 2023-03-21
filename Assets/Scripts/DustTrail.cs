using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
  [SerializeField] ParticleSystem dustTrail;
  bool trailOn = true;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Ground" && trailOn)
    {
      dustTrail.Play();
    }
  }


  private void OnCollisionExit2D(Collision2D other)
  {
    dustTrail.Stop();
  }

  public void DisableTrail()
  {
    trailOn = false;
  }
}
