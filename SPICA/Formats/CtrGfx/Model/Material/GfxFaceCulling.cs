using SPICA.PICA.Commands;

using System;

namespace SPICA.Formats.CtrGfx.Model.Material
{
    public enum GfxFaceCulling : uint
    {
        FrontFace,
        BackFace,
        Always,
        Never
    }

    static class GfxFaceCullingExtensions
    {
        public static PICAFaceCulling ToPICAFaceCulling(this GfxFaceCulling FaceCulling)
        {
            switch (FaceCulling)
            {
                case GfxFaceCulling.FrontFace: return PICAFaceCulling.FrontFace;
                case GfxFaceCulling.BackFace:  return PICAFaceCulling.BackFace;
                case GfxFaceCulling.Always:    return PICAFaceCulling.FrontFace;
                case GfxFaceCulling.Never:     return PICAFaceCulling.Never;

                default: throw new ArgumentException($"Invalid PICA Face Culling {FaceCulling}!");
            }
        }

        public static GfxFaceCulling ToGfxFaceCulling(this PICAFaceCulling FaceCulling)
        {
            switch (FaceCulling)
            {
                case PICAFaceCulling.FrontFace: return GfxFaceCulling.FrontFace;
                case PICAFaceCulling.BackFace: return GfxFaceCulling.BackFace;
                //case PICAFaceCulling.Always: return GfxFaceCulling.FrontFace;
                case PICAFaceCulling.Never: return GfxFaceCulling.Never;

                default: throw new ArgumentException($"Invalid Gfx Face Culling {FaceCulling}!");
            }
        }
    }
}
