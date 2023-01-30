using Unity.Mathematics;
using Unity.Collections;
using System.Collections;
using System;

namespace Vox2Mesh
{
    public struct VoxelArray : IEnumerable, IDisposable
    {
        public int WidthX { get; }
        public int Height { get; }
        public int WidthZ { get; }
        NativeArray<Voxel> native;

        public VoxelArray(int widthX, int height, int widthZ, Allocator allocator = Allocator.TempJob)
        {
            native = new NativeArray<Voxel>(widthX * height * widthZ, allocator);
            WidthX = widthX;
            Height = height;
            WidthZ = widthZ;
        }

        public Voxel this[int3 position]
        {
            get => this[position.x, position.y, position.z];
            set => this[position.x, position.y, position.z] = value;
        }

        public Voxel this[int x, int y, int z]
        {
            get => native[x + WidthX * (y + Height * z)];
            set => native[x + WidthX * (y + Height * z)] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return native.GetEnumerator();
        }

        public void Dispose()
        {
            native.Dispose();
        }
    }
}