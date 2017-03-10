using System;

namespace Interfaces.Rendering.Interfaces
{
    public interface ITextureMapCollection
    {
        void AddTexture(ITextureMap texture);
        int Count { get; }
        int Radius { get; set; }
        void SaveAllRaw(string path);
        void SaveAllTag(string taglocation);
        ITextureMap this[int index] { get; set; }
    }
}
