using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    //��ó ��ڻ��� ����Ƽ ��Ʈ
    //https://www.youtube.com/watch?v=0El8t9-4x6E


    private float shakeTime; // ��鸮�� �ð�
    private float shakeIntensity; // ��鸲 ���� 

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            OnShakeCamera(0.1f, 1f);
        }
    }
    ///<summary>
    /// ī�޶��� ��鸲 ���� ȣ�� �޼ҵ�
    /// x.f �ʰ� x_1 �� ����� ��鸲
    /// </summary>
    ///<param name="shakeTime">ī�޶� ��鸲 ���ӽð� ���� ���ҽ� �⺻�� 1f 
    ///<param name="shakeIntensity">ī�޶� ��鸲 ���� ���� Ŭ���� ������ �⺻�� 0.1f
    // �� �� ���̰� ó�� ��� �̰� ���� ��� �Ǵ°ž�? �� ������ �߳� �ű��ϴ� -����-

    public void OnShakeCamera(float shakeTime = 1.0f,float shakeIntensity= 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    /// <summary>
    /// ī�޶� shakeTime ���� shakeIntensity �� ����� ���� �ڷ�ƾ �Լ�
    /// </summary>
    private IEnumerator ShakeByPosition()
    {
        // ��鸮�� ������ ������ġ (��鸲 ������ ���ƿ� ��ġ)
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
            // Ư�� �ุ �����ϱ� ���ϸ� �Ʒ� �ڵ� �̿� (�̵����� ���� ���� 0�� ���)
            //float x = Random.Range(-1f,1f);
            //float y = Random.Range(-1f,1f);
            //float z = Random.Range(-1f,1f);
            //transform.position = startPosition + new Vector3(x,y,z) * shakeIntensity;

            //�ʱ� ��ġ�κ��� �� ����(Size 1) * shakeIntensity�� �����ȿ��� ī�޶� ��ġ ����
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            //�ð� ����
            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
}
