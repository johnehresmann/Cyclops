using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace DarkTonic.CoreGameKit {
    public static class UndoHelper {
        public static void CreateObjectForUndo(GameObject go, string actionName) {
            // New Undo API
            Undo.RegisterCreatedObjectUndo(go, actionName);
        }
         
        public static void SetTransformParentForUndo(Transform child, Transform newParent, string name) {
            // New Undo API
            Undo.SetTransformParent(child, newParent, name);
        }

        // ReSharper disable once RedundantAssignment
        public static void RecordObjectPropertyForUndo(ref bool isDirty, Object objectProperty, string actionName) {
            isDirty = true;

            // New Undo API
            Undo.RecordObject(objectProperty, actionName);
        }

        public static void RecordObjectsForUndo(Object[] objects, string actionName) {
            // New Undo API
            Undo.RecordObjects(objects, actionName);
        }

        public static void DestroyForUndo(GameObject go) {
            // New Undo API
            Undo.DestroyObjectImmediate(go);
        }
    }
}