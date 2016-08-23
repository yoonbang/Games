using UnityEngine;
using System.Collections;
public class MoveUtil
{
    //캐릭터 이동 (캐릭터컨트롤러, 이동할위치, 이동속도, 회전속도) 인자값을 받아온다.
    public static float MoveFrame(CharacterController characterController, Transform target, float moveSpeed, float turnSpeed)
    {
        Transform t = characterController.transform;
        Vector3 dir = target.position - t.position;
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);
        Vector3 targetPos = t.position + dirXZ;
        Vector3 framePos = Vector3.MoveTowards(t.position, targetPos, moveSpeed * Time.deltaTime);

        characterController.Move(framePos - t.position + Physics.gravity);

        RotateToDir(t, target, turnSpeed);

        return Vector3.Distance(framePos, targetPos);
    }


    //캐릭터 회전 (본인 위치, 회전할 각도, 회전 속도) 인자값을 MoveFrame() 에서 받아온다.
    public static void RotateToDir(Transform self, Transform target, float turnSpeed)
    {
        Vector3 dir = target.position - self.position;
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);

        //회전 방향이 더이상 할 필요가 없을 경우
        if (dirXZ == Vector3.zero)
            return;

        //회전.
        self.rotation = Quaternion.LookRotation(new Vector3(target.position.x, self.transform.position.y, target.position.z) - self.transform.position);
        //self.rotation = Quaternion.RotateTowards(self.rotation, Quaternion.LookRotation(dirXZ), turnSpeed * Time.deltaTime);
    }


    // 긴급 회전 (몬스터 한테 맞을 경우 등)
    public static void RotateToDirBurst(Transform self, Transform target)
    {
        Vector3 dir = target.position - self.position;
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);

        //회전 방향이 더이상 할 필요가 없을 경우
        if (dirXZ == Vector3.zero)
            return;

        //회전.
        self.rotation = Quaternion.LookRotation(dirXZ);
    }
}