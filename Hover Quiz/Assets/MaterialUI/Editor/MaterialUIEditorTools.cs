//  Copyright 2014 Invex Games http://invexgames.com
//	Licensed under the Apache License, Version 2.0 (the "License");
//	you may not use this file except in compliance with the License.
//	You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//	Unless required by applicable law or agreed to in writing, software
//	distributed under the License is distributed on an "AS IS" BASIS,
//	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//	See the License for the specific language governing permissions and
//	limitations under the License.

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace MaterialUI
{
	[ExecuteInEditMode]
	public static class MaterialUIEditorTools
	{
		private static UnityEngine.GameObject theThing;
		private static UnityEngine.GameObject selectedObject;
		private static bool notCanvas;

		private static void SetupObject(string objectName)
		{
			selectedObject = Selection.activeGameObject;
			theThing.name = objectName;

			if (selectedObject)
			{
				if (UnityEngine.GameObject.Find(selectedObject.name))
				{
					if (selectedObject.GetComponentInParent<Canvas>())
                        notCanvas = false;
					else
                        notCanvas = true;
				}
				else
                    notCanvas = true;
			}
			else
				notCanvas = true;

			if (notCanvas)
			{
				if (!UnityEngine.GameObject.FindObjectOfType<UnityEngine.EventSystems.EventSystem>())
				{
                    UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/EventSystem.prefab",
						typeof (UnityEngine.GameObject))).name = "EventSystem";
				}

				if (UnityEngine.GameObject.FindObjectOfType<Canvas>())
				{
                    selectedObject = UnityEngine.GameObject.FindObjectOfType<Canvas>().gameObject as UnityEngine.GameObject;
				}
				else
				{
                    selectedObject =
                        UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Canvas.prefab",
                            typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
                    selectedObject.name = "Canvas";
				}
			}

			theThing.transform.SetParent(selectedObject.transform);
			theThing.transform.localPosition = Vector3.zero;
			theThing.transform.localScale = new Vector3(1, 1, 1);
			Selection.activeGameObject = theThing;
		}

		[MenuItem("GameObject/MaterialUI/Background", false, 1)]
		[MenuItem("MaterialUI/Create/Background", false, 1)]
		private static void CreateBackground()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Background.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Background");
			theThing.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/Panel", false, 1)]
		[MenuItem("MaterialUI/Create/Panel", false, 1)]
		private static void CreatePanel()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Panel.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Panel");
		}
		
		[MenuItem("GameObject/MaterialUI/Text", false, 1)]
		[MenuItem("MaterialUI/Create/Text", false, 1)]
		private static void CreateText()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Text.prefab",
                                                                     typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Text");
		}
		
		[MenuItem("GameObject/MaterialUI/Button/Text - Flat", false, 2)]
		[MenuItem("MaterialUI/Create/Button/Text - Flat", false, 2)]
		private static void CreateButtonFlat()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Button - Flat.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Button - Flat");
		}

		[MenuItem("GameObject/MaterialUI/Button/Text - Raised", false, 3)]
		[MenuItem("MaterialUI/Create/Button/Text - Raised", false, 3)]
		private static void CreateButtonRaised()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Button - Raised.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Button - Raised");
		}

		[MenuItem("GameObject/MaterialUI/Button/Round - Flat", false, 4)]
		[MenuItem("MaterialUI/Create/Button/Round - Flat", false, 4)]
		private static void CreateRoundButtonFlat()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(
                    "Assets/MaterialUI/ComponentPrefabs/Round Button - Flat.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Round Button - Flat");
		}

		[MenuItem("GameObject/MaterialUI/Button/Round - Raised", false, 5)]
		[MenuItem("MaterialUI/Create/Button/Round - Raised", false, 5)]
		private static void CreateRoundButtonRaised()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(
                    AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Round Button - Raised.prefab",
                        typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Round Button - Raised");
		}

		[MenuItem("GameObject/MaterialUI/Button/Small Round - Flat", false, 6)]
		[MenuItem("MaterialUI/Create/Button/Small Round - Flat", false, 6)]
		private static void CreateSmallRoundButtonFlat()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(
                    AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Round Button - Small - Flat.prefab",
                        typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Small Round Button - Flat");
		}

		[MenuItem("GameObject/MaterialUI/Button/Small Round - Raised", false, 7)]
		[MenuItem("MaterialUI/Create/Button/Small Round - Raised", false, 7)]
		private static void CreateSmallRoundButtonRaised()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(
                    AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Round Button - Small - Raised.prefab",
                        typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Small Round Button - Raised");
		}

		[MenuItem("GameObject/MaterialUI/Spinny Arrow Button", false, 7)]
		[MenuItem("MaterialUI/Create/Spinny Arrow Button", false, 7)]
		private static void CreateSpinnyArrowButton()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(
                    "Assets/MaterialUI/ComponentPrefabs/SpinnyArrow Button.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Spinny Arrow Button");
		}

		[MenuItem("GameObject/MaterialUI/Checkbox", false, 8)]
		[MenuItem("MaterialUI/Create/Checkbox", false, 8)]
		private static void CreateCheckbox()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Checkbox.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Checkbox");
		}

		[MenuItem("GameObject/MaterialUI/Radio Buttons", false, 9)]
		[MenuItem("MaterialUI/Create/Radio Buttons", false, 9)]
		private static void CreateRadioButtons()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/RadioGroup.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Radio Buttons");
		}

		[MenuItem("GameObject/MaterialUI/Switch", false, 10)]
		[MenuItem("MaterialUI/Create/Switch", false, 10)]
		private static void CreateSwitch()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Switch.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Switch");
		}

		[MenuItem("GameObject/MaterialUI/Text Input", false, 11)]
		[MenuItem("MaterialUI/Create/Text Input", false, 11)]
		private static void CreateTextInput()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/TextInput.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Text Input");
		}

		[MenuItem("GameObject/MaterialUI/Slider", false, 12)]
		[MenuItem("MaterialUI/Create/Slider", false, 12)]
		private static void CreateSlider()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Slider.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Slider");
		}

		[MenuItem("GameObject/MaterialUI/Selection Box/Raised", false, 13)]
		[MenuItem("MaterialUI/Create/Selection Box/Raised", false, 13)]
		private static void CreateSelectionBox()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/SelectionBox.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Selection Box");
		}

		[MenuItem("GameObject/MaterialUI/Selection Box/Flat", false, 13)]
		[MenuItem("MaterialUI/Create/Selection Box/Flat", false, 13)]
		private static void CreateSelectionBoxFlat()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(
                    "Assets/MaterialUI/ComponentPrefabs/SelectionBox - Flat.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Selection Box - Flat");
		}

		[MenuItem("GameObject/MaterialUI/Dialog Box/Normal", false, 13)]
		[MenuItem("MaterialUI/Create/Dialog Box/Normal", false, 13)]
		private static void CreateDialogBoxNormal()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(
                    "Assets/MaterialUI/ComponentPrefabs/DialogBox - Normal.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Dialog Box - Normal");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/Dialog Box/Scroll", false, 13)]
		[MenuItem("MaterialUI/Create/Dialog Box/Scroll", false, 13)]
		private static void CreateDialogBoxScroll()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(
                    "Assets/MaterialUI/ComponentPrefabs/DialogBox - Scroll.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Dialog Box - Scroll");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/Dialog Box/Simple", false, 13)]
		[MenuItem("MaterialUI/Create/Dialog Box/Simple", false, 13)]
		private static void CreateDialogBoxSimple()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath(
                    "Assets/MaterialUI/ComponentPrefabs/DialogBox - Simple.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Dialog Box - Simple");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/Divider/Light", false, 13)]
		[MenuItem("MaterialUI/Create/Divider/Light", false, 13)]
		private static void CreateDividerLight()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Divider - Light.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Divider");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/Divider/Dark", false, 13)]
		[MenuItem("MaterialUI/Create/Divider/Dark", false, 13)]
		private static void CreateDividerDark()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Divider - Dark.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Divider");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/ListView", false, 13)]
		[MenuItem("MaterialUI/Create/List/ListView", false, 13)]
		private static void CreateListView()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/ListView.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("ListView");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			theThing.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Single-line item/Text only", false, 13)]
		[MenuItem("MaterialUI/Create/List/Single-line item/Text only", false, 13)]
		private static void CreateListItemSingle()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Single.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Single-line item/Text with icon", false, 13)]
		[MenuItem("MaterialUI/Create/List/Single-line item/Text with icon", false, 13)]
		private static void CreateListItemSingleIcon()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Single Icon.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Single-line item/Text with avatar", false, 13)]
		[MenuItem("MaterialUI/Create/List/Single-line item/Text with avatar", false, 13)]
		private static void CreateListItemSingleAvatar()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Single Avatar.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Single-line item/Text with icon and avatar", false, 13)]
		[MenuItem("MaterialUI/Create/List/Single-line item/Text Only", false, 13)]
		private static void CreateListItemSingleIconAvatar()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Single Icon Avatar.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Double-line item/Text only", false, 13)]
		[MenuItem("MaterialUI/Create/List/Double-line item/Text only", false, 13)]
		private static void CreateListItemDouble()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Double.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Double-line item/Text with icon", false, 13)]
		[MenuItem("MaterialUI/Create/List/Double-line item/Text with icon", false, 13)]
		private static void CreateListItemDoubleIcon()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Double Icon.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Double-line item/Text with avatar", false, 13)]
		[MenuItem("MaterialUI/Create/List/Double-line item/Text with avatar", false, 13)]
		private static void CreateListItemDoubleAvatar()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Double Avatar.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Double-line item/Text with icon and avatar", false, 13)]
		[MenuItem("MaterialUI/Create/List/Double-line item/Text Only", false, 13)]
		private static void CreateListItemDoubleIconAvatar()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Double Icon Avatar.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Triple-line item/Text only", false, 13)]
		[MenuItem("MaterialUI/Create/List/Triple-line item/Text only", false, 13)]
		private static void CreateListItemTriple()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Triple.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Triple-line item/Text with icon", false, 13)]
		[MenuItem("MaterialUI/Create/List/Triple-line item/Text with icon", false, 13)]
		private static void CreateListItemTripleIcon()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Triple Icon.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Triple-line item/Text with avatar", false, 13)]
		[MenuItem("MaterialUI/Create/List/Triple-line item/Text with avatar", false, 13)]
		private static void CreateListItemTripleAvatar()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Triple Avatar.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/List/Triple-line item/Text with icon and avatar", false, 13)]
		[MenuItem("MaterialUI/Create/List/Triple-line item/Text Only", false, 13)]
		private static void CreateListItemTripleIconAvatar()
		{
            theThing = UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/List Item/List Item Triple Icon Avatar.prefab", typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("List Item");
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}



		[MenuItem("GameObject/MaterialUI/Nav Drawer", false, 13)]
		[MenuItem("MaterialUI/Create/Nav Drawer", false, 13)]
		private static void CreateNavDrawer()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Nav Drawer.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Nav Drawer");
			theThing.GetComponent<RectTransform>().sizeDelta = new Vector2(theThing.GetComponent<RectTransform>().sizeDelta.x, 8f);
			theThing.GetComponent<RectTransform>().anchoredPosition =
				new Vector2(-theThing.GetComponent<RectTransform>().sizeDelta.x/2f, 0f);
		}

		[MenuItem("GameObject/MaterialUI/App Bar", false, 13)]
		[MenuItem("MaterialUI/Create/App Bar", false, 13)]
		private static void CreateAppBar()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/App Bar.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("App Bar");
			theThing.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/Screen Manager", false, 13)]
		[MenuItem("MaterialUI/Create/Screen Manager", false, 13)]
		private static void CreateScreenManager()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/ScreenManager.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Screen Manager");
			theThing.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("GameObject/MaterialUI/Screen", false, 13)]
		[MenuItem("MaterialUI/Create/Screen", false, 13)]
		private static void CreateScreen()
		{
            theThing =
                UnityEngine.GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/MaterialUI/ComponentPrefabs/Screen.prefab",
                    typeof(UnityEngine.GameObject))) as UnityEngine.GameObject;
			SetupObject("Screen");
			theThing.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
			theThing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		[MenuItem("Component/MaterialUI/Ripple Config")]
		[MenuItem("MaterialUI/Add Component/Ripple Config")]
		private static void AddRippleConfig()
		{
			selectedObject = Selection.activeGameObject;

			if (selectedObject)
			{
				if (UnityEngine.GameObject.Find(selectedObject.name))
				{
                    selectedObject.AddComponent<RippleConfig>();
				}
			}
		}

		[MenuItem("Component/MaterialUI/Shadow Config")]
		[MenuItem("MaterialUI/Add Component/Shadow Config")]
		private static void AddShadowConfig()
		{
			selectedObject = Selection.activeGameObject;

			if (selectedObject)
			{
				if (UnityEngine.GameObject.Find(selectedObject.name))
				{
                    selectedObject.AddComponent<ShadowConfig>();
				}
			}
		}

		[MenuItem("Component/MaterialUI/Rect Transform Snapper")]
		[MenuItem("MaterialUI/Add Component/Rect Transform Snapper")]
		private static void AddRectTransformSnap()
		{
			selectedObject = Selection.activeGameObject;

			if (selectedObject)
			{
				if (UnityEngine.GameObject.Find(selectedObject.name))
				{
                    selectedObject.AddComponent<RectTransformSnap>();
				}
			}
		}

		[MenuItem("Component/MaterialUI/Shadow Generator")]
		[MenuItem("MaterialUI/Add Component/Shadow Generator")]
		private static void AddShadowGen()
		{
			selectedObject = Selection.activeGameObject;

			if (selectedObject)
			{
				if (UnityEngine.GameObject.Find(selectedObject.name))
				{
                    selectedObject.AddComponent<ShadowGen>();
				}
			}
		}

		[MenuItem("Component/MaterialUI/Toaster")]
		[MenuItem("MaterialUI/Add Component/Toaster")]
		private static void AddToaster()
		{
			selectedObject = Selection.activeGameObject;

			if (selectedObject)
			{
				if (UnityEngine.GameObject.Find(selectedObject.name))
				{
                    selectedObject.AddComponent<Toaster>();
				}
			}
		}

		[MenuItem("Component/MaterialUI/EZAnim")]
		[MenuItem("MaterialUI/Add Component/EZAnim")]
		private static void AddEZAnim()
		{
			selectedObject = Selection.activeGameObject;

			if (selectedObject)
			{
				if (UnityEngine.GameObject.Find(selectedObject.name))
				{
                    selectedObject.AddComponent<EZAnim>();
				}
			}
		}

		[MenuItem("MaterialUI/Report a Bug - Request a Feature")]
		private static void Feedback()
		{
			Application.OpenURL("https://github.com/InvexGames/MaterialUI/issues");
		}

		[MenuItem("MaterialUI/Wiki")]
		private static void Wiki()
		{
			Application.OpenURL("https://github.com/InvexGames/MaterialUI/wiki");
		}

		[MenuItem("MaterialUI/Check for Update (current v" + MaterialUIVersion.currentVersion + ")")]
		private static void About()
		{
			Application.OpenURL("https://github.com/InvexGames/MaterialUI/releases");
		}
	}
}