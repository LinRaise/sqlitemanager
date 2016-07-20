//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Collections.Generic;
using SQLiteManager.Core.Utilities;

namespace SQLiteManager.Gui.FormPositioning
{
	[Serializable]
	public class ApplicationFormsPositions
	{
	    private static readonly string STR_SETTINGS_FILE_NAME = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SQLite Manager\\" + "Settings.bin";

	    private static ApplicationFormsPositions formsPositionCache;
		private static Dictionary<Type, FormPositionInfo> formPositions = new Dictionary<Type, FormPositionInfo>();

		public static ApplicationFormsPositions FormsPositionCache {
			get {
				if (formsPositionCache == null) {
					// Load the saved position from the settings file
					formsPositionCache = SerializationUtility.BinarySerializer.DeserializeFromFile<ApplicationFormsPositions>(STR_SETTINGS_FILE_NAME);
					
					// If there is no file => the cache is still null => is first run of app => create new cache
					if (formsPositionCache == null) {
						formsPositionCache = new ApplicationFormsPositions();
					}
				}
				
				return formsPositionCache;
			}
			
			set {
				formsPositionCache = value;
			}
		}

        public ApplicationFormsPositions()
        {
        }

	    public FormPositionInfo GetFormPositionInfo(BaseForm baseForm)
	    {
	    	if (formPositions.ContainsKey(baseForm.GetType())) {
				return formPositions[baseForm.GetType()];
	    	}
	        return null;
	    }

	    public void SetFormPositionInfo(BaseForm baseForm, FormPositionInfo formPositionInfo)
		{
	    	if (formPositions.ContainsKey(baseForm.GetType())) {
				formPositions[baseForm.GetType()] = formPositionInfo;
	    	} else {
				formPositions.Add(baseForm.GetType(), formPositionInfo);
	    	}
			
			SerializationUtility.BinarySerializer.SerializeToFile(this, STR_SETTINGS_FILE_NAME);
		}
	}
}
