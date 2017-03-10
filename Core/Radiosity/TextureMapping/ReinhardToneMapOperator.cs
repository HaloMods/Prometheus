using System;
using System.Drawing;

using Interfaces.Rendering.Interfaces;

namespace Core.Radiosity.TextureMapping
{
	/// <summary>
	/// Implementation of the Reinhard tone map operator.
	/// </summary>
	public sealed class ReinhardToneMapOperator : IToneMapOperator
	{
		#region Members
		private Bitmap m_Image;
		private double[, ,] m_HDRi;
		private double[,] m_Luminances;
		private int m_Width, m_Height;

		private double m_Sigma_0, m_Sigma_1, m_BBeta;

		// Defaults:
		private float m_Key = 0.18f;
		private double m_White = 1e20;
		private float m_Gamma = 1.6f;
		private float m_Threshold = 0.05f;
		private float phi = 8.0f;
		private int num = 8;
		private int scale_low = 1;
		private int scale_high = 43;
		private int range = 8;
    double key = 0.18;
    double gammaval = 1.6;


   static readonly double[,] XYZ2RGB = new double[3, 3]{{ 2.5651,   -1.1665,   -0.3986},
				 {-1.0217,    1.9777,    0.0439},
				 { 0.0753,   -0.2543,    1.1892}};
    static readonly double[,] RGB2XYZ = new double[3, 3]{{0.5141364, 0.3238786,  0.16036376},{
				 0.265068,  0.67023428, 0.06409157},
				 {0.0241188, 0.1228178,  0.84442666}};
		#endregion

		#region Constructor
		/// <summary>
		/// Constructs a Reinhard tone map operator.
		/// </summary>
		public ReinhardToneMapOperator() { }
		#endregion

		#region IToneMapOperator member
		/// <summary>
		/// Returns a rgba image.
		/// Leave parameters blank to use defaults.
		/// <param name="optionalsettings">
		///     If used the parameters are as follows:
		/// </param>
		/// </summary>
		public Bitmap CreateImage(double[, ,] HDRi, params object[] optionalsettings)
		{
			int _width = (int)optionalsettings[0];
			int _height = (int)optionalsettings[1];
			this.m_Image = new Bitmap(_width, _height);
			this.m_Luminances = new double[_width, _height];
			this.m_Height = _height;
			this.m_Width = _width;
			this.m_HDRi = HDRi;

			// Compute sigma 0 and 1.
			this.m_Sigma_0 = Math.Log(this.scale_low);
			this.m_Sigma_1 = Math.Log(this.scale_high);
			this.Compute_bessel();
			this.rgb_Yxy();
      //CopyLuminances();
      //scale_to_midtone();
			this.Compute_fourier_convolution();
			this.Tonemap_image();
			this.Yxy_RGB();
//      ClampImage();
			return this.m_Image;
  //compute_bessel              ();
  //rgb_Yxy                     ();
  //copy_luminance              ();
  //scale_to_midtone            ();
  //compute_fourier
  //tonemap_image               ();
  //Yxy_rgb                     ();
  //clamp_image                 ();
  //write_image                 ();

		}

		#endregion

		#region Bessel function
		/// <summary>
		/// Modified zeroeth order bessel function of the first kind.
		/// </summary>
		private void Compute_bessel()
		{      
      this.m_BBeta = Bessel(Math.PI * 2);
		}

    double kaiserbessel(double x, double y, double M)
    {
      double d = 1 - ((x * x + y * y) / (M * M));
      if (d <= 0)
        return 0;
      return Bessel(Math.PI * 2 * Math.Sqrt(d)) / m_BBeta;
    }

    double log_average()
    {
      int x, y;
      double sum = 0;

      for (x = 0; x < m_Width; x++)
        for (y = 0; y < m_Height; y++)
          sum += Math.Log(0.00001 + m_Luminances[x,y]);
      return Math.Exp(sum / (double)(m_Width * m_Height));
    }


