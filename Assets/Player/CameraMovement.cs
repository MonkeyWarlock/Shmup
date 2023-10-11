using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject myPlayer;
    [SerializeField] private GameObject myCameraCenter;
    [SerializeField] private GameObject myMapBorder;

    //if player pos X is above camera center, move camera
    private void Update()
    {
        if (myCameraCenter.transform.position.x + 8 < myMapBorder.transform.position.x)
        {
            if (myPlayer.transform.position.x >= myCameraCenter.transform.position.x)
            {
                transform.position = new Vector3(myPlayer.transform.position.x, 0.0f, transform.position.z);
            }
        }
    }

}
