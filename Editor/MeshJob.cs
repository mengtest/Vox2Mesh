using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;
using UnityEngine;

namespace Vox2Mesh
{
    [BurstCompile]
    public struct MeshJob : IJob
    {
        [ReadOnly] public VoxelArray voxels;
        public NativeList<float3> vertices;
        [WriteOnly] public NativeList<int> triangles;
        [WriteOnly] public NativeList<Color32> colors;
        [ReadOnly] public bool aoEnabled;
        [ReadOnly] public float aoSaturation;
        [ReadOnly] public float aoValue;

        public void Execute()
        {
            for (int x = 0; x < voxels.WidthX; x++)
            {
                for (int y = 0; y < voxels.Height; y++)
                {
                    for (int z = 0; z < voxels.WidthZ; z++)
                    {
                        var voxel = voxels[x, y, z];
                        if (!voxel.solid) continue;

                        MakeVoxel(new int3(x, y, z), voxel.color);
                    }
                }
            }
        }

        void MakeVoxel(int3 position, Color32 color)
        {
            for (int face = 0; face < 6; face++)
            {
                var verticesCount = vertices.Length;

                if (!IsFaceVisible(face, position)) continue;

                var aoLevels = new NativeArray<int>(4, Allocator.Temp);
                for (int vertex = 0; vertex < 4; vertex++)
                {
                    vertices.Add(Voxel.vertices[face][vertex] + position);

                    if (aoEnabled)
                    {
                        var level = GetAOLevel(position, face, vertex);
                        aoLevels[vertex] = level;

                        colors.Add(GetAOColor(color, level));
                    }
                    else
                    {
                        colors.Add(color);
                    }
                }

                var trianglesToAdd = aoLevels[0] + aoLevels[2] > aoLevels[1] + aoLevels[3] ? Voxel.trianglesFlipped : Voxel.triangles;
                for (int i = 0; i < 6; i++)
                {
                    triangles.Add(verticesCount + trianglesToAdd[i]);
                }

                aoLevels.Dispose();
            }
        }

        int GetAOLevel(int3 position, int face, int vertex)
        {
            var level = 0;
            for (int i = 0; i < 3; i++)
            {
                var offset = Voxel.ambientOcclusion[face][vertex][i] + position;

                if (IsVoxelInBounds(offset) && voxels[offset].solid)
                {
                    level += 1;
                }
            }

            return level;
        }

        Color32 GetAOColor(Color32 color, int level)
        {
            Color.RGBToHSV(color, out var h, out var s, out var v);
            return Color.HSVToRGB(
                h,
                math.clamp(s + aoSaturation * level, 0f, 1f),
                math.clamp(v + aoValue * level, 0f, 1f)
            );
        }

        bool IsFaceVisible(int direction, int3 position)
        {
            var next = position + Voxel.directions[direction];
            if (!IsVoxelInBounds(next)) return true;

            return !voxels[next].solid;
        }

        bool IsVoxelInBounds(int3 position)
        {
            return
                position.x >= 0 && position.x < voxels.WidthX &&
                position.z >= 0 && position.z < voxels.WidthZ &&
                position.y >= 0 && position.y < voxels.Height;
        }
    }
}