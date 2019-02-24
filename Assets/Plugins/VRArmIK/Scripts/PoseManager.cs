using UnityEngine;

namespace VRArmIK
{
	[ExecuteInEditMode]
	public class PoseManager : MonoBehaviour
	{
		public static PoseManager Instance = null;
		public VRTrackingReferences vrTransforms;

		public delegate void OnCalibrateListener();

		public event OnCalibrateListener onCalibrate;

		public const float referencePlayerHeightHmd = 1.7f;
		public const float referencePlayerWidthWrist = 1.39f;
		public float playerHeightHmd = 1.70f;
		public float playerWidthWrist = 1.39f;
		public float playerWidthShoulders = 0.31f;

		void OnEnable()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else if (Instance != null)
			{
				Debug.LogError("Multiple Instances of PoseManager in Scene");
			}
		}

		void Start()
		{
			onCalibrate += OnCalibrate;
		}

		[ContextMenu("calibrate")]
		void OnCalibrate()
		{
			playerHeightHmd = Camera.main.transform.position.y;
		}

		[ContextMenu("setArmLength")]
		public void calibrateIK()
		{
			playerWidthWrist = (vrTransforms.leftHand.position - vrTransforms.rightHand.position).magnitude;
			playerHeightHmd = vrTransforms.hmd.position.y;
			savePlayerSize(playerHeightHmd, playerWidthWrist);
		}

		public void savePlayerSize(float heightHmd, float widthWrist)
		{
			playerHeightHmd = heightHmd;
			playerWidthWrist = widthWrist;
			onCalibrate?.Invoke();
		}
	}
}