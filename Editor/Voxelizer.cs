using CsharpVoxReader;

namespace Vox2Mesh
{
    /// <summary>
    /// Turns <see cref="Loader"/> data into <see cref="Voxel"/> data.
    /// </summary>
    public static class Voxelizer
    {
        public static VoxelArray GetVoxels(Loader loader)
        {
            var voxels = new VoxelArray(loader.sizeX, loader.sizeY, loader.sizeZ);

            for (int x = 0; x < voxels.WidthX; x++)
            {
                for (int y = 0; y < voxels.Height; y++)
                {
                    for (int z = 0; z < voxels.WidthZ; z++)
                    {
                        var id = loader.ids[x, y, z];
                        if (id == 0) continue;

                        loader.palette[id].ToARGB(out var a, out var r, out var g, out var b);
                        voxels[x, y, z] = new Voxel(new(r, g, b, a));
                    }
                }
            }

            return voxels;
        }
    }
}