    private static double Bessel(double x)
    {
      double f = 1e-9;
      int n = 1;
      double s = 1;
      double d = 1;
      double t;

      while (d > f * s)
      {
        t = x / (2 * n);
        n++;
        d *= t * t;
        s += d;
      }
      return s;
    }
		#endregion

		#region RGB->Yxy
		/// <summary>
		/// Colour space conversion. rgb->Yxy
		/// </summary>
		private void rgb_Yxy()
		{
			double[,] RGB2XYZ = new double[3, 3]{{0.5141364, 0.3238786,  0.16036376},
				 {0.265068,  0.67023428, 0.06409157},
				 {0.0241188, 0.1228178,  0.84442666}};
			double[] result = new double[3];
			double W;

			for (int x = 0; x < this.m_Width; x++)
			{
				for (int y = 0; y < this.m_Height; y++)
				{
					result[0] = result[1] = result[2] = 0;
					for (int i = 0; i < 3; i++)
					{
						for (int j = 0; j < 3; j++)
						{
							result[i] += RGB2XYZ[i, j] * this.m_HDRi[x, y, j];
							W = result[0] + result[1] + result[2];
							if (W > 0)
							{
								this.m_HDRi[x, y, 0] = result[1] * this.m_Key;
								this.m_HDRi[x, y, 1] = result[0] / W;
								this.m_HDRi[x, y, 2] = result[1] / W;
							}
							else
							{
								this.m_HDRi[x, y, 0] = 0;
								this.m_HDRi[x, y, 1] = 0;
								this.m_HDRi[x, y, 2] = 0;
							}
						}
					}
					this.m_Luminances[x, y] = this.m_HDRi[x, y, 0];
				}
			}
		}
		#endregion

		#region Yxy->RGB
		/// <summary>
		/// Colour space conversion Yxy->rgb.
		/// </summary>
		private void Yxy_RGB()
		{
			double[] result = new double[3];
			double X, Y, Z;
      int negativePixels = 0;

			for (int x = 0; x < this.m_Width; x++)
			{
				for (int y = 0; y < this.m_Height; y++)
				{
					Y = this.m_HDRi[x, y, 0];
					result[1] = this.m_HDRi[x, y, 1];
					result[2] = this.m_HDRi[x, y, 2];
					if ((Y > 0) && (result[1] > 0) && (result[2] > 0))
					{
						X = (result[1] * Y) / result[2];
						Z = (X / result[1]) - X - Y;
					}
					else
					{
						X = Z = 0;
					}

					this.m_HDRi[x, y, 0] = X;
					this.m_HDRi[x, y, 1] = Y;
					this.m_HDRi[x, y, 2] = Z;
					result[0] = result[1] = result[2] = 0;

					for (int i = 0; i < 3; i++)
					{
						for (int j = 0; j < 3; j++)
						{
							result[i] += XYZ2RGB[i, j] * this.m_HDRi[x, y, j];
						}
					}

					for (int i = 0; i < 3; i++)
					{
						this.m_HDRi[x, y, i] = result[i];

						// Clamp channel between 0->1.
						this.m_HDRi[x, y, i] = (this.m_HDRi[x, y, i] > 1) ? 1 : this.m_HDRi[x, y, i];
            if (m_HDRi[x, y, i] < 0)
            {
              negativePixels++;
              m_HDRi[x, y, i] = 0;
            }
					}
          
					//int r = (int)Math.Floor(255*this.m_HDRi[x,y,0]);
          int r = (int)(255 * Math.Pow(m_HDRi[x, y, 0], 1 / gammaval));
          int g = (int)(255 * Math.Pow(m_HDRi[x, y, 1], 1 / gammaval));
          int b = (int)(255 * Math.Pow(m_HDRi[x, y, 2], 1 / gammaval));
					//int g = (int)Math.Floor(255*this.m_HDRi[x,y,1]);
					//int b = (int)Math.Floor(255*this.m_HDRi[x,y,2]);
          if ((r > 255) || (r < 0) || (g > 255) || (g < 0) || (b > 255) || (b < 0))
          {
#if DEBUG
            //throw new RadiosityException("Reinhardt operator returned invalid color values.", RadiosityLocation.Reinhardt);
//#else
            Interfaces.Output.Write(Interfaces.OutputTypes.Error, "Tonemapping operator returned invalid color value - your lightmapping results may be incorrect.");     
#endif
            // not in debug mode, so recover
            r = (Math.Abs(r) + r) / 2; g = (Math.Abs(g) + g) / 2; b = (Math.Abs(b) + b) / 2; // This will clamp the values to zero or their original value.
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;
          }
					Color c = Color.FromArgb(r, g, b);
					this.m_Image.SetPixel(x, y, c);
				}
			}
      if (negativePixels > 0)
        Interfaces.Output.Write(Interfaces.OutputTypes.Developer, string.Format("{0}% ({1} channels) were invalid.", negativePixels / (m_Width * m_Height * 3), negativePixels));
		}
		#endregion

