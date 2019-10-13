using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShader : MonoBehaviour
{
    public Material Shader;
    public Material CloseShader;
    public MeshRenderer meshEdit;
    Material[] matArray;
    Material[] matArrayShader;
    Material[] matArrayShaderClose;
    // Start is called before the first frame update
    void Start()
    {
        matArray = meshEdit.materials;
        matArrayShader = new Material[matArray.Length + 1];
        matArrayShaderClose = new Material[matArray.Length + 1];
        matArray.CopyTo(matArrayShader, 0);
        matArray.CopyTo(matArrayShaderClose, 0);
        matArrayShader[matArray.Length] = Shader;
        matArrayShaderClose[matArray.Length] = CloseShader;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void activate()
    {
        meshEdit.materials = matArrayShader;
    }
    public void disable()
    {
        meshEdit.materials = matArray;
    }
    public void activateClose()
    {
        meshEdit.materials = matArrayShaderClose;
    }
    public void deactivateClose()
    {
        meshEdit.materials = matArray;
    }
}
