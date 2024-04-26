using Photon.Pun;
using PlayFab.ExperimentationModels;
using Rift.Menu;
using UnityEngine;
using static Rift.Menu.Main;
using static Rift.Settings;

namespace Rift.Classes
{
	internal class Button : MonoBehaviour
	{
		public string relatedText;

		public static float buttonCooldown = 0f;
		
		public void OnTriggerEnter(Collider collider)
		{
			if (Time.time > buttonCooldown && collider == buttonCollider && menu != null)
			{
                buttonCooldown = Time.time + 0.2f;
                GorillaTagger.Instance.StartVibration(rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(Variables.buttonIndex, false, 0.4f);
                Toggle(this.relatedText);
            }
		}
	}
}
