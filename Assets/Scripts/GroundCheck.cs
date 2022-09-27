using UnityEngine;

public class GroundCheck : MonoBehaviour
{

  [SerializeField] private LayerMask groundLayer;

  public bool isGrounded;

  private void OnTriggerStay2D(Collider2D collider)
  {
    isGrounded = collider != null && (((1 << collider.gameObject.layer) & groundLayer) != 0);
  }

  private void OnTriggerExit2D(Collider2D collider)
  {
    isGrounded = false;
  }

}