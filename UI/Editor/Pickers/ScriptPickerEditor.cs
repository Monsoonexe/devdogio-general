using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Devdog.General.Editors
{
    public class ScriptPickerEditor : GenericObjectPickerBaseEditor<Type>
    {
        private static Type _type;
        private static Type[] _ignoreTypes = Array.Empty<Type>();

        public static ScriptPickerEditor Get(Type type, params Type[] ignoreTypes)
        {
            _type = type;
            _ignoreTypes = ignoreTypes;

            var window = GetWindow<ScriptPickerEditor>(true);
            window.windowTitle = "Script type picker";
            window.isUtility = true;

            return window;
        }

        protected override List<Type> FindObjects(bool searchProjectFolder)
        {
            // TODO - this doesn't feel right. the behaviour of this instance method changes based on static _type. 
            return ReflectionUtility.GetAllTypesThatImplement(_type, true).Where(o => !_ignoreTypes.Contains(o)).ToList();
        }

        protected override bool MatchesSearch(Type obj, string search)
        {
            return obj.Name.ToLower().Contains(search);
        }

        protected override void DrawObjectButton(Type item)
        {
            if (GUILayout.Button(item.Name))
            {
                NotifyPickedObject(item);
            }
        }
    }
}
