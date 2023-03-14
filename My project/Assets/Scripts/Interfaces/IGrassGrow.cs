using System;

internal interface IGrassGrow
{
    public event Action GrassGrowned;
    void OnGrassBevelled();
}
