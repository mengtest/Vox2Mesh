<div align="center">
<h1>Vox2Mesh</h1>
<span>.vox importer for Unity</span>
</div>
<br/>

## Installation
1. In the Unity Editor, select **Window > Package Manager**.
2. Press the ➕ icon, then select **Add package from git URL...**
3. Paste `https://github.com/pixldev/Vox2Mesh.git`, then press **Add**.
  
*Also available on [OpenUPM](https://openupm.com/packages/com.pixl.vox2mesh/)*

## Usage
After installing the package, all .vox files behave like meshes automatically.
  
![Mesh](https://user-images.githubusercontent.com/36799862/217020499-76210e18-afb4-44fc-aaca-bd7b4046e6e5.png)  


### Mesh
To display a mesh, simply drag it into a Mesh Filter component.
  
![Mesh Filter](https://user-images.githubusercontent.com/36799862/217020520-51ad4a07-833f-444b-95c1-20709f92b9c2.png)

### Material
The package comes with a different material for each render pipeline.
To see the materials on the list, you may need to press the eye icon in the top right corner of the window.
  
![Mesh Renderer](https://user-images.githubusercontent.com/36799862/217020539-f4f17628-f26f-4b94-8600-6bbdadb5b2be.png)  
![Select Material](https://user-images.githubusercontent.com/36799862/217020549-44cff390-4749-4424-bafc-25fbfcc76a5d.png)
### Ambient Occlusion
Vox2Mesh features a baked ambient occlusion system. You can configure it in the inspector, after selecting a .vox file.
  
![AO](https://user-images.githubusercontent.com/36799862/217020558-5a0b5083-101a-4f16-ba85-2c5d02a7ff7d.png)

## Compatibility
- Unity 2021.3+
- URP, HDRP, BIRP
