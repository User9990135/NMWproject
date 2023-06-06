using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_obj : MonoBehaviour
{

    public float triggerRadius = 5f; //�÷��̾� ���� ����.
    private bool playerInRange = false;
    public LayerMask targetLayer;
    public GameObject Puzzle_UI;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

        // �÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� 
        if (isPlayerInRange && !playerInRange)
        {
            Debug.Log("Press GetKey Down Q");
            //�÷��̾�� ��ȣ�ۿ� Ű �����ֱ�.
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Puzzle_Game();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                Puzzle_UnGame();
            }
        }
    }


    public void Puzzle_Game()
    {
        Puzzle_UI.gameObject.SetActive(true);
    
    }
    public void Puzzle_UnGame()
    {
        Puzzle_UI.gameObject.SetActive(false);

    }
    private void OnDrawGizmosSelected()
    {
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
