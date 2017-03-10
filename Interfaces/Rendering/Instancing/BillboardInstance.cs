using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Rendering.Interfaces;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Selection;

namespace Interfaces.Rendering.Instancing
{
  public class BillboardInstance : WorldInstance
  {
    private Billboard billboardEntity;
    private Matrix billboardMatrix = new Matrix();

    public override void Render()
    {
      base.Render();
      Render(true);
    }

    protected virtual bool Render(bool draw)
    {
      bool zbufferWriteEnable = MdxRender.Device.RenderState.ZBufferWriteEnable;
      MdxRender.Device.RenderState.ZBufferWriteEnable = false;

      if (draw)//is this draw flag updated for object distance outside?
      {
        float dist = MdxRender.Camera.GetObjectDistance(
                bindingTransform.X,
                bindingTransform.Y,
                bindingTransform.Z);

        if (dist < 30)
        {
          if (selectTool.m_Mode != EditMode.NotSelected)
          {
            MdxRender.Device.Transform.World = bindingTransform.matrix;
            //m_Model.Render(dist);
          }

          billboardMatrix = MdxRender.Camera.InverseView;
          billboardMatrix.M41 = bindingTransform.X;
          billboardMatrix.M42 = bindingTransform.Y;
          billboardMatrix.M43 = bindingTransform.Z;

          MdxRender.Device.Transform.World = billboardMatrix;

          entity.Render();
        }
      }

      MdxRender.Device.RenderState.ZBufferWriteEnable = zbufferWriteEnable;
      return false;
    }

    public BillboardInstance(IRenderable entity, Vector3 centroid, BoundingBox boundingBox)
      : base(entity, centroid, boundingBox)
    {
      billboardEntity = (Billboard)entity;
    }
  }
}
