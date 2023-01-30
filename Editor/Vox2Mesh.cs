using UnityEngine;
using UnityEditor.AssetImporters;

namespace Vox2Mesh
{
    [ScriptedImporter(1, ".vox")]
    public class Vox2Mesh : ScriptedImporter
    {
        public AmbientOcclusion ambientOcclusion;

        [System.Serializable]
        public class AmbientOcclusion
        {
            public bool enabled = true;
            [Range(-1f, 1f)] public float saturation = 0.2f;
            [Range(-1f, 1f)] public float value = -0.2f;
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            ambientOcclusion ??= new();

            var loader = new Loader(ctx.assetPath);
            var voxels = Voxelizer.GetVoxels(loader);
            var mesh = Mesher.GetMesh(voxels, ambientOcclusion);
            voxels.Dispose();

            ctx.AddObjectToAsset("mesh", mesh);
            ctx.SetMainObject(mesh);
        }
    }
}