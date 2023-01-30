using CsharpVoxReader;
using CsharpVoxReader.Chunks;
using System;
using System.Collections.Generic;

namespace Vox2Mesh
{
    /// <summary>
    /// Loads data from a .vox file.
    /// </summary>
    public class Loader : IVoxLoader
    {
        /// <summary>
        /// Loads data from a .vox file at the specified <paramref name="path"/>.
        /// </summary>
        public Loader(string path)
        {
            var reader = new VoxReader(path, this);
            reader.Read();
        }

        public byte[,,] ids;
        public int sizeX;
        public int sizeY;
        public int sizeZ;
        public uint[] palette;

        public void LoadModel(Int32 sizeX, Int32 sizeY, Int32 sizeZ, byte[,,] data)
        {
            this.ids = data;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.sizeZ = sizeZ;
        }

        public void LoadPalette(UInt32[] palette)
        {
            this.palette = palette;
        }

        public void NewGroupNode(int id, Dictionary<string, byte[]> attributes, int[] childrenIds) { }
        public void NewLayer(int id, string name, Dictionary<string, byte[]> attributes) { }
        public void NewMaterial(int id, Dictionary<string, byte[]> attributes) { }
        public void NewShapeNode(int id, Dictionary<string, byte[]> attributes, int[] modelIds, Dictionary<string, byte[]>[] modelsAttributes) { }
        public void NewTransformNode(int id, int childNodeId, int layerId, string name, Dictionary<string, byte[]>[] framesAttributes) { }
        public void SetMaterialOld(int paletteId, MaterialOld.MaterialTypes type, float weight, MaterialOld.PropertyBits property, float normalized) { }
        public void SetModelCount(int count) { }
    }
}