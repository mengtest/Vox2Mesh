<div align="center">
<h1><span style="color: #ac4cec;">Vox</span><span style="color: white;">2</span><span style="color: #6ebdee;">Mesh</span></h1>
<span>.vox importer for Unity</span>
</div>
<br/>

## Installation
1. In the Unity Editor, select **Window > Package Manager**.
2. Press the ➕ icon, then select **Add package from git URL...**
3. Paste `https://github.com/pixldev/Vox2Mesh.git`, then press **Add**.

## Usage
- After installing the package, all .vox files will behave like meshes automatically.  
![Mesh in the project window](./usage_1.png)

- To display a mesh, simply drag it into a Mesh Filter component.  
![Mesh Filter component](./usage_2.png)

- To display its colors, add a material to a Mesh Renderer component. The package comes with a different material for each render pipeline.  
![Mesh Renderer component](./usage_3.png)  
To see the materials on the list, you may need to press the eye icon in the top right corner of the window.  
![Mesh Renderer component](./usage_4.png)

- Vox2Mesh also features a baked ambient occlusion system. You can configure it in the inspector, after selecting a .vox file.  
![Mesh Filter component](./usage_5.png)

## Compatibility
- Unity 2021.3+
- URP, HDRP, BIRP
