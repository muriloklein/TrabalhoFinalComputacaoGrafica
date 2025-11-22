using UnityEngine;

public class FinishLine : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
     {
          if (!other.CompareTag("Player")) return;

          int kills = GameManager.Instance.GetDestroyed();
          int required = GameManager.Instance.killsRequiredToWin;

          if (kills >= required)
          {
               GameManager.Instance.WinGame();
          }
          else
          {
               KillRequirementUI.Instance.ShowMessage();
          }
     }

     private void OnTriggerExit2D(Collider2D other)
     {
          if (other.CompareTag("Player"))
          {
               if (KillRequirementUI.Instance != null)
                    KillRequirementUI.Instance.HideMessage();
          }
     }
}
