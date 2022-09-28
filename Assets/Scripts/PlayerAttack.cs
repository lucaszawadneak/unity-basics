using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  private GameObject attackArea = default;

  private bool attacking = false;

  private float timeToAttack = 0.25f;
  private float timer = 0f;

  // Start is called before the first frame update
  void Start()
  {
    attackArea = transform.GetChild(0).gameObject;
    attackArea.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      Attack();
    }

    if (attacking)
    {
      timer += Time.deltaTime;

      if (timer >= timeToAttack)
      {
        attacking = false;
        timer = 0f;
        attackArea.SetActive(false);
      }
    }

  }

  private void Attack()
  {
    attacking = true;
    attackArea.SetActive(true);
    GetComponent<PlayerMovement>().AnimateAttack();

  }
}
