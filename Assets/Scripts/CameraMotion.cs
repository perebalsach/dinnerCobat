using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public GameObject Player;
    public float YOffset;
    public float ZOffset;
    public float OffsetTargetY;


    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, 
                                                Player.transform.position.y + YOffset,
                                                Player.transform.position.z + ZOffset
                                            );

        var lookAt = new Vector3(Player.transform.position.x, 
                                    Player.transform.position.y + OffsetTargetY,
                                    Player.transform.position.z
                                );

        this.transform.LookAt(lookAt);
    }
}
