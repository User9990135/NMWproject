using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_num1 : MonoBehaviour
{
    public bool Spawn = false;  // 귀신이 다시 활동을 할수있는지 여부를 확인하는 변수입니다
    public float SpawnTimer = 10f;  // 귀신이 다시 활동을 재개하는 시간 변수 입니다. 테스트용으로 시간을 10f로 정했습니다.
    public float PlayerInTime = 0f; // 플레이어가 귀신의 활동범위 안에 대기한 시간입니다 트리거 타임보다 적다면 사망합니다.
    public float TriggerTime= 4f; // 귀신이 범위안에 들어온 플레이어가 대기해야하는 시간 입니다.

    public float triggerRadius = 5f; // 이벤트를 발생시킬 범위의 반지름 입니다
    public LayerMask targetLayer; // 플레이어를 확인할 레이어 입니다 플레이어의 레이어는 Player_Layer 입니다

    private bool playerInRange = false; // 플레이어가 범위 안에 있는지 여부

    private void Update()
    {

        if (Spawn == false)  // 귀신이 활동을 끝내어 활동상태가 false 일경우 다시 활동하기위해 쿨타임이 돌아갑니다.
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0f)
            {
                Debug.Log("Ghost_num1 respawn");
                SpawnTimer = 10f;
                Spawn = true;
            }
        }
        

        if(Spawn ==true)  // 귀신이 활동이 가능해질경우 범위안에 들어오는 플레이어를 탐지합니다
        {
             // 플레이어를 탐지하는 코드입니다.
            Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
            bool isPlayerInRange = colliders.Length > 0;


            if(playerInRange == true) // 플레이어가 범위안에 들어와 대기시간만큼 기다릴경우 살려주는 코드입니다
            {
                PlayerInTime += Time.deltaTime;

                if (PlayerInTime >= TriggerTime)
                {
                    Debug.Log("Ghost_num1 not kill you");
                    SpawnTimer = 10f;
                    PlayerInTime = 0f;
                    Spawn = false;
                }

            }
            // 플레이어가 범위에 처음 들어왔을 때 이벤트 발생 
            if (isPlayerInRange && !playerInRange)
            {
                playerInRange = true;
                // 이벤트 발생 코드 작성

                Debug.Log("Ghost_num1 Wathing you");
                // 사운드매니저에 접근하여 사운드를 재생해야합니다.
            }
            // 플레이어가 범위를 벗어났을 때 플래그 업데이트
            else if (!isPlayerInRange && playerInRange)
            {
                playerInRange = false;
                // 플레이어가 범위를 벗어난 경우에 대한 처리 코드 작성
                if (PlayerInTime < TriggerTime)
                {
                    Debug.Log("Ghost kill you");

                    //귀신이 플레이어를 죽이는 함수를 호출합니다
                    
                }
               
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 트리거 범위를 시각적으로 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
