<div align="center">
<h1><span style="color: #ac4cec;">Vox</span><span style="color: white;">2</span><span style="color: #6ebdee;">Mesh</span></h1>
<span>.vox importer for Unity</span>
</div>
<br/>

1. [Installation](#installation)
2. [Usage](#usage)
3. [Compatibility](#compatibility)

## Installation
1. In the Unity Editor, select **Window > Package Manager**.
2. Press the ➕ icon, then select **Add package from git URL...**
3. Paste `https://github.com/pixldev/Vox2Mesh.git`, then press **Add**.

## Usage
After installing the package, all .vox files will behave like meshes automatically.
<br/>\<Image TBA\><br/><br/>
To display a mesh, simply drag it into a Mesh Filter component.
<br/>\<Image TBA\><br/><br/>
To display its colors, add a material to a Mesh Renderer component.
The package comes with a different material for each render pipeline.
Their names are `Vox2Mesh_URP`, `Vox2Mesh_HDRP` and `Vox2Mesh_BuiltIn`.
To see the materials on the list, you may need to press the eye icon in the top right corner of the window. 
<br/>\<Image TBA\><br/><br/>

## Compatibility
- Unity 2021.3+
- URP, HDRP, BIRP
