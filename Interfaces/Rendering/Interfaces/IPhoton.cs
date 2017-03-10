using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Interfaces.Rendering.Primitives;

///
/// IPhoton.cs
/// 
/// Author: James Dickson   james.dickson@gmail.com
/// 
/// Company: Prometheus Project
/// 
/// Version: 1.0
/// 
/// History:
///     2006/12/10 - v1.0 feature complete.
///     
namespace Interfaces.Rendering.Interfaces
{
    /// <summary>
    /// Interface for the definition of a Photon.
    /// </summary>
    public interface IPhoton
    {
        #region IPhoton Members
        /// <summary>
        /// Colour of the photon.
        /// </summary>
        RealColor Color { get; set; }

        /// <summary>
        /// Direction of the photon.
        /// </summary>
        Vector3 Direction { get; set; }

        /// <summary>
        /// Position of the photon in 3d space.
        /// </summary>
        Vector3 Position { get; set; }

        /// <summary>
        /// Processes a collision between a Binary Space Partition (BSP)
        /// and the photon.
        /// </summary>
        /// <param name="bsp">BSP to process.</param>
        /// <param name="tmc">Texture map collection to store result.</param>
        /// <returns>Result of collision.</returns>
        bool ProcessCollision(List<IBsp> bsp, ITextureMapCollection textureCollection);

        /// <summary>
        /// Processes the collision of a photon and a model.
        /// </summary>
        /// <param name="model">Model to collide with.</param>
        /// <returns>Result of intersection test.</returns>
        bool ProcessCollision(IModel model);

      void ProcessCollision(global::Interfaces.Rendering.Radiosity.RadiosityIntersection intersection);

        /// <summary>
        /// U component of collision with texture.
        /// (3D->2D transform.)
        /// </summary>
        float U { get; set; }

        /// <summary>
        /// V component of collision with texture.
        /// (3D->2D transform.)
        /// </summary>
        float V { get; set; }
        #endregion
    }
}
