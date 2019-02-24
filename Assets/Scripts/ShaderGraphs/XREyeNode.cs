using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("XR", "Stereo Eye")]
public class XREyeNode : CodeFunctionNode
{
	public XREyeNode()
	{
		name = "Stereo Eye";
	}
 
	protected override MethodInfo GetFunctionToConvert()
	{
		return GetType().GetMethod("MyCustomFunction",
			BindingFlags.Static | BindingFlags.NonPublic);
	}

	static string MyCustomFunction(
		[Slot(0, Binding.None)] out DynamicDimensionVector Eye)
	{
		return @"
		{
			Eye = unity_StereoEyeIndex;
		} 
		";
	}
}