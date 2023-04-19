using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//镜像类型
public enum MirrorType
{
	HORIZONTAL,
	VERTICAL,
	ALL
}
//镜像接口
public interface IMirror
{
	bool CanDraw { get; }
	void Init(MirrorType type,Image image);
	void Draw(List<UIVertex> vertices);
}
[RequireComponent(typeof(Image))]
public class MirrorImage : BaseMeshEffect
{
	//镜像的类型
	public MirrorType _mirrorType = MirrorType.HORIZONTAL;
	//存放UI的顶点信息
	private List<UIVertex> _vertices=new List<UIVertex>();
	//key是图片平铺类型
	private Dictionary<Image.Type, IMirror> _mirrors;

	//初始化镜像Image的类型字典
	private void InitMirror()
	{
		_mirrors = new Dictionary<Image.Type, IMirror>();
		_mirrors.Add(Image.Type.Simple, new SimpleMirror());
		_mirrors.Add(Image.Type.Sliced, new SimpleMirror());
		_mirrors.Add(Image.Type.Tiled, new TiledMirror());
	}
	private Dictionary<Image.Type, IMirror> Mirrors
	{
		get
		{
			if (_mirrors == null)
			{
				InitMirror();
			}
			return _mirrors;
		}
	}

	private IMirror GetMirrorObject()
	{
		Image image = graphic as Image;
		IMirror mirror = Mirrors[Image.Type.Simple];
		if (Mirrors.ContainsKey(image.type))
		{
			mirror = Mirrors[image.type];
			mirror.Init(_mirrorType, image);
			if (mirror.CanDraw)
			{
				return mirror;
			}
		}
		mirror.Init(_mirrorType, image);
		return mirror;
	}
    //修改网络
    public override void ModifyMesh(VertexHelper vh)
    {
		if (!IsActive())
		{
			return;
		}
		IMirror mirror = GetMirrorObject();
		vh.GetUIVertexStream(_vertices);
		mirror.Draw(_vertices);
		vh.Clear();
		vh.AddUIVertexTriangleStream(_vertices);
    }
	//扩大显示区域
	public void SetNativeSize()
	{
		Image image = graphic as Image;
		if (image.overrideSprite != null)
		{
			float width = image.overrideSprite.rect.width / image.pixelsPerUnit;
			float height = image.overrideSprite.rect.height / image.pixelsPerUnit;

			image.rectTransform.anchorMax = image.rectTransform.anchorMin;
			Vector2 temp = Vector2.zero;
			switch (_mirrorType)
			{
				case MirrorType.HORIZONTAL:
					temp.x = width * 2;
					temp.y = height;
					break;
				case MirrorType.VERTICAL:
					temp.x = width;
					temp.y = height * 2;
					break;
				case MirrorType.ALL:
					temp.x = width * 2;
					temp.y = height * 2;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
