using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Jobs;

namespace Vox2Mesh
{
    /// <summary>
    /// Turns <see cref="Voxel"/> data into <see cref="Mesh"/> data.
    /// </summary>
    public static class Mesher
    {
        public static Mesh GetMesh(VoxelArray voxels, Vox2Mesh.AmbientOcclusion ambientOcclusion)
        {
            using var vertices = new NativeList<float3>(Allocator.TempJob);
            using var triangles = new NativeList<int>(Allocator.TempJob);
            using var colors = new NativeList<Color32>(Allocator.TempJob);

            var job = new MeshJob
            {
                voxels = voxels,
                vertices = vertices,
                triangles = triangles,
                colors = colors,
                aoEnabled = ambientOcclusion.enabled,
                aoSaturation = ambientOcclusion.saturation,
                aoValue = ambientOcclusion.value,
            };

            var handle = job.Schedule();
            handle.Complete();

            var mesh = new Mesh();
            mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            mesh.SetVertices(vertices.AsArray());
            mesh.SetIndices(triangles.AsArray(), MeshTopology.Triangles, 0);
            mesh.SetColors(colors.AsArray());
            mesh.RecalculateNormals();
            mesh.Optimize();

            return mesh;
        }
    }
}