using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_obj : MonoBehaviour
{

    public float triggerRadius = 5f; //플레이어 감지 범위.
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

        // 플레이어가 범위에 처음 들어왔을 때 이벤트 발생 
        if (isPlayerInRange && !playerInRange)
        {
            Debug.Log("Press GetKey Down Q");
            //플레이어에게 상호작용 키 보여주기.
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
        // 트리거 범위를 시각적으로 표시
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
