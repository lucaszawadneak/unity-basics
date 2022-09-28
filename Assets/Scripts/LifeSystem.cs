using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
  public int life = 3;
  [SerializeField] private TMPro.TMP_Text lifeText;

  // Update is called once per frame
  void Update()
  {
  }

  public void TakeDamage()
  {
    life--;
    if (lifeText != null)
    {
      lifeText.text = life.ToString();
      GetComponentInParent<PlayerMovement>().AnimateDamage();
    }
    if (life <= 0)
    {
      GetComponentInParent<PlayerMovement>().AnimateDeath();
    }
  }
}
