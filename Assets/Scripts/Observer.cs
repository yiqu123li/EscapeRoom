using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Transform player; //主角
    [SerializeField] private GameEnding gameEnding;

    private bool m_IsPlayerInRange;

    private void Update()
    {
        if (m_IsPlayerInRange)
        {
            var direction = player.position - transform.position + Vector3.up;
            var ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player == other.transform)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player == other.transform)
        {
            m_IsPlayerInRange = false;
        }
    }
}