		private void Compute_fourier_convolution()
		{
      /*int x;
      zomplex* convolution_fft;

      initialise_fft(cvts.xmax, cvts.ymax);
      build_image_fft();
      build_gaussian_fft();
      convolved_image = (double***)malloc(range * sizeof(double**));

      convolution_fft = (zomplex*)calloc(cvts.xmax * cvts.ymax, sizeof(zomplex));
      for (scale = 0; scale < range; scale++)
      {
        fprintf(stderr, "Computing convolved image at scale %i%c", scale, (char)13);
        convolved_image[scale] = (double**)malloc(cvts.xmax * sizeof(double*));
        for (x = 0; x < cvts.xmax; x++)
          convolved_image[scale][x] = (double*)malloc(cvts.ymax * sizeof(double));
        convolve_filter(scale, convolution_fft);
        free(filter_fft[scale]);
      }
      fprintf(stderr, "\n");
      free(convolution_fft);
      free(image_fft);*/
		}
    private void CopyLuminances()
    {
      for (int x = 0; x < m_Width; x++)
        for (int y = 0; y < m_Height; y++)
          m_Luminances[x, y] = m_HDRi[x, y, 0];
    }
    private void scale_to_midtone()
    {
      int x, y, u, v, d;
      double factor;
      double scale_factor;
      double low_tone = key / 3f;
      int border_size = ((m_Width < m_Height) ? m_Width / 5 : m_Height / 5);
      int hw = m_Width >> 1;
      int hh = m_Height >> 1;

      scale_factor = 1.0 / log_average();
      for (y = 0; y < m_Height; y++)
        for (x = 0; x < m_Width; x++)
        {
          factor = key;
          m_HDRi[x,y,0] *= scale_factor * factor;
          m_Luminances[x,y] *= scale_factor * factor;
        }
    }


    #region Calculate max scene value
    private double GetMaxValue()
		{
			double max = 0;
			for (int x = 0; x < this.m_Width; x++)
			{
				for (int y = 0; y < this.m_Height; y++)
				{
					max = (max < this.m_HDRi[x, y, 0]) ? this.m_HDRi[x, y, 0] : max;
				}
			}
			return max;
		}
		#endregion

		#region Tone Image
		/// <summary>
		/// Tones the floating point bitmap to 0 to 1 values.
		/// </summary>
		private void Tonemap_image()
		{

			double Lmax2;
			int scale, prefscale;

			if (this.m_White < 1e20)
				Lmax2 = this.m_White * this.m_White;
			else
			{
				Lmax2 = this.GetMaxValue();
				Lmax2 *= Lmax2;
			}

			for (int x = 0; x < this.m_Width; x++)
				for (int y = 0; y < this.m_Height; y++)
				{
					if (Lmax2 != 0.0)
					{
						m_HDRi[x, y, 0] = m_HDRi[x, y, 0] * (1 + (m_HDRi[x, y, 0] / Lmax2)) / (1 + m_HDRi[x, y, 0]);
					}
				}
    }
		#endregion
	}
}
