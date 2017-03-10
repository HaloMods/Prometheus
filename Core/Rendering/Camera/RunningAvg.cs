using System;
using Microsoft.DirectX;

namespace Core.Rendering.Camera
{
  internal class RunningAvg
  {
    private static int BUF_SIZE = 10;
    private float[] m_Buffer = new float[BUF_SIZE];
    private int m_Index = 0;
    private float m_Average = 0;
    public float Average
    {
      get { return m_Average; }
    }
    public float Update(float data_pt)
    {
      m_Average = 0;
      m_Buffer[m_Index] = data_pt;
      m_Index++;
      if ((m_Index % BUF_SIZE) == 0)
        m_Index = 0;

      for (int i = 0; i < BUF_SIZE; i++)
        m_Average += m_Buffer[i];

      m_Average /= BUF_SIZE;

      return (m_Average);
    }
  }
}
