using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private int flag = 0;
    private bool b = false;
    private GameObject go;
    Vector3 targetScreenPos;
    Vector3 mousePos;
    Camera mainCamera;
    void Start()
    {
        mainCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;//射线碰撞到的物体
            if (Physics.Raycast(ray, out hit))
            {

                go = hit.collider.gameObject.transform.parent.gameObject;//点击到的物体
                if (go.name == this.name)
                {
                    b = true;
                    if (flag == 0)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                    }
                    if (flag == 1 && b && go != null)
                    {
                        targetScreenPos = mainCamera.WorldToScreenPoint(go.transform.position);//将屏幕坐标转换成世界坐标
                        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPos.z);//鼠标的位置                    
                        go.transform.position = mainCamera.ScreenToWorldPoint(mousePos);//将物体的位置给到鼠标颠倒屏幕的位置
                    }
                }
            }
        }
    }
}