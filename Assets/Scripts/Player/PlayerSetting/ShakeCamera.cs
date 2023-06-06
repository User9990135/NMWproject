using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    //출처 고박사의 유니티 노트
    //https://www.youtube.com/watch?v=0El8t9-4x6E


    private float shakeTime; // 흔들리는 시간
    private float shakeIntensity; // 흔들림 강도 

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            OnShakeCamera(0.1f, 1f);
        }
    }
    ///<summary>
    /// 카메라의 흔들림 조작 호출 메소드
    /// x.f 초간 x_1 의 세기로 흔들림
    /// </summary>
    ///<param name="shakeTime">카메라 흔들림 지속시간 설정 안할시 기본값 1f 
    ///<param name="shakeIntensity">카메라 흔들림 세기 값이 클수록 강해짐 기본값 0.1f
    // ㄴ 오 나이거 처음 써봐 이거 쓰면 어떻게 되는거야? 오 툴팁에 뜨네 신기하당 -공명-

    public void OnShakeCamera(float shakeTime = 1.0f,float shakeIntensity= 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    /// <summary>
    /// 카메라를 shakeTime 동안 shakeIntensity 의 세기로 흔드는 코루틴 함수
    /// </summary>
    private IEnumerator ShakeByPosition()
    {
        // 흔들리기 직전의 시작위치 (흔들림 종료후 돌아올 위치)
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
            // 특정 축만 변경하길 원하면 아래 코드 이용 (이동하지 않을 축은 0값 사용)
            //float x = Random.Range(-1f,1f);
            //float y = Random.Range(-1f,1f);
            //float z = Random.Range(-1f,1f);
            //transform.position = startPosition + new Vector3(x,y,z) * shakeIntensity;

            //초기 위치로부터 구 범위(Size 1) * shakeIntensity의 범위안에서 카메라 위치 변동
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            //시간 감소
            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
}
