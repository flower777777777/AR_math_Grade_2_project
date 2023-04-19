using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleMirror : IMirror {
    private MirrorType _mirrorType;
    private Image _image;
    public bool CanDraw
    {
        get { return true; }
    }
    public void Init(MirrorType mirrorType,Image image)
    {
        _mirrorType = mirrorType;
        _image = image;
    }
    //将图像分成四份，然后图像变换到左上角的位置
    private void ChangeVertexPos(Rect rect,List<UIVertex> vertices)
    {
        Vector3 pos = Vector3.zero;
        UIVertex uiVertex;
        for(int i = 0; i < vertices.Count; i++)
        {
            uiVertex = vertices[i];
            pos = uiVertex.position;
            if (_mirrorType == MirrorType.HORIZONTAL || _mirrorType == MirrorType.ALL)
            {
                pos.x = (pos.x + rect.x) * 0.5f;
            }
            if (_mirrorType == MirrorType.VERTICAL || _mirrorType == MirrorType.ALL)
            {
                pos.y = (pos.y + rect.y + rect.height) * 0.5f;
            }
            uiVertex.position = pos;
            vertices[i] = uiVertex;
        }
    }
    //绘制图形
    public void Draw(List<UIVertex> vertices)
    {
        //目标绘制区域的坐标及大小（x,y为该UI相对于轴心的坐标，width，height为UI宽高）
        Rect rect = _image.GetPixelAdjustedRect();
        //将顶点位置变换到左上角
        ChangeVertexPos(rect, vertices);
        MirrorUtil.RemoveInvalidVertex(vertices);
        MirrorUtil.MirrorVertex(rect, vertices, _mirrorType);
    }
}